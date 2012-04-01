namespace Txtr.Platform.Data.Provider.Connection
{
    public interface IBooksDatabaseFactory
    {
        PocoContext Context { get; }
    }
}
