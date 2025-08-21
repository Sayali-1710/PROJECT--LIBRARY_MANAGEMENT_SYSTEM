namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);  
        void Update(T entity);
        void Remove(T entity);
    }

}
