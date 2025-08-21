namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal FineAmount { get; set; }

       
    }
}
