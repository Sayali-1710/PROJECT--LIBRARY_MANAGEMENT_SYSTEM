﻿using System.Transactions;

namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models
{
    public class Book
    {

        public int BookId { get; set; }  
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; } 
        public BookStatus Status { get; set; } = BookStatus.Available;
        

    }
}
