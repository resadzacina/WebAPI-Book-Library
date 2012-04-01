namespace Txtr.Platform.Data.Core.Dependency
{
    public interface IDependencyResolverFactory
    {
        IDependencyResolver CreateInstance();
    }
}