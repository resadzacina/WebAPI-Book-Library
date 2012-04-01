using System;
using Txtr.Platform.Data.Core.Dependency;
using Txtr.Platform.Data.Core.Extension;

namespace Txtr.Platform.Data.Core.Bootstrapper
{
    public static class Bootstrapper
    {
        static Bootstrapper()
        {
            try
            {
                IoC.InitializeWith(new DependencyResolverFactory());
            }
            catch (ArgumentException)
            {
                // Config file is Missing
            }
        }

        public static void Run()
        {
            IoC.ResolveAll<IBootstrapperTask>().ForEach(t => t.Execute());
        }
    }
}