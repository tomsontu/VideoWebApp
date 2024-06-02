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

        public AddComment(ApplicationDbContext context)
        {
            _context = context;
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
