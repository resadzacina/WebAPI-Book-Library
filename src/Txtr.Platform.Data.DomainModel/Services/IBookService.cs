using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Txtr.Platform.Data.DomainModel.Model;

namespace Txtr.Platform.Data.DomainModel.Services
{
    public interface IBookService
    {
        IList<Book> FindAll();

        Book FindByID( int id );

        Book FindByISBN( string ISBN );

        void Add( Book book );

        void Update( Book book );

        void Delete( int id );
    }
}
