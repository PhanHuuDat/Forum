using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Pages.Main
{
    [Authorize]
    [BindProperties]
    public class HomeModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public Account Account { get; set; }
        public List<Account> Accounts { get; set; }
        public Post Post { get; set; }
        public List<Post> Posts { get; set; }
        public Comment Comment { get; set; }
        public List<Comment> Comments { get; set; }
        public int aPostId { get; set; }

        public HomeModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            Posts = _applicationDbContext.Post.ToList();
            Comments = _applicationDbContext.Comment.ToList();
            Accounts = _applicationDbContext.Account.ToList(); 
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPostNewPost()
        {
            Account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("user"));
            Post.Likes = 0;
            Post.Views = 0;
            Post.PostTime = DateTime.Now;
            Post.UserId = Account.Id;
            _applicationDbContext.Post.Add(Post);
            _applicationDbContext.SaveChanges();
            return RedirectToPage("/Main/Home");
        }

        public IActionResult OnPostNewComment(int aPostId)
        {
            Account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("user"));
            Comment.PostId = aPostId;
            Comment.UserId = Account.Id;
            Comment.CommentTime = DateTime.Now;
            _applicationDbContext.Comment.Add(Comment);
            _applicationDbContext.SaveChanges();

            return RedirectToPage("/Main/Home");
        }

    }
}