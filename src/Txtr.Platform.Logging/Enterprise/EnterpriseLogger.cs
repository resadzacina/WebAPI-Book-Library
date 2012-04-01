using System;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Txtr.Platform.Logging.Enterprise
{
    internal class EnterpriseLogger : ILog
    {
        readonly LogWriter logWriter;
        readonly LogEntryCreator logEntryCreator;
        
        public EnterpriseLogger( LogWriter logWriter, LogEntryCreator logEntryCreator )
        {
            this.logWriter = logWriter;
            this.logEntryCreator = logEntryCreator;
        }

        public LogLevel LogLevel { get; set; }

        public void Close() { }

        public bool DebugEnabled { get; private set; }

        public void Debug( string message )
        {            
            Write( TraceEventType.Verbose, message );
        }

        public void Debug( string message, params object[] args )
        {
            Write( TraceEventType.Verbose, message, args );
        }

        public bool InfoEnabled { get; private set; }

        public void Info( string message )
        {
            Write( TraceEventType.Information, message );
        }

        public void Info( string message, params object[] args )
        {
            Write( TraceEventType.Information, message, args );
        }

        public bool WarnEnabled { get; private set; }

        public void Warn( string message )
        {
            Write( TraceEventType.Warning, message );
        }

        public void Warn( string message, params object[] args )
        {
            Write( TraceEventType.Warning, message, args );
        }

        public void Exception( string message )
        {
            Write( TraceEventType.Error, message );
        }

        public void Exception( Exception exception )
        {
            Write( TraceEventType.Error, FormatException( exception, string.Empty ) );
        }

        public void Exception( Exception exception, string message )
        {
            Write( TraceEventType.Error, FormatException( exception, message ) );
        }

        public void Exception( string message, params object[] args )
        {
            Write( TraceEventType.Error, message, args );
        }

        public void Exception( Exception exception, string message, params object[] args )
        {
            Write( TraceEventType.Error, FormatException( exception, string.Format( message, args ) ) );
        }

        string FormatException( Exception exception, string message  )
        {
            string exceptionMessage = string.Format( "Exception [{0}] \\n Message[{1}] \\n Source[{2}] \\n StackTrace[{3}]",
                        exception.GetType().ToString(),
                        exception.Message, exception.Source, exception.StackTrace );

            if ( exception.InnerException != null )
                exceptionMessage = string.Concat( exceptionMessage, string.Format( "\\n Inner Exception Message[{0}]", exception.InnerException.Message ) );

            if ( !string.IsNullOrEmpty( message ) )
                exceptionMessage = string.Concat( message, " - ", exceptionMessage );

            return exceptionMessage;
        }

        //*********************************************
        // Obsolete
        //*********************************************
        public void Error( string message )
        {
            Warn( message );
        }

        public void Error( string message, params object[] args )
        {
            Warn( message, args );
        }

        public void Critical( string message )
        {
            Exception( message );
        }

        public void Critical( string message, Exception exception )
        {
            Exception( exception, message );
        }

        public void Critical( string message, params object[] args )
        {
            Exception( message, args );
        }

        void Write( TraceEventType logLevel, string message )
        {
            this.logWriter.Write( this.logEntryCreator.Create( logLevel, message ) );
        }

        void Write( TraceEventType logLevel, string message, params object[] args )
        {
            this.logWriter.Write( this.logEntryCreator.Create( logLevel, message, args ) );
        }
    }
}
