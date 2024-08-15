using Application.DTOs;
using Application.Interfaces;
using Application.Utilities;
using Application.Validations;
using AutoMapper;
using Domain.Entities;
using Domain.Intefaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> AuthenticateAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Email and password are required");
            }

            if (!EmailValidator.IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email format");
            }

            var user = await _userRepository.GetByemailAsync(email);
            if (user == null || !PasswordValidator.IsPasswordValid(password, user.PasswordHash!))
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task RegisterUserAsync(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            if (string.IsNullOrWhiteSpace(userDto.Email) || string.IsNullOrWhiteSpace(userDto.Password))
            {
                throw new ArgumentException("Email and password are required");
            }

            if (!EmailValidator.IsValidEmail(userDto.Email))
            {
                throw new ArgumentException("Invalid email format");
            }

            if (!PasswordValidator.IsPasswordComplexEnough(userDto.Password))
            {
                throw new ArgumentException("Password does not meet complexity requirements");
            }

            var existingUser = await _userRepository.GetByemailAsync(userDto.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User already exists");
            }

            var hashedPassword = PasswordHasher.HashPassword(userDto.Password);
            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = hashedPassword;

            await _userRepository.AddAsync(user);
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdWithRoleAsync(userId);
            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}