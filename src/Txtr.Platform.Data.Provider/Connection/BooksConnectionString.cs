using System;
using Txtr.Platform.Data.Core;
using Txtr.Platform.Data.Core.Configuration;
using Txtr.Platform.Data.Core.Dependency;

namespace Txtr.Platform.Data.Provider.Connection
{
    public class BooksConnectionString : IBooksConnectionString
    {
        readonly string value;

        public BooksConnectionString( string name )
        {
            var resolvedConf = IoC.Resolve<IConfigurationManager>();

            Check.IsNotNull( resolvedConf, "configuration" );
            Check.Require( !String.IsNullOrEmpty( name ), "name" );

            this.value = resolvedConf.ConnectionStrings( name );
        }

        public string Value { get { return this.value; } }
    }
}
