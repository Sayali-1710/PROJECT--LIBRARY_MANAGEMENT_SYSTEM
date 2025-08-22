using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Repository;

namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Services
{ 
    public class BookService: IBookService
    {
        private readonly IGenericRepository<Book> _repo;
        private readonly LibraryContext _context;
        public BookService(IGenericRepository<Book>repo,LibraryContext context)
        {
            _repo = repo;
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<Book> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task AddAsync (Book book)
        {
            await _repo.AddAsync(book);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book==null)
                throw new Exception("Book not found");
            _repo.Remove(book);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
