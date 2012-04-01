using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Txtr.Platform.Data.DomainModel.Model
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string FavouriteCategory { get; set; }
        public string FavouriteBook { get; set; }
        public string Occupation { get; set; }
        public string CountryISO { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? LastActivity { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IList<Book> Books { get; set; }
        public Country Country { get; set; }
    }
}
