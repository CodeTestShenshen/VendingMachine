using VendingMachineApp.Helper;
using VendingMachineApp.Models;

namespace VendingMachineApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VendingMachineApp.Database.VendingMachineContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VendingMachineApp.Database.VendingMachineContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Machines.AddOrUpdate(x => x.SeriesNumber,
                new Machine()
                {
                    SeriesNumber = AppHelper.SeedMachineNum1, IsActive = true, Location = "123 N Road", PostCode = "2222",
                    State = States.NSW
                },
                new Machine()
                {
                    SeriesNumber = AppHelper.SeedMachineNum2, IsActive = true, Location = "22 S Road", PostCode = "1242",
                    State = States.WA
                },
                new Machine()
                {
                    SeriesNumber = AppHelper.SeedMachineNum3, IsActive = true, Location = "11 A Road", PostCode = "3214",
                    State = States.VIC
                },
                new Machine()
                {
                    SeriesNumber = AppHelper.SeedMachineNum4, IsActive = true, Location = "44 B Road", PostCode = "1111",
                    State = States.QLD
                }
            );

        }
    }
}
