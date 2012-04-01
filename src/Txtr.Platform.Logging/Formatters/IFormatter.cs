namespace Txtr.Platform.Logging.Formatters
{
    public interface IFormatter
    {
        string Header { get; }
        string Format( LogEntry logEntry );
        string Footer { get; }
        string FileExtension { get; }
    }
}
