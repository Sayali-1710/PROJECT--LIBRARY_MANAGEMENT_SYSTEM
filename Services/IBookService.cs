using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models;

namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }
}
