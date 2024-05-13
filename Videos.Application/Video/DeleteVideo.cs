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
		public DeleteVideo(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Do(string videoId)
		{
			var video = _context.Videos.FirstOrDefault(x => x.VideoId == videoId);
			_context.Videos.Remove(video);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
