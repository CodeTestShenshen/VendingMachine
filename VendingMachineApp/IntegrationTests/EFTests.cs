using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineApp.Database;
using VendingMachineApp.Helper;
using VendingMachineApp.Models;

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
        public void VendingMachineContextTest_InitilizeSeedData2_Successfully()
        {
            // arrange
            var sNum = Guid.NewGuid().ToString();
            var stubMachine = GetFakeMachine(sNum);

            //action
           var result = testContext.Machines.Add(stubMachine);
            testContext.SaveChanges();
            //assert
            Assert.IsTrue(testContext.Machines.Any(m=> m.SeriesNumber == sNum));

        }
    }
}
