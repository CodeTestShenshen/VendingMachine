using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachineApp.Helper
{
    public class IOCLocator
    {
        private static readonly Lazy<IWindsorContainer> Instance = new Lazy<IWindsorContainer>(() => new WindsorContainer());

        public static IWindsorContainer Container
        {
            get
            {
                return Instance.Value;
                
            }
        } 
    }
}