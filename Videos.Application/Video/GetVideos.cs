using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Videos.Database;

namespace Videos.Application.Video
{
    public class GetVideos
    {
        private readonly ApplicationDbContext _context;

        public GetVideos(ApplicationDbContext context)
        {
            _context = context;
        }

        public class VideoListViewModel
        {
            public int Id { get; set; }
            public string VideoId { get; set; }
			public string AuthorId { get; set; }
			public string AuthorName { get; set; }
            public string Description { get; set; }
            public string CreateTime { get; set; }
            public string DiggCount { get; set; }
            public string Duration { get; set; }
            public string VideoUrl { get; set; }
            public string Remark { get; set; }

        }

        public IEnumerable<VideoListViewModel> Do()
        {
            return _context.Videos.ToList().Select(x =>
            {
                JToken jToken = JsonConvert.DeserializeObject<JToken>(x.JsonString);

                string authorName = jToken.SelectToken("$.author.uniqueId").Value<string>();
				string authorId = jToken.SelectToken("$.author.id").Value<string>();
				string description = jToken.SelectToken("$.contents[0].desc").Value<string>();
                DateTime createTime = DateTimeOffset.FromUnixTimeSeconds(jToken.SelectToken("$.createTime").Value<long>()).UtcDateTime;
                string diggCount = jToken.SelectToken("$.statsV2.diggCount").Value<string>();
                string duration = jToken.SelectToken("$.video.duration").Value<int>().ToString();
                string videoUrl = jToken.SelectToken("$.video_url").Value<string>();

                return new VideoListViewModel
                {
                    Id = x.Id,
                    VideoId = x.VideoId,
                    Remark = x.Remark,
                    AuthorName = authorName,
                    Description = description,
                    CreateTime = createTime.ToString(),
                    DiggCount = diggCount,
                    Duration = duration,
                    VideoUrl = videoUrl,
                    AuthorId = authorId,
                };
            });
        }
    }
}
