using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Videos.Application.Users;

namespace Videos.UI.Controllers
{
	[Route("[controller]")]
	[Authorize(Policy = "Admin")]
	public class UsersController : Controller
	{
		private CreateUser _createUser;
		private readonly ILogger<AccountController> _logger;

		public UsersController(CreateUser createUser, ILogger<AccountController> logger)
		{
			_createUser = createUser;
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser([FromBody] CreateUser.Request request)
		{
			await _createUser.Do(request);
			_logger.LogInformation($"Admin has created a user: {request.UserName}");
			return Ok();
		}
	}
}
