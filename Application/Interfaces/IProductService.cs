using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();

        Task<ProductDto> GetProductByIdAsync(int productId);

        Task AddProductAsync(ProductDto product);

        Task UpdateProductAsync(ProductDto product);

        Task DeleteProductAsync(int productId);
    }
}