using Domain.Entities;
using Domain.Intefaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetByemailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email)
                .ConfigureAwait(false);
        }

        public async Task<User> GetByIdWithRoleAsync(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("User ID must be greater than zero", nameof(userId));

            return await _context.Users
                .AsNoTracking()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == userId)
                .ConfigureAwait(false);
        }
    }
}