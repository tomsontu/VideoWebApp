using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videos.Database;

namespace Videos.Application.Video
{
	public class AddRemark
	{
		private readonly ApplicationDbContext _context;
		public AddRemark(ApplicationDbContext context)
		{
			_context = context;
		}

		public class Request
		{
            public string Remark { get; set; }
            public string VideoId { get; set; }
        }

		public class Response
		{
            public bool Result { get; set; }
        }

		public async Task<Response> Do(Request request)
		{
			var video = _context.Videos.FirstOrDefault(x => x.VideoId == request.VideoId);
			video.Remark = request.Remark;
			var result = await _context.SaveChangesAsync() > 0;
			return new Response
			{
				Result = result,
			};
		}
	}
}
