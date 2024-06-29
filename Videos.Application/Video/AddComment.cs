using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videos.Database;
using Videos.Domain;

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
			var searchResponse = _elasticsearchDb.GetClient().Search<ESVideo>(s => s
			.Query(q => q
				.Term(t => t.Field(f => f.VideoId).Value(request.VideoId))
				)
			);


			string descFromES = "";
			// Directly access the first hit if it exists
			if (searchResponse.Hits.Count > 0)
			{
				var hit = searchResponse.Hits.FirstOrDefault();
				descFromES = hit.Source.Description;
			}

			string newESDesc = descFromES + ". " + commentsFromMysql;


			var updateESresponse = _elasticsearchDb.GetClient().Update<ESVideo>(request.VideoId, u => u
				.Doc(new ESVideo { Description = newESDesc })
				.DocAsUpsert()
			);

			return new
            {
                Result = updateESresponse.IsValid,
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
	}
}
