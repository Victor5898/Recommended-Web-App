using System.ComponentModel.DataAnnotations;

namespace WebApplication2.API.Entities.Users
{
    public class AuthDTO
    {
        [Required]
        public string Credential { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
