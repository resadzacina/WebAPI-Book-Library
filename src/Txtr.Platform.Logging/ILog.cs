using System;

namespace Txtr.Platform.Logging
{
    public interface ILog
    {
        LogLevel LogLevel { get; set; }

        void Close();

        void Debug( string message );

        void Debug( string message, params object[] args );

        bool DebugEnabled { get; }

        bool InfoEnabled { get; }

        void Info( string message );

        void Info( string message, params object[] args );
        
        bool WarnEnabled { get; }

        void Warn( string message );

        void Warn( string message, params object[] args );

        void Exception( string message );

        void Exception( Exception exception );

        void Exception( Exception exception, string message );

        void Exception( string message, params object[] args );

        void Exception( Exception exception, string message, params object[] args );

        [Obsolete( "Use the Warn or Exception method.", false )]
        void Error( string message );

        [Obsolete( "Use the Warn or Exception method.", false )]
        void Error( string message, params object[] args );

        [Obsolete( "Use the Exception method.", false )]
        void Critical( string message );

        [Obsolete( "Use the Exception method.", false )]
        void Critical( string message, Exception exception );

        [Obsolete( "Use the Exception method.", false )]
        void Critical( string message, params object[] args );
    }
}
