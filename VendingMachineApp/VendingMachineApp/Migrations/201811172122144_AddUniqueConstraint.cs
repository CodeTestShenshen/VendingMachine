namespace VendingMachineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueConstraint : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MachineId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Machines", t => t.MachineId, cascadeDelete: true)
                .Index(t => t.MachineId);
            
            AlterColumn("dbo.Machines", "SeriesNumber", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Machines", "SeriesNumber", unique: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "MachineId", "dbo.Machines");
            DropIndex("dbo.Transactions", new[] { "MachineId" });
            DropIndex("dbo.Machines", new[] { "SeriesNumber" });
            AlterColumn("dbo.Machines", "SeriesNumber", c => c.String(nullable: false));
            DropTable("dbo.Transactions");
        }
    }
}
