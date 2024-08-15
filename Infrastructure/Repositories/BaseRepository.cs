using Domain.Intefaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                .FindAsync(id)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<T>().AddAsync(entity).ConfigureAwait(false);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<T>().Update(entity);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await SaveChangesAsync().ConfigureAwait(false);
            }
        }

        private async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log and handle concurrency exceptions
                throw new Exception("A concurrency error occurred while saving changes.", ex);
            }
            catch (Exception ex)
            {
                // Log and handle other exceptions
                throw new Exception("An error occurred while saving changes.", ex);
            }
        }
    }
}