using System;
using Txtr.Platform.Data.Core.Configuration;

namespace Txtr.Platform.Data.Core.Dependency
{
    public class DependencyResolverFactory : IDependencyResolverFactory
    {
        private readonly Type resolverType;

        public DependencyResolverFactory( string resolverTypeName )
        {
            Check.Require( !String.IsNullOrEmpty( resolverTypeName ), "resolverTypeName cannot be empty" );

            resolverType = Type.GetType( resolverTypeName, true, true );
        }

        public DependencyResolverFactory()
            : this( new ConfigurationManagerWrapper().AppSettings[ "dependencyResolverTypeName" ] )
        {
        }

        public IDependencyResolver CreateInstance()
        {
            return Activator.CreateInstance( resolverType ) as IDependencyResolver;
        }
    }
}