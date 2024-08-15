using Domain.Entities;
using Domain.Intefaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        // Adicione métodos específicos para produtos, se necessário
    }
}