using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Videos.Domain;

namespace Videos.Application.Video
{
	public class GetVideo
	{
		private readonly ApplicationDbContext _context;
		public GetVideo(ApplicationDbContext context)
		{
			_context = context;
		}

		public class VideoViewModel
		{
			public string VideoId { get; set; }
			public string AuthorName { get; set; }
			public string AuthorId { get; set; }
			public string CreateTime { get; set; }
			public string Duration { get; set; }
			public string VideoUrl { get; set; }
            public string Ratio { get; set; }
            public string Format { get; set; }
            public string Height { get; set; }
            public string Size { get; set; }
            public string VideoQuality { get; set; }
        }

		public VideoViewModel Do(string videoId)
		{
			return _context.Videos.AsEnumerable().Where(x=>x.VideoId==videoId).Select(x =>
			{
				JToken jToken = JsonConvert.DeserializeObject<JToken>(x.JsonString);

				string authorName = jToken.SelectToken("$.author.uniqueId").Value<string>();
				string authorId = jToken.SelectToken("$.author.id").Value<string>();
				DateTime createTime = DateTimeOffset.FromUnixTimeSeconds(jToken.SelectToken("$.createTime").Value<long>()).UtcDateTime;
				string duration = jToken.SelectToken("$.video.duration").Value<int>().ToString();
				string videoUrl = jToken.SelectToken("$.video_url").Value<string>();
				string ratio= jToken.SelectToken("$.video.ratio").Value<string>();
				string format= jToken.SelectToken("$.video.format").Value<string>();
				string height= jToken.SelectToken("$.video.height").Value<string>();
				string size = (jToken.SelectToken("$.video.size").Value<int>() / 1024.0 / 1024.0).ToString() + "MB";
				string videoQuality = jToken.SelectToken("$.video.videoQuality").Value<string>();

				return new VideoViewModel
				{
					VideoId = x.VideoId,
					AuthorName = authorName,
					AuthorId = authorId,
					CreateTime = createTime.ToString(),
					Duration = duration,
					VideoUrl = videoUrl,
					Ratio = ratio,
					Format = format,
					Height = height,
					Size = size,
					VideoQuality = videoQuality,
				};
			}).FirstOrDefault();
		}
	}
}
