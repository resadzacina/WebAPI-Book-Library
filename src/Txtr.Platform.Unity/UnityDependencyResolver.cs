using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Txtr.Platform.Data.Core;
using Txtr.Platform.Data.Core.Dependency;

namespace Txtr.Platform.Unity
{
    public class UnityDependencyResolver : DisposableResource, IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public UnityDependencyResolver() : this(new UnityContainer())
        {
            UnityConfigurationSection configuration = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            configuration.Containers.Default.Configure(_container);
        }

        
        public UnityDependencyResolver(IUnityContainer container)
        {
            Check.IsNotNull(container, "container");

            _container = container;
        }

        
        public void Register<T>(T instance)
        {
            Check.IsNotNull(instance, "instance");

            _container.RegisterInstance(instance);
        }

        
        public void Inject<T>(T existing)
        {
            Check.IsNotNull(existing, "existing");

            _container.BuildUp(existing);
        }

        
        public T Resolve<T>(Type type)
        {
            Check.IsNotNull(type, "type");

            return (T) _container.Resolve(type);
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303")]
        public T Resolve<T>(Type type, string name)
        {
            Check.IsNotNull(type, "type");
            Check.Require( !String.IsNullOrEmpty(name ), "name") ;

            return (T) _container.Resolve(type, name);
        }

        
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303")]
        public T Resolve<T>(string name)
        {
            Check.Require( !String.IsNullOrEmpty( name ), "name" );

            return _container.Resolve<T>(name);
        }

        
        public IEnumerable<T> ResolveAll<T>()
        {
            IEnumerable<T> namedInstances = _container.ResolveAll<T>();
            T unnamedInstance = default(T);

            try
            {
                unnamedInstance = _container.Resolve<T>();
            }
            catch (ResolutionFailedException)
            {
                //When default instance is missing
            }

            if (Equals(unnamedInstance, default(T)))
            {
                return namedInstances;
            }

            return new ReadOnlyCollection<T>(new List<T>(namedInstances) { unnamedInstance });
        }

        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                _container.Dispose();
            }

            base.Dispose( disposing );
        }
    }
}