using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineApp.Database;
using VendingMachineApp.Helper;
using VendingMachineApp.Models;
using VendingMachineApp.Services;

namespace IntegrationTests
{
    [TestClass]
    public class EFTests
    {
        VendingMachineContext testContext;
        const string testDBName = "TestDB";

        [TestInitialize]
        public void TestSetup()
        {
            testContext = new VendingMachineContext(testDBName);
            testContext.Configuration.AutoDetectChangesEnabled = true;
            testContext.Database.CreateIfNotExists();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            try
            {
                testContext.Database.ExecuteSqlCommand(("TRUNCATE TABLE [Transactions]"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally 
            {
                testContext.Dispose();
            }               
        }
        

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Database.Delete(testDBName);
        }
        
        private Machine GetFakeMachine(string seriesNumber)
        {
            return new Machine()
            {
                Location = "location1",
                IsActive = true,
                PostCode = "2222",
                SeriesNumber = seriesNumber,
                State = States.NSW
            };
        }

        private Transaction GetFakeTransaction(Machine fakeMachine, Flavour fakeFlaviour)
        {
            return new Transaction()
            {
               Machine = fakeMachine,
               Flavour = fakeFlaviour,
               FlavourId = fakeFlaviour.Id,
               PriceInCents = 2500 ,
               IsActive = true,
               TransactionType = TransactionType.cash,
               MachineId = fakeMachine.Id,
               TansactionTime = DateTime.Now

            };
        }

        private Flavour GetFakeFlaviour(string sNum)
        {
            return new Flavour()
            {
                SeriesNumber = sNum,
                PriceInCents = 2500,
                Name = "f1",
                IsActive = true
            };
        } 

        [TestMethod]
        public void VendingMachineContextTest_InitilizeSeedData_Successfully()
        {
            // arrange

            //action
            var seedMachines = testContext.Machines;
            //assert
            Assert.IsTrue(testContext.Machines.Any(m => m.SeriesNumber == AppHelper.SeedMachineNum1));
            Assert.IsTrue(testContext.Machines.Any(m => m.SeriesNumber == AppHelper.SeedMachineNum2));
            Assert.IsTrue(testContext.Machines.Any(m => m.SeriesNumber == AppHelper.SeedMachineNum3));
            Assert.IsTrue(testContext.Machines.Any(m => m.SeriesNumber == AppHelper.SeedMachineNum4));

        }

        [TestMethod]
        public void RepositoryTest_GetMachines_ReturnAllSeedMachines()
        {
            // arrange
            var repository = new Repository(testDBName);

            //action
            var result = repository.GetMachines();
            //assert
            Assert.IsTrue(result.Any(m => m.SeriesNumber == AppHelper.SeedMachineNum1));
            Assert.IsTrue(result.Any(m => m.SeriesNumber == AppHelper.SeedMachineNum2));
            Assert.IsTrue(result.Any(m => m.SeriesNumber == AppHelper.SeedMachineNum3));
            Assert.IsTrue(result.Any(m => m.SeriesNumber == AppHelper.SeedMachineNum4));

        }

        [TestMethod]
        public void RepositoryTest_GetMachineByseriesNumber_ReturnAMachine()
        {
            // arrange
            var repository = new Repository(testDBName);

            //action
            var result = repository.GetMachineByseriesNumber(AppHelper.SeedMachineNum1);
            //assert
            Assert.IsTrue(result.SeriesNumber == AppHelper.SeedMachineNum1); 

        }

        [TestMethod]
        public void RepositoryTest_DeleteMachine_SetMachineActiveAsFalse()
        {
            // arrange
            var repository = new Repository(testDBName);
            
            //action
            repository.DeleteMachine(AppHelper.SeedMachineNum2);
            var result = repository.GetMachineByseriesNumber(AppHelper.SeedMachineNum2);
            //assert
            Assert.IsTrue(testContext.Machines.Any(m => m.IsActive == false)); 

        }

        [TestMethod]
        public void RepositoryTest_GetTransactions_ReturnTransactions()
        {
            // arrange
            var repository = new Repository(testDBName);
            var flaviour = testContext.Flaviours.FirstOrDefault();
            var machine = testContext.Machines.FirstOrDefault();

            var stubTransaction = GetFakeTransaction(machine, flaviour);
             
            // to avoid from adding reference too
            stubTransaction.Machine = null;
            stubTransaction.Flavour = null;
           
            testContext.Transactions.Add(stubTransaction);         
            testContext.SaveChanges();
            var d = testContext.Transactions.FirstOrDefault();
            testContext.Dispose();
            //action
            var result = repository.GetTransactions(machine.SeriesNumber).FirstOrDefault();
            //assert
            Assert.IsTrue(result.MachineId == machine.Id); 

        }

        [TestMethod]
        public void RepositoryTest_SaveTransaction_SaveNewTransaction()
        {
            // arrange
            var repository = new Repository(testDBName);
            var newFlaviour = testContext.Flaviours.FirstOrDefault();
            var newMachine = testContext.Machines.FirstOrDefault();
       
 
            var stubTransaction = GetFakeTransaction(newMachine, newFlaviour);

            // to avoid from adding reference too
            stubTransaction.Machine = null;
            stubTransaction.Flavour = null;
            //action
             repository.SaveTransaction(stubTransaction);
            //assert 
            var b = testContext.Transactions.Where(t => t.MachineId == newMachine.Id).FirstOrDefault();
            Assert.IsTrue(b.Machine.SeriesNumber == newMachine.SeriesNumber );
            Assert.IsTrue(b.Flavour.SeriesNumber == newFlaviour.SeriesNumber);
        }
    }
}
