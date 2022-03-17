using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels
{
    public class Register
    {
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation password did not match.")]
        public string ConfirmPassword { get; set; }
        public string Position { get; set; }
        [Display(Name ="School Id")]
        public int SchoolId { get; set; }
    }
}
