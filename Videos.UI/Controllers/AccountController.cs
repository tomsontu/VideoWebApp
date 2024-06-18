using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Videos.UI.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
		private readonly ILogger<AccountController> _logger;

		public AccountController(SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
			var userName = User.Identity.Name;
			await _signInManager.SignOutAsync();
			// Log which user has logged out
			_logger.LogInformation("User {UserName} has logged out.", userName);
			return RedirectToPage("/Index");
		}
    }
}
