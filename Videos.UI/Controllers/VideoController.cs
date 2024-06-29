using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
		private readonly ILogger _logger;
		private readonly ElasticSearchDb _elasticsearchDb;

		public VideoController(ApplicationDbContext context, RedisDb redisDb, ILogger<AccountController> logger, ElasticSearchDb elasticSearchDb)
		{
			_context = context;
			_redisDb = redisDb;
			_logger = logger;
			_elasticsearchDb = elasticSearchDb;
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
			return Ok(await new AddRemark(_context, _logger).Do(request));
		}

		[Authorize(Policy = "Manager")]
		[HttpDelete("videos/{videoId}")]
		public async Task<IActionResult> DeleteVideoAsync(string videoId)
		{
			return Ok(await new DeleteVideo(_context, _redisDb, _logger).Do(videoId));
		}

		[HttpGet("videos/{videoId}")]
		public IActionResult GetVideo(string videoId)
		{
			_logger.LogInformation($"video {videoId} has been viewed by a user");
			return View("~/Pages/VideoDetail.cshtml", new GetVideo(_context).Do(videoId));
		}

		[HttpPost("videos/addComment")]
		public async Task<IActionResult> AddComment([FromBody] AddComment.Request request)
		{
			return Ok(await new AddComment(_context, _logger, _elasticsearchDb).Do(request));
		}
	}
}
