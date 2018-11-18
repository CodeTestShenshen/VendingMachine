using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachineApp.Models;

namespace VendingMachineApp.Services
{
    public interface IRepository
    {
        Machine GetMachineByseriesNumber(string seriesNumber);
        Flavour GetFlavourBySeriesNumber(string seriesNumber);
        IEnumerable<Machine> GetMachines();
        void DeleteMachine(string seriesNumber);
        void SaveTransaction(Transaction transaction);
        IEnumerable<Transaction> GetTransactions(string machineSeriesNumber);

    }
}