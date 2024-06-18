using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Videos.UI.Pages.Accounts
{
    public class LoginModel : PageModel
    {
		private SignInManager<IdentityUser> _signInManager;
		private readonly ILogger<LoginModel> _logger;

		public LoginModel(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger)
		{
			_signInManager = signInManager;
			_logger = logger;
		}

		[BindProperty]
		public LoginViewModel Input { get; set; }

		public void OnGet()
		{

		}

		public async Task<IActionResult> OnPost()
		{
			var result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, false, false);
			if (result.Succeeded)
			{
				_logger.LogInformation($"User {Input.Username} has logged in");
				return RedirectToPage("/Admin/Index");
			}
			else
			{
				_logger.LogInformation($"User {Input.Username} login failed: wrong password");
				return Page();
			}
		}

	}

	public class LoginViewModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
