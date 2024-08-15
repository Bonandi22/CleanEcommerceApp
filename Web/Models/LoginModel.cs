using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(8)]
        public string? Password { get; set; }
    }
}