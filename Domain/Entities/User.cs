using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string? FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string? Email { get; set; } = string.Empty;

        [Required]
        [StringLength(256)]
        public string? PasswordHash { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Address { get; set; }

        [Phone]
        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        [Required]
        public UserRole Role { get; set; } = UserRole.Customer;

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        // Construtor padrão
        public User()
        {
        }

        // Construtor com parâmetros para inicialização rápida
        public User(string fullName, string email, string passwordHash, UserRole role = UserRole.Customer)
        {
            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
        }

        // Adicione métodos de domínio se necessário
    }
}