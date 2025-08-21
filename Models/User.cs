namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = " ";
        public string Email { get; set; } = "  ";
        public string Password { get; set; } = "  ";
        public string Role { get; set; } = "Member";  
        public DateTime MembershipDate { get; set; } = DateTime.Now;
        public ICollection<Transaction> Transactions { get; set; }
    }
}
