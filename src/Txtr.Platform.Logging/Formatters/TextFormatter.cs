namespace Txtr.Platform.Logging.Formatters
{
    public class TextFormatter : IFormatter
    {
        public string Header { get { return string.Empty; } }

        public string Format( LogEntry logEntry )
        {
            return string.Format( "[{0}][{1}] {2}: {3}", logEntry.Level, logEntry.Namespace, logEntry.Date, logEntry.Message );
        }

        public string Footer { get { return string.Empty; } }

        public string FileExtension
        {
            get { return ".txt"; }
        }
    }
}
