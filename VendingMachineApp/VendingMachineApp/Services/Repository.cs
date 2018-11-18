using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachineApp.Database;

namespace VendingMachineApp.Services
{
    public class Repository: IRepository
    {
        public Repository()
        {
            VendingMachineContext v = new VendingMachineContext();
            var a = v.Database;
        }
    }
}