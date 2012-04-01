using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Txtr.Platform.Data.DomainModel.Model
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public IList<Book> Books { get; set; }
    }
}
