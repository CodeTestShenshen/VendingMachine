using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VendingMachineApp.Helper;
using VendingMachineApp.Services;

namespace VendingMachineApp
{
    public class WebApiIocInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // resolve all controllers
            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestylePerWebRequest());
            container.Register(Component.For<IRepository>().ImplementedBy<Repository>()
                .DependsOn(Dependency.OnValue("connString", AppHelper.DBConnectName)));
        }
    }
}