namespace Web.Models
{
    public class RegisterModel
    {
        public string? FullName { get; set; }   // Nome completo do usuário
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }    // Endereço do usuário
        public string? PhoneNumber { get; set; } // Telefone do usuário
    }
}