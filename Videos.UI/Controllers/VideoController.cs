using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Videos.Application.Video;
using Videos.Database;

namespace Videos.UI.Controllers
{
	[Route("[controller]")]
	public class VideoController : Controller
	{
		private readonly ApplicationDbContext _context;
        private readonly RedisDb _redisDb;

        public VideoController(ApplicationDbContext context, RedisDb redisDb)
		{
			_context = context;
			_redisDb = redisDb;
		}

		[HttpGet("videos")]
		public IActionResult GetVideos()
		{
			return Ok(new GetVideos(_context).Do());
		}

		[Authorize(Policy = "Manager")]
		[HttpPut("videos")]
		public async Task<IActionResult> AddRemark([FromBody] AddRemark.Request request)
		{
			return Ok(await new AddRemark(_context).Do(request));
		}

		[Authorize(Policy = "Manager")]
		[HttpDelete("videos/{videoId}")]
		public async Task<IActionResult> DeleteVideoAsync(string videoId)
		{
			return Ok(await new DeleteVideo(_context, _redisDb).Do(videoId));
		}

		[HttpGet("videos/{videoId}")]
		public IActionResult GetVideo(string videoId)
		{
			return View("~/Pages/VideoDetail.cshtml", new GetVideo(_context).Do(videoId));
		}
	}
}
