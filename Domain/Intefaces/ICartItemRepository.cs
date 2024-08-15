using Domain.Entities;

namespace Domain.Intefaces
{
    public interface ICartItemRepository : IBaseRepository<CartItem>
    {
        Task<IEnumerable<CartItem>> GetByUserIdAsync(int userId);

        Task ClearCartAsync(int userId);
    }
}