using System.Linq;
using Txtr.Platform.Data.DomainModel.Model;

namespace Txtr.Platform.Data.DomainModel.Repository
{
    public interface IBooksRepository
    {
        IQueryable<Book> FindAll();

        Book FindByID( int id );

        Book FindByISBN( string ISBN );

        void Add( Book book );

        void Update( Book book );

        void Delete( int id );
    }
}
