using System;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;


namespace Txtr.Platform.Logging.Enterprise
{
    internal static class EnterpriseLoggerFactory
    {
        static LogWriter writer = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();

        public static ILog Get( string source )
        {            
            LogEntryCreator creator;
            if ( GetCategory( source ) )
                creator = new CategoryLogEntryCreator( source );
            else
                creator = new DefaultLogEntryCreator( source );

            return new EnterpriseLogger( writer, creator );
        }

        static bool GetCategory( string category )
        {
            foreach ( var entry in writer.TraceSources )
            {
                if ( entry.Key.Equals( category, StringComparison.CurrentCultureIgnoreCase ) )
                    return true;
            }

            return false;
        }
    }
}
