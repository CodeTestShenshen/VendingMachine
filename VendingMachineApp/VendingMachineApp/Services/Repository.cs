using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VendingMachineApp.Database;
using VendingMachineApp.Models;

namespace VendingMachineApp.Services
{
    public class DbContextCreator : IDisposable
    {
        private VendingMachineContext _context;

        public VendingMachineContext DbContext
        {
            get { return _context; }
        }

        public DbContextCreator(string connString)
        {
            if (string.IsNullOrEmpty(connString))
                _context = new VendingMachineContext();
            else
                _context = new VendingMachineContext(connString);
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
 
    }
    public class Repository: IRepository
    {
        private DbContextCreator dbCreator;
        private string connString = null;

        public Repository(string connString = null)
        {
            this.connString = connString;
        }

        public Machine GetMachineByseriesNumber(string seriesNumber)
        {          
            using (dbCreator = new DbContextCreator(connString))
            {
                return dbCreator.DbContext.Machines.Where(m =>m.SeriesNumber == seriesNumber).FirstOrDefault();
            }
        }

        public  IEnumerable<Machine> GetMachines()
        {
            using (dbCreator = new DbContextCreator(connString))
            {
                return dbCreator.DbContext.Machines.Where(t => t.IsActive ).ToList();
            }
        }

        public void DeleteMachine(string seriesNumber)
        {
            using (dbCreator = new DbContextCreator(connString))
            {
                var machine = dbCreator.DbContext.Machines.Where(m => m.SeriesNumber == seriesNumber).FirstOrDefault();
                if (machine != null)
                {
                    dbCreator.DbContext.Machines.Remove(machine);
                    dbCreator.DbContext.SaveChanges();
                }
            }
        }

        public void SaveTransaction(Transaction transaction)
        {
            using (dbCreator = new DbContextCreator(connString))
            {
                try
                {
                    // check reference
                    if (!dbCreator.DbContext.Machines.Any(m => m.Id == transaction.MachineId)
                        || !dbCreator.DbContext.Flaviours.Any(f => f.Id == transaction.FlaviourId))
                    {
                        Console.WriteLine("No reference resouces found");
                        return;
                    }

                    if (transaction.Id > 0)
                    {
                        var trans = dbCreator.DbContext.Transactions.Where(t => t.Id == transaction.Id)
                            .FirstOrDefault();

                        if (trans != null)
                        {
                            //update
                            trans.MachineId = transaction.MachineId;
                            trans.FlaviourId = transaction.FlaviourId;
                            trans.IsActive = transaction.IsActive;
                            trans.PriceInCents = transaction.PriceInCents;
                            trans.TransactionType = transaction.TransactionType;
                            trans.TansactionTime = transaction.TansactionTime;
                        }
                    }

                    // create new
                    transaction.Machine = null;
                    transaction.Flaviour = null;

                    dbCreator.DbContext.Transactions.Add(transaction);  
                    dbCreator.DbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }

        public IEnumerable<Transaction> GetTransactions(string machineSeriesNumber)
        {
            using (dbCreator = new DbContextCreator(connString))
            {
                return dbCreator.DbContext.Transactions.Where(t => t.Machine.IsActive && t.Machine.SeriesNumber == machineSeriesNumber).ToList();
            }
        }     
    }
}