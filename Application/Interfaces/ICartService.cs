using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICartService
    {
        Task AddToCartAsync(CartItemDto cartItem);

        Task RemoveFromCartAsync(int cartItemId);

        Task<IEnumerable<CartItemDto>> GetCartItemsAsync(int userId);

        Task ClearCartAsync(int userId);
    }
}