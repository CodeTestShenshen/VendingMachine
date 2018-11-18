using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineApp.ViewModels;

namespace VendingMachineApp.Services
{
    public interface IStateMonitor
    {
        RunningState GetStateWithMachineNum(string machineSeriesNumber);
        void UpdateStatus(RunningState state);
        List<RunningState> GetAll();
    }
}
