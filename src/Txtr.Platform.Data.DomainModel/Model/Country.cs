using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Txtr.Platform.Data.DomainModel.Model
{
    public class Country
    {
        public string ISO { get; set; }
        public string PrintableName { get; set; }
        public string Name { get; set; }
        public string ISO3 { get; set; }
        public short? NumCode { get; set; }
        public List<User> Users { get; set; }
    }
}
