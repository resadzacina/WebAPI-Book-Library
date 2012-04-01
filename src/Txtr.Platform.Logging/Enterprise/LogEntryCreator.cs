using System;
using System.Diagnostics;
using ent = Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Txtr.Platform.Logging.Enterprise
{
    internal abstract class LogEntryCreator
    {
        public string Source { get; set; }

        public LogEntryCreator( string source )
        {
            this.Source = source;
        }

        public abstract ent.LogEntry Create( TraceEventType logLevel, string message );

        public virtual ent.LogEntry Create( TraceEventType logLevel, string message, params object[] args )
        {
            return Create( logLevel, string.Format( message, args ) );
        }
    }

    internal class DefaultLogEntryCreator : LogEntryCreator
    {
        public DefaultLogEntryCreator( string source ) : base( source ) { }

        public override ent.LogEntry Create( TraceEventType logLevel, string message )
        {
            var log = new ent.LogEntry()
            {
                Message = message,
                Title = this.Source,
                Severity = logLevel
            };    

            return log;
        }
    }

    internal class CategoryLogEntryCreator : LogEntryCreator
    {
        public CategoryLogEntryCreator( string source ) : base( source ) { }

        public override ent.LogEntry Create( TraceEventType logLevel, string message )
        {
            var log = new ent.LogEntry()
            {
                Message = message,
                Title = this.Source,
                Severity = logLevel
            };
            log.Categories.Add( this.Source );

            return log;
        }
    }
}
