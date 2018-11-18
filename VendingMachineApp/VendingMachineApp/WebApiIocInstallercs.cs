using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
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

            container.Register(Component.For<IStateMonitor>().ImplementedBy<StateMonitor>());
        }
    }
}