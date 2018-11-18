using System.Collections.Generic;
using System.Linq;
using VendingMachineApp.Helper;
using VendingMachineApp.ViewModels;

namespace VendingMachineApp.Services
{
    public class StateMonitor: IStateMonitor
    {
        public RunningState GetStateWithMachineNum(string machineSeriesNumber)
        {
            if (StatesLocator.RunningStateCache.ContainsKey(machineSeriesNumber))
            {
                return StatesLocator.RunningStateCache[machineSeriesNumber];
            }

            return null;
        }

        public void UpdateStatus(RunningState state)
        {
            StatesLocator.RunningStateCache[state.MachineSeriesNumber] = state;
        }

        public List<RunningState> GetAll()
        {
            return StatesLocator.RunningStateCache.Select(x => x.Value).ToList();
        }
    }
}