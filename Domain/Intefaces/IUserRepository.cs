using Domain.Entities;

namespace Domain.Intefaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByemailAsync(string email);

        Task<User> GetByIdWithRoleAsync(int userId);
    }
}