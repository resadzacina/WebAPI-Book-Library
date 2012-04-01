using System;
using System.Collections.Generic;

namespace Txtr.Platform.Data.Core.Dependency
{
    public static class IoC
    {
        private static IDependencyResolver resolver;

        public static void InitializeWith( IDependencyResolverFactory factory )
        {
            Check.IsNotNull( factory, "factory" );

            resolver = factory.CreateInstance();
        }

        public static void Register<T>( T instance )
        {
            Check.IsNotNull( instance, "instance" );

            resolver.Register( instance );
        }

        public static void Inject<T>( T existing )
        {
            Check.IsNotNull( existing, "existing" );

            resolver.Inject( existing );
        }

        public static T Resolve<T>( Type type )
        {
            Check.IsNotNull( type, "type" );

            return resolver.Resolve<T>( type );
        }

        public static T Resolve<T>( Type type, string name )
        {
            Check.IsNotNull( type, "type" );
            Check.Require( !String.IsNullOrEmpty( name ), "name" );

            return resolver.Resolve<T>( type, name );
        }

        public static T Resolve<T>()
        {
            return resolver.Resolve<T>();
        }

        public static T Resolve<T>( string name )
        {
            Check.Require( !String.IsNullOrEmpty( name ), "name" );

            return resolver.Resolve<T>( name );
        }

        public static IEnumerable<T> ResolveAll<T>()
        {
            return resolver.ResolveAll<T>();
        }

        public static void Reset()
        {
            if ( resolver != null )
            {
                resolver.Dispose();
            }
        }
    }
}