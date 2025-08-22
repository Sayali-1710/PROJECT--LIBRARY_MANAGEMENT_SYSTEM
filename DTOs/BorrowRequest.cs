namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.DTOs
{
    public class BorrowRequest
    {
        public int UserId { get; set; }
        public int BorrowId { get; set; }
        public object?[]? BookId { get; internal set; }

    }
}
