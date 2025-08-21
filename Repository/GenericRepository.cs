using Microsoft.EntityFrameworkCore;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models;

namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly LibraryContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(LibraryContext context)
        {
            _context=context;
            _dbSet=context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task AddAsync( T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void Update(T entity) => _dbSet.Update(entity);
        public void Remove(T entity) => _dbSet.Remove(entity);

    }

}