using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachineApp.ViewModels;

namespace VendingMachineApp.Helper
{
    public static class StatesLocator
    {
        private static Lazy<Dictionary<string, RunningState>> stateCache = new Lazy<Dictionary<string, RunningState>>();

        public static Dictionary<string, RunningState> RunningStateCache
        {
            get { return stateCache.Value; }
        }
    }
}