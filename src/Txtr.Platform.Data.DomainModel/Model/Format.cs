using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Txtr.Platform.Data.DomainModel.Model
{
    public class Format
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Book> Books { get; set; }
    }
}
