using VendingMachineApp.Helper;

namespace VendingMachineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using VendingMachineApp.Models;

    public partial class AddSeedsData : DbMigration
    {
        public override void Up()
        { 
            Sql($"Insert into Machines (SeriesNumber, [Location], [PostCode], [State], [IsActive]) values({AppHelper.SeedMachineNum1}, 'localtion1', '2222', {(int)States.QLD}, 1)");
            Sql($"Insert into Machines (SeriesNumber, [Location], [PostCode], [State], [IsActive]) values({AppHelper.SeedMachineNum2}, 'localtion2', '1111', {(int)States.NSW}, 1)");
            Sql($"Insert into Machines (SeriesNumber, [Location], [PostCode], [State], [IsActive]) values({AppHelper.SeedMachineNum3}, 'localtion3', '1234', {(int)States.WA}, 1)");
            Sql($"Insert into Machines (SeriesNumber, [Location], [PostCode], [State], [IsActive]) values({AppHelper.SeedMachineNum4}, 'localtion4', '4321', {(int)States.VIC}, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
