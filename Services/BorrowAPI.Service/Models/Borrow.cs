using System;

namespace BorrowAPI.Service.Models
{
    public class Borrow
    {
        public int id { get; set; }
        public string borrowName { get; set; }
        public string bookId { get; set; }
        public string bookName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime returnDate { get; set; }
  


        
    }
}
