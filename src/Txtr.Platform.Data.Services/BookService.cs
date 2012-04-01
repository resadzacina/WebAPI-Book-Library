using System.Collections.Generic;
using System.Linq;
using Txtr.Platform.Data.Core;
using Txtr.Platform.Data.DomainModel.Model;
using Txtr.Platform.Data.DomainModel.Repository;
using Txtr.Platform.Data.DomainModel.Services;

namespace Txtr.Platform.Data.Services
{
    public class BookService : IBookService
    {
        private IBooksRepository repository;

        public BookService( IBooksRepository repository )
        {
            Check.IsNotNull( repository, "IBooksRepository" );
            this.repository = repository;
        }

        public IList<Book> FindAll()
        {
            return repository.FindAll().ToList();
        }

        public Book FindByID( int id )
        {
            return repository.FindByID( id );
        }

        public Book FindByISBN( string ISBN )
        {
            return repository.FindByISBN( ISBN );
        }

        public void Add( Book book )
        {
            repository.Add( book );
        }

        public void Update( Book book )
        {
            repository.Update( book );
        }

        public void Delete( int id )
        {
            repository.Delete( id );
        }
    }
}
