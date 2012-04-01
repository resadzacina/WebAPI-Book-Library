using Txtr.Platform.Data.Core;
using Txtr.Platform.Data.Core.Dependency;

namespace Txtr.Platform.Data.Provider.Connection
{
    public class BooksDatabaseFactory : IBooksDatabaseFactory
    {
        readonly string connectionString;

        public BooksDatabaseFactory()
        {
            var resolvedConnectionString = IoC.Resolve<IBooksConnectionString>();

            Check.IsNotNull( resolvedConnectionString, "connectionString" );

            this.connectionString = resolvedConnectionString.Value;
        }

        public virtual PocoContext Context
        {
            get
            {
                return new PocoContext( this.connectionString );
            }
        }
    }
}
