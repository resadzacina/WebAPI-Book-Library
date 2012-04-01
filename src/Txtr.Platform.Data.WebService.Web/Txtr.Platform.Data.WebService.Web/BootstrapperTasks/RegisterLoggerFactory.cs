using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Txtr.Platform.Data.Core.Bootstrapper;
using Txtr.Platform.Data.Core.Configuration;
using Txtr.Platform.Data.Core.Dependency;
using Txtr.Platform.Logging;

namespace Txtr.Platform.Data.WebService.Web.BootstrapperTasks
{
    public class RegisterLoggerFactory : IBootstrapperTask
    {
        IConfigurationManager configurationManager;

        public RegisterLoggerFactory( IConfigurationManager configurationManager )
        {
            this.configurationManager = configurationManager;
        }

        public void Execute()
        {
            // get log level
            LogLevel level = LogLevel.All;
            try
            {
                level = (Logging.LogLevel)Enum.Parse( typeof( Logging.LogLevel ), this.configurationManager.AppSettings[ "LogLevel" ] );
            }
            catch ( Exception ) { }

            // get path
            string path = this.configurationManager.AppSettings[ "LogPath" ];
            if ( path.StartsWith( "~" ) ) path = HttpContext.Current.Server.MapPath( path );

            IoC.Register<ILog>( LogProvider.GetLog( "Txtr.Platform.Data.WebService.Web", level, path, "Txtr.Data.WebService" ) );
        }
    }
}