using System;

namespace Txtr.Platform.Logging
{
    public struct LogEntry
    {
        public string Namespace;
        public LogLevel Level;
        public DateTime Date;
        public string Message;

        public LogEntry( string nameSpace, LogLevel level, string message )
        {
            Namespace = nameSpace;
            Level = level;
            Message = message;
            Date = DateTime.Now;
        }

        public LogEntry( string nameSpace, LogLevel level, string message, params object[] args ) : this( nameSpace, level, string.Format( message, args ) )
        {
        }
    }
}
