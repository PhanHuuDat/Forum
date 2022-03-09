using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string gender { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string phone { get; set; }
        public DateTime DoB { get; set; }

    }

}
