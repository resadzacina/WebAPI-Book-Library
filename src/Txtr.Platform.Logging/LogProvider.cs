using System;
using Txtr.Platform.Logging.Queues;
using Txtr.Platform.Logging.Writers;
using Txtr.Platform.Logging.Enterprise;
using Txtr.Platform.Logging.Formatters;

namespace Txtr.Platform.Logging
{
    public static class LogProvider
    {
        public static ILog GetLog( string nameSpace, LogLevel logLevel, string path, string fileName )
        {
            IQueue queue = new LogQueue( new FileWriter( path, fileName, new TextFormatter() ) );
            return new Logger( logLevel, queue, nameSpace );
        }

        public static ILog GetLog( string source )
        {
            return EnterpriseLoggerFactory.Get( source );
        }

        public static ILog GetLog( string nameSpace, string logLevel, string path, string fileName )
        {
            var level = LogLevel.Info;
            if ( !string.IsNullOrEmpty( logLevel ) )
            {
                try
                {
                    level = ( LogLevel )Enum.Parse( typeof( LogLevel ), logLevel );
                }
                catch { }
            }

            return GetLog( nameSpace, level, path, fileName );
        }

        public static ILog GetNullLog()
        {
            return new Logger( LogLevel.All, new LogQueue( new NullWriter() ), "NullWriter.Testing" );
        }
    }
}
