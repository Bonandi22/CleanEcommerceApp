using Domain.Entities;
using Domain.Intefaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CartItem>> GetByUserIdAsync(int userId)
        {
            return await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Product)
                .ToListAsync();
        }

        public async Task ClearCartAsync(int userId)
        {
            var cartItems = _context.CartItems.Where(ci => ci.UserId == userId);
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }
    }
}