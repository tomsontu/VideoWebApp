using Elasticsearch.Net;
using Microsoft.Extensions.Logging;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Videos.Database;
using Videos.Domain;
using static Videos.Application.Video.AddRemark;

namespace Videos.Application.Video
{
	public class AddComment
	{
		private readonly ApplicationDbContext _context;
		private readonly ILogger _logger;
		private readonly ElasticSearchDb _elasticsearchDb;

		public AddComment(ApplicationDbContext context, ILogger logger, ElasticSearchDb esDb)
        {
            _context = context;
            _logger = logger;
			_elasticsearchDb = esDb;
        }

        public async Task<object> Do(Request request)
        {
            var review = new Review
            {
                VideoId = request.VideoId,
                VideoReview = request.Comment,
            };
            _context.Reviews.Add(review);
			await _context.SaveChangesAsync();


            _logger.LogInformation($"A user has posted a comment '{request.Comment}' on the video {request.VideoId}");

            var commentObjFromMysql = _context.Reviews.Where(x => x.VideoId == request.VideoId).ToList();
            string commentsFromMysql = "";
            commentObjFromMysql.ForEach(x =>
            {
                commentsFromMysql += (x.VideoReview + ", ");
            });

			//search in ES
			//NEST does not work in proxy, so here we send request


			// Configure the proxy
			//var proxy = new WebProxy("http://127.0.0.1:15236");
			//var httpClientHandler = new HttpClientHandler
			//{
			//	Proxy = proxy,
			//	UseProxy = true
			//};

			string descFromES = "";

			using (var httpClient = new HttpClient())
			{
				//must be 127.0.0.1:9200 instead of localhost
				var response = await httpClient.GetAsync($"http://127.0.0.1:9200/videos/_doc/{request.VideoId}");

				if (response.IsSuccessStatusCode)
				{
					var jsonResponse = await response.Content.ReadAsStringAsync();
					var document = JsonConvert.DeserializeObject<ElasticsearchResponse<ESVideo>>(jsonResponse);

					if (document.Found)
					{
						var video = document.Source;
						descFromES = video.Description;
					}
					
				}
			}

			string newESDesc = descFromES + ". " + commentsFromMysql;

			//update es record

			var updateDocument = new
			{
				doc = new
				{
					description = newESDesc
				}
			};

			var jsonContent = JsonConvert.SerializeObject(updateDocument);
			var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

			bool result = false;

			using (var httpClient = new HttpClient())
			{
				var response = await httpClient.PostAsync($"http://127.0.0.1:9200/videos/_update/{request.VideoId}", content);

				if (response.IsSuccessStatusCode)
				{
					result = true;
				}
			}

			return new
            {
                Result = result,
            };
        }

		public class Request
		{
			public string VideoId { get; set; }
			public string Comment { get; set; }
		}

		public class ESVideo
		{
			public string VideoId { get; set; }
			public string Description { get; set; }
		}

		public class ElasticsearchResponse<T>
		{
			[JsonProperty("_index")]
			public string Index { get; set; }

			[JsonProperty("_type")]
			public string Type { get; set; }

			[JsonProperty("_id")]
			public string Id { get; set; }

			[JsonProperty("_version")]
			public int Version { get; set; }

			[JsonProperty("found")]
			public bool Found { get; set; }

			[JsonProperty("_source")]
			public T Source { get; set; }
		}
	}
}
