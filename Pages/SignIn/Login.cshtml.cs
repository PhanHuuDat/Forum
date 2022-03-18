using Forum.Data;
using Forum.Models;
using Forum.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Pages.SignIn
{

    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _applicationDbContext;
        [BindProperty]
        public Account Account { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager, ApplicationDbContext applicationDbContext)
        {
            _signInManager = signInManager;
            _applicationDbContext = applicationDbContext;
        }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl= null)
        {
            
            if (ModelState.IsValid)
            {
                
                var identityResult = await _signInManager.PasswordSignInAsync(Account.Email, Account.Password, Account.RememberMe, false);
                Account = _applicationDbContext.Account.FirstOrDefault(u => u.Email == Account.Email);
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(Account));

                if (identityResult.Succeeded)
                {
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("/Index");
                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }

                }
                ModelState.AddModelError(string.Empty, "Username or Password incorrect");
            }
            return Page();
        }
    }
}
