using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public DateTime CommentTime { get; set; }
        public string AttchmentUrl { get; set; }
        public int UserId { get; set; }
        public Account Account { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
