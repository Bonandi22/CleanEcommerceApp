namespace Application.Validations
{
    public static class PasswordValidator
    {
        public static bool IsPasswordValid(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

        public static bool IsPasswordComplexEnough(string password)
        {
            // Implementar lógica para validar complexidade da senha
            return password.Length >= 8; // Exemplo simples
        }
    }
}