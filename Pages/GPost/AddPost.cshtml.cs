using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Forum.Pages.GPost
{
    [BindProperties]
    public class AddPostModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Post Posts { get; set; }

        public AddPostModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            
        }
    }
}
