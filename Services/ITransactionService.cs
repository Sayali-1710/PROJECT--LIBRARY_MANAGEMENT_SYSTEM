using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.DTOs;

namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Services
{
    public interface ITransactionService
    {
        Task BorrowAsync(BorrowRequest request);
        Task ReturnAsync(ReturnRequest request);
    }
}
