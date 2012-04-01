using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Txtr.Platform.Data.DomainModel.Model
{
    public class Book
    {
        public int ID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public string Publisher { get; set; }
        public int? Pages { get; set; }
        public int Year { get; set; }
        public int? GenreID { get; set; }
        public int? FormatID { get; set; }
        public DateTime? BorrowedDate { get; set; }
        public int? BorrowerID { get; set; }
        public string Extra { get; set; }
        public Format Format { get; set; }
        public Genre Genre { get; set; }
        public User User { get; set; }
    }
}
