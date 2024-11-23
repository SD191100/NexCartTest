using NexCart.DTOs.User;
using NexCart.Models;
using NexCart.Repositories.Interfaces;
using NexCart.Services.Interfaces;

namespace NexCart.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponseDto> CreateUserAsync(UserRequestDto userDto)
        {
            // Map DTO to Entity
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password), // Example password hashing
                CreatedAt = DateTime.UtcNow
            };

            // Save user to database
            var createdUser = await _userRepository.CreateUserAsync(user);

            // Map Entity to DTO
            return new UserResponseDto
            {
                Id = createdUser.Id,
                FullName = $"{createdUser.FirstName} {createdUser.LastName}",
                Email = createdUser.Email,
                CreatedAt = createdUser.CreatedAt
            };
        }

        public async Task<UserResponseDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
                throw new KeyNotFoundException("User not found.");

            return new UserResponseDto
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            return users.Select(user => new UserResponseDto
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                CreatedAt = user.CreatedAt
            });
        }
    }
}

