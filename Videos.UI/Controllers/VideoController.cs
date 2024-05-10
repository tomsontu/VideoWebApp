using Microsoft.AspNetCore.Mvc;
using Videos.Application.Video;
using Videos.Domain;

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
	}
}
