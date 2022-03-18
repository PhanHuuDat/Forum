using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Pages.Main
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        [BindProperty]
        public Account Account { get; set; }
        [BindProperty]
        public string schoolName { get; set; }
        public ProfileModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void OnGet()
        {
            Account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("user"));
            Account.School = _applicationDbContext.School.FirstOrDefault(u => u.Id == Account.SchoolId);
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Account newUpdate = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("user"));
            newUpdate.Id = Account.Id;
            newUpdate.Address = Account.Address;
            newUpdate.Username = Account.Username;
            newUpdate.DoB = Account.DoB;
            newUpdate.SchoolId = Account.SchoolId;
            newUpdate.Class = Account.Class;
            newUpdate.phone = Account.phone;
            newUpdate.gender = Account.gender;
            _applicationDbContext.Account.Update(newUpdate);
            await _applicationDbContext.SaveChangesAsync();
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("user", JsonConvert.SerializeObject(newUpdate));
            return RedirectToPage("/Main/Profile");
        }
    }
}