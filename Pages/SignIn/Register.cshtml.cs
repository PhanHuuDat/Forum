using Forum.Data;
using Forum.Models;
using Forum.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Pages.SignIn
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _applicationDbContext;

        [BindProperty]
        public Register Account { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext applicationDbContext)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._applicationDbContext = applicationDbContext;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {             
                var user = new IdentityUser()
                {
                    UserName = Account.Username,
                    Email = Account.Email
                };
                var result = await _userManager.CreateAsync(user, Account.Password);
                if (result.Succeeded)
                {
                    Account newAcc = new Account()
                    {
                        Username = Account.Username,
                        Email = Account.Email,
                        Position = Account.Position,
                        Password = Account.Password,
                        ConfirmPassword = Account.ConfirmPassword,
                        SchoolId = Account.SchoolId,

                };
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _applicationDbContext.Add(newAcc);
                    _applicationDbContext.SaveChanges();
                    return RedirectToPage("/Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }
    }
}
