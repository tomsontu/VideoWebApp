using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

		public AddComment(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<object> Do(Request request)
        {
            var review = new Review
            {
                VideoId = request.VideoId,
                VideoReview = request.Comment,
            };
            _context.Reviews.Add(review);
            var result = await _context.SaveChangesAsync() > 0;
            _logger.LogInformation($"A user has posted a comment '{request.Comment}' on the video {request.VideoId}");
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
	}
}
