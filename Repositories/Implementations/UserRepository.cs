using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NexCart.Models;
using NexCart.Repositories.Interfaces;

namespace NexCart.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly NexCartDBContext _context;

        public UserRepository(NexCartDBContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id) => await _context.Users.FindAsync(id);

        public async Task<User> GetUserByUsernameAsync(string username) => await _context.Users.FirstOrDefaultAsync(u => u.Email == username);

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync() => await _context.Users.ToListAsync();

        public async Task DeactivateUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsActive = false; // Assuming IsActive exists
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}

