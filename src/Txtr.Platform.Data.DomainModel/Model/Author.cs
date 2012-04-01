using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Txtr.Platform.Data.DomainModel.Model
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryISO { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
