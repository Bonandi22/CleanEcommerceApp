using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Intefaces;

namespace Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task AddToCartAsync(CartItemDto cartItemDto)
        {
            var cartItem = new CartItem
            {
                ProductId = cartItemDto.ProductId,
                UserId = cartItemDto.UserId,
                Quantity = cartItemDto.Quantity
            };

            await _cartItemRepository.AddAsync(cartItem);
        }

        public async Task RemoveFromCartAsync(int cartItemId)
        {
            await _cartItemRepository.DeleteAsync(cartItemId);
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItemsAsync(int userId)
        {
            var cartItems = await _cartItemRepository.GetByUserIdAsync(userId);
            return cartItems.Select(item => new CartItemDto
            {
                Id = item.Id,
                ProductId = item.ProductId,
                UserId = item.UserId,
                Quantity = item.Quantity
            });
        }

        public async Task ClearCartAsync(int userId)
        {
            await _cartItemRepository.ClearCartAsync(userId);
        }
    }
}