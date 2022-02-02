using System.ComponentModel.DataAnnotations;

namespace BookStoreWebAPI.Models
{
    public class SignUp
    {
        [Required]
        public string FirstName { get; set;}
        [Required]
        public string LastName { get; set;}
        [Required]
        [EmailAddress]
        public string Email { get; set;}
        [Required]
        [Compare("confirmPassword")]
        public string password { get; set; }
        [Required]
        public string confirmPassword { get; set; }
    }
}