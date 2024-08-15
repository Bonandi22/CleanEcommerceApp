using Application.DTOs;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> AuthenticateAsync(string email, string password);

        Task RegisterUserAsync(UserDto userDto);

        Task<UserDto> GetUserByIdAsync(int userId);
    }
}