using System.ComponentModel.DataAnnotations;

namespace WebApplication2.API.Entities.Users
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The username cannot be shorter than 6 characters")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "The password cannot be shorter than  8 characters")]
        public string Password { get; set; }
    }
}
