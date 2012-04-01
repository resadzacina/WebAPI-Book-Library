namespace Txtr.Platform.Logging.Formatters
{
    public class XmlFormatter : IFormatter
    {
        public string Header { get { return "<Log>"; } }

        public string Format( LogEntry logEntry )
        {
            return string.Format( "<LogEntry Namespace='{0}' Date='{1}' LogLevel='{2}'><![CDATA[{3}]]></LogEntry>",
                                                                logEntry.Namespace, logEntry.Date, logEntry.Level, logEntry.Message );
        }

        public string Footer { get { return "</Log>"; } }

        public string FileExtension
        {
            get { return ".xml"; }
        }
    }
}
