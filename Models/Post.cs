using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Forum.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public int UserId { get; set; }
        public Account Account { get; set; }
        public string Image { get; set; }
    }
}
