using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Class { get; set; }               
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Position { get; set; }
        public string gender { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string phone { get; set; }
        public DateTime DoB { get; set; }
        public bool RememberMe { get; set; }
        [ForeignKey("SchoolId")]
        public int SchoolId { get; set; }
        public School School { get; set; }

    }

}
