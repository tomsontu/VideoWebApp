using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videos.Database;

namespace Videos.Application.Video
{
	public class DeleteVideo
	{
		private readonly ApplicationDbContext _context;
		private readonly RedisDb _redisDb;

		public DeleteVideo(ApplicationDbContext context, RedisDb redisDb)
		{
			_context = context;
			_redisDb = redisDb;
		}

		public async Task<bool> Do(string videoId)
		{
			var video = _context.Videos.FirstOrDefault(x => x.VideoId == videoId);
			_context.Videos.Remove(video);
			bool dbIsDeleted = await _context.SaveChangesAsync() > 0;
			bool redisIsdeleted = _redisDb.GetDatabase().SetRemove("processed_video_ids", videoId);
			return dbIsDeleted && redisIsdeleted;
		}
	}
}
