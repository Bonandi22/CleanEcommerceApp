using Domain.Entities;

namespace Domain.Intefaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        // Adicione métodos específicos para produtos, se necessário
    }
}