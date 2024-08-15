using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 100 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(256, ErrorMessage = "Email cannot be longer than 256 characters.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(256, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 256 characters.")]
        public string? Password { get; set; }

        public string? Address { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(15, ErrorMessage = "Phone number cannot be longer than 15 characters.")]
        public string? PhoneNumber { get; set; }

        public UserRole Role { get; set; } = UserRole.Customer; // Default role is "Customer"
    }
}