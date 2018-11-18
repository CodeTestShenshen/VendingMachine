using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using VendingMachineApp.Helper;

namespace VendingMachineApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
          //  httpConfiguration.DependencyResolver = new WindsorApiResolver(IOCLocator.Container);
            httpConfiguration.Services.Replace(
                typeof(IHttpControllerActivator), new WindsorCompositionRoot(IOCLocator.Container));
            WebApiConfig.Register(httpConfiguration);
            appBuilder.UseWebApi(httpConfiguration);
        }
        
    }
}