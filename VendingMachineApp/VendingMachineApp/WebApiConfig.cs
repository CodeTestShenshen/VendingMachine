using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VendingMachineApp.Helper;

namespace VendingMachineApp
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            InitializeIoc();
        }

        private static void InitializeIoc()
        {
            IOCLocator.Container.Install(new WebApiIocInstaller());
        }
    }
}