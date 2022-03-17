using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Forum.Pages.SignIn
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public LogoutModel(SignInManager<IdentityUser> signInManager)
        {
            this._signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToPage("Login");
        }

        public IActionResult OnPostNoLogoutAsync()
        {
            return RedirectToPage("/Index");
        }
    }
}
