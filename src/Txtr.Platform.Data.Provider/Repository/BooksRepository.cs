using System;
using System.Data.Objects;
using System.Linq;
using Txtr.Platform.Data.Core.Dependency;
using Txtr.Platform.Data.DomainModel.Model;
using Txtr.Platform.Data.DomainModel.Repository;
using Txtr.Platform.Data.Provider.Connection;
using Txtr.Platform.Logging;

namespace Txtr.Platform.Data.Provider.Repository
{
    public class BooksRepository : IBooksRepository
    {
        readonly IBooksDatabaseFactory databaseFactory;
        readonly ILog log;

        public BooksRepository()
        {
            this.databaseFactory = IoC.Resolve<IBooksDatabaseFactory>();
            this.log = IoC.Resolve<ILog>();
        }

        public IQueryable<Book> FindAll()
        {
            try
            {
                var items = databaseFactory.Context.Books.AsQueryable();

                return items;
            }
            catch ( Exception ex )
            {
                log.Exception( ex, "Exception in BooksRepository.FindAll" );
            }

            return null;
        }

        public Book FindByID( int id )
        {
            try
            {
                var book = databaseFactory.Context.Books.Single( b => b.ID == id );

                return book;
            }
            catch ( Exception ex )
            {
                log.Exception( ex, "Exception in BooksRepository.FindByID" );
            }

            return null;
        }

        public Book FindByISBN( string ISBN )
        {
            try
            {
                var book = databaseFactory.Context.Books.Single( b => b.ISBN == ISBN );

                return book;
            }
            catch ( Exception ex )
            {
                log.Exception( ex, "Exception in BooksRepository.FindByISBN" );
            }

            return null;
        }

        public void Add( Book book )
        {
            using ( var framework = databaseFactory.Context )
            {
                framework.Books.AddObject( book );
                framework.SaveChanges();
            }
        }

        public void Delete( int id )
        {
            using ( var framework = databaseFactory.Context )
            {
                var original = framework.Books.Single( b => b.ID == id );
                framework.Books.DeleteObject( original );
                framework.SaveChanges();
            }
        }

        public void Update( Book book )
        {
            using ( var framework = databaseFactory.Context )
            {
                var original = framework.Books.FirstOrDefault( f => f.ID == book.ID );

                if ( original != null )
                {
                    framework.DetectChanges();
                    framework.Books.ApplyCurrentValues( book );
                    framework.SaveChanges( SaveOptions.AcceptAllChangesAfterSave );

                }
            }
        }
    }
}
