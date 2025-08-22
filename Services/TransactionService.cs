using Microsoft.EntityFrameworkCore;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.DTOs;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Repository;

namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Services
{
    public class TransactionService:ITransactionService
    {
        private readonly LibraryContext _context;
        private readonly IGenericRepository<Transaction> _tranRepo;
        private const decimal FinePerDay = 5m;
        private const int BorrowDays = 14;
        public TransactionService(LibraryContext context, IGenericRepository<Transaction> tranRepo)
        {
            _context = context;
            _tranRepo = tranRepo;
        }
        public async Task BorrowAsync(BorrowRequest request)
        {
            var book = await _context.Books.FindAsync(request.BookId);
            if (book==null || book.Status!=Enums.BookStatus.Available) 
                throw new Exception("Book is not available");

            var user = await _context.Users.FindAsync(request.UserId);
            if (user==null) 
                throw new Exception("User not found");

            var txn = new Transaction
            {
                BookId=book.BookId,
                UserId=user.UserId,
                BorrowDate=DateTime.Now,
                FineAmount=0
            };

            book.Status=Enums.BookStatus.CheckedOut;
            await _tranRepo.AddAsync(txn);
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task ReturnAsync(ReturnRequest request)
        {
            var txn = await _context.Transactions.Where(t => t.BookId==request.BookId && t.UserId==request.UserId &&
            t.ReturnDate==null).OrderByDescending(t => t.BorrowDate).FirstOrDefaultAsync();

            if (txn==null)
                throw new Exception("Active transaction not found");

            txn.ReturnDate=DateTime.Now;

            var dueDate = txn.BorrowDate.AddDays(BorrowDays);

            if (txn.ReturnDate>dueDate)
            {
                var overdueDays = (txn.ReturnDate.Value.Date-dueDate.Date).Days;
                txn.FineAmount=overdueDays * FinePerDay;
            }

            var book = await _context.Books.FindAsync(request.BookId);
            book.Status=Enums.BookStatus.Available;

            _context.Transactions.Update(txn);
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
