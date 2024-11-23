using System.Collections.Generic;
using System.Threading.Tasks;
using NexCart.Models;

namespace NexCart.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task DeactivateUserAsync(int id);
        Task DeleteUserAsync(int id);
    }
}

