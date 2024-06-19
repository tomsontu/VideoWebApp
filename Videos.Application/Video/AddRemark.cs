using Microsoft.Extensions.Logging;
using Stripe;
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
		private readonly ILogger _logger;

		public AddRemark(ApplicationDbContext context, ILogger logger)
		{
			_context = context;
			_logger = logger;
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
			_logger.LogInformation($"A manager/admin has added a remark '{request.Remark}' on the video {request.VideoId}");
			return new Response
			{
				Result = result,
			};
		}
	}
}
