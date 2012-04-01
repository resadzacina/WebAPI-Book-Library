using System.Data.Objects;
using Txtr.Platform.Data.DomainModel.Model;

namespace Txtr.Platform.Data.Provider
{
    public class PocoContext : ObjectContext
    {
        private const string CONNECTION_STRING = "name=BooksDatabaseEntities";
        private const string CONTAINER_NAME = "BooksDatabaseEntities";

        public PocoContext()
            : this( CONNECTION_STRING )
        {
        }

        public PocoContext( string connectionString )
            : base( connectionString, CONTAINER_NAME )
        {
        }

        #region ObjectSet Properties
        
        private ObjectSet<Book> books;
        private ObjectSet<Author> authors;
        private ObjectSet<Format> formats;
        private ObjectSet<Genre> genres;
        private ObjectSet<User> users;
        private ObjectSet<Country> countries;

        public virtual ObjectSet<Book> Books
        {
            get { return books ?? ( books = CreateObjectSet<Book>( "Books" ) ); }
        }

        public virtual ObjectSet<Author> Authors
        {
            get { return authors ?? ( authors = CreateObjectSet<Author>( "Authors" ) ); }
        }

        public virtual ObjectSet<Format> Formats
        {
            get { return formats ?? ( formats = CreateObjectSet<Format>( "Formats" ) ); }
        }

        public virtual ObjectSet<Genre> Genres
        {
            get { return genres ?? ( genres = CreateObjectSet<Genre>( "Genres" ) ); }
        }

        public virtual ObjectSet<User> Users
        {
            get { return users ?? ( users = CreateObjectSet<User>( "Users" ) ); }
        }

        public virtual ObjectSet<Country> Countries
        {
            get { return countries ?? ( countries = CreateObjectSet<Country>( "Countries" ) ); }
        }

        #endregion
    }
}
