using Microsoft.EntityFrameworkCore;

namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
            
        protected override void 
        OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .Property(t => t.FineAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<User>().HasIndex(u=>u.Email).IsUnique();
        }


    }
}




    
    

