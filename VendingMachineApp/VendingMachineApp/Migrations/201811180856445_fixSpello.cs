namespace VendingMachineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixSpello : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Flaviours", newName: "Flavours");
            RenameColumn(table: "dbo.Transactions", name: "FlaviourId", newName: "FlavourId");
            RenameIndex(table: "dbo.Transactions", name: "IX_FlaviourId", newName: "IX_FlavourId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Transactions", name: "IX_FlavourId", newName: "IX_FlaviourId");
            RenameColumn(table: "dbo.Transactions", name: "FlavourId", newName: "FlaviourId");
            RenameTable(name: "dbo.Flavours", newName: "Flaviours");
        }
    }
}
