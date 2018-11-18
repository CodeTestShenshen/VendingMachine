namespace VendingMachineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFlavursModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flaviours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeriesNumber = c.String(nullable: false),
                        PriceInCents = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Transactions", "FlaviourId", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "TransactionType", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "PriceInCents", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "TansactionTime", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Transactions", "FlaviourId");
            AddForeignKey("dbo.Transactions", "FlaviourId", "dbo.Flaviours", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "FlaviourId", "dbo.Flaviours");
            DropIndex("dbo.Transactions", new[] { "FlaviourId" });
            DropColumn("dbo.Transactions", "TansactionTime");
            DropColumn("dbo.Transactions", "PriceInCents");
            DropColumn("dbo.Transactions", "TransactionType");
            DropColumn("dbo.Transactions", "FlaviourId");
            DropTable("dbo.Flaviours");
        }
    }
}
