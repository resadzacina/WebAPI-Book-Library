using System;
using Txtr.Platform.Logging.Queues;

namespace Txtr.Platform.Logging
{
    internal class Logger : ILog
    {
        readonly IQueue messageQueue;
        readonly string nameSpace;
        LogLevel logLevel;

        internal Logger( LogLevel logLevel, IQueue messageQueue, string nameSpace )
        {
            this.messageQueue = messageQueue;
            this.nameSpace = nameSpace;
            LogLevel = logLevel;
        }

        public LogLevel LogLevel 
        {
            get { return this.logLevel; }

            set
            {
                this.logLevel = value;
                this.DebugEnabled = LogLevel.Debug >= this.logLevel;
                this.InfoEnabled = LogLevel.Info >= this.logLevel;
                this.WarnEnabled = LogLevel.Warn >= this.logLevel;
            }
        }

        public void Close()
        {
            this.messageQueue.Close();
        }

        public bool DebugEnabled { get; private set; }

        public void Debug( string message )
        {
            if ( DebugEnabled ) Write( LogLevel.Debug, message );
        }

        public void Debug( string message, params object[] args )
        {
            if ( DebugEnabled ) Write( LogLevel.Debug, message, args );
        }

        public bool InfoEnabled { get; private set; }

        public void Info( string message )
        {
            if ( InfoEnabled ) Write( LogLevel.Info, message );
        }

        public void Info( string message, params object[] args )
        {
            if ( InfoEnabled ) Write( LogLevel.Info, message, args );
        }

        public bool WarnEnabled { get; private set; }

        public void Warn( string message )
        {
            if ( WarnEnabled ) Write( LogLevel.Warn, message );
        }

        public void Warn( string message, params object[] args )
        {
            if ( WarnEnabled ) Write( LogLevel.Warn, message, args );
        }

        public void Exception( string message )
        {
            Write( LogLevel.Exception, message );
        }

        public void Exception( Exception exception )
        {
            Write( LogLevel.Exception, FormatException( exception, string.Empty ) );
        }

        public void Exception( Exception exception, string message )
        {
            Write( LogLevel.Exception, FormatException( exception, message ) );
        }

        public void Exception( string message, params object[] args )
        {
            Write( LogLevel.Exception, message, args );
        }

        public void Exception( Exception exception, string message, params object[] args )
        {
            Write( LogLevel.Exception, FormatException( exception, string.Format( message, args ) ) );
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

        void Write( LogLevel logLevel, string message )
        {
            this.messageQueue.Enqueue( new LogEntry( this.nameSpace, logLevel, message ) );
        }

        void Write( LogLevel logLevel, string message, params object[] args )
        {
            this.messageQueue.Enqueue( new LogEntry( this.nameSpace, logLevel, message, args ) );
        }
    }
}
