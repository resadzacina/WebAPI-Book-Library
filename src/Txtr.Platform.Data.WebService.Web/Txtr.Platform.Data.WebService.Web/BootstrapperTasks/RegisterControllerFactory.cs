using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Txtr.Platform.Data.Core;
using Txtr.Platform.Data.Core.Bootstrapper;

namespace Txtr.Platform.Data.WebService.Web.BootstrapperTasks
{
    public class RegisterControllerFactory : IBootstrapperTask
    {
        private readonly IControllerFactory controllerFactory;

        public RegisterControllerFactory( IControllerFactory controllerFactory )
        {
            Check.IsNotNull( controllerFactory, "controllerFactory" );

            this.controllerFactory = controllerFactory;
        }

        public void Execute()
        {
            ControllerBuilder.Current.SetControllerFactory( this.controllerFactory );
        }
    }
}