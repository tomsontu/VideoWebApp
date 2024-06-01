using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videos.UI.Pages.Admin
{
    public class ConfigUsersModel : PageModel
    {
		private readonly UserManager<IdentityUser> _userManager;

		public ConfigUsersModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

		public List<UserClaimsViewModel> UsersWithClaims { get; set; } = new List<UserClaimsViewModel>();

		public async Task OnGetAsync()
		{
			var users = _userManager.Users.ToList();
			foreach (var user in users)
			{
				var claims = await _userManager.GetClaimsAsync(user);
				foreach (var claim in claims)
				{
					UsersWithClaims.Add(new UserClaimsViewModel
					{
						UserId = user.Id,
						Username = user.UserName,
						ClaimType = claim.Type,
						ClaimValue = claim.Value
					});
				}
			}
		}

		public async Task<IActionResult> OnPostDeleteAsync(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return NotFound("User not found.");
			}

			var result = await _userManager.DeleteAsync(user);
			if (result.Succeeded)
			{
				return RedirectToPage();
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
				return Page();
			}
		}
	}
	public class UserClaimsViewModel
	{
		public string UserId { get; set; }
		public string Username { get; set; }
		public string ClaimType { get; set; }
		public string ClaimValue { get; set; }
	}
}
