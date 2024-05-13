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

		public VideoController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("videos")]
		public IActionResult GetVideos()
		{
			return Ok(new GetVideos(_context).Do());
		}

		[HttpDelete("videos/{videoId}")]
		public async Task<IActionResult> DeleteVideoAsync(string videoId)
		{
			return Ok(await new DeleteVideo(_context).Do(videoId));
		}

		[HttpGet("videos/{videoId}")]
		public IActionResult GetVideo(string videoId)
		{
			return View("~/Pages/VideoDetail.cshtml", new GetVideo(_context).Do(videoId));
		}
	}
}
