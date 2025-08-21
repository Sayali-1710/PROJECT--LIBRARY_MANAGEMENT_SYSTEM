using static PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models.Enums;

namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.DTOs
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public string Genre { get; set; }

        public string ISBN { get; set; }

        public int PublicationYear { get; set; }

        public  BookStatus  Status { get; set; }
    }
}
