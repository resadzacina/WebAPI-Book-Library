using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Txtr.Platform.Data.Core.Dependency;

namespace Txtr.Platform.Data.WebService.Web.Controllers
{
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance( System.Web.Routing.RequestContext requestContext, Type controllerType )
        {
            return ( controllerType == null ) ? base.GetControllerInstance( requestContext, controllerType ) : IoC.Resolve<IController>( controllerType );
        }
    }
}