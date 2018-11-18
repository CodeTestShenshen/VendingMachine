namespace VendingMachineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using VendingMachineApp.Helper;

    public partial class AddFlavursModelAndSeedData : DbMigration
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

            Sql($"Insert into Flavours (SeriesNumber, PriceInCents, [PostCode], Name, [IsActive]) values({AppHelper.SeedFlavourNum1}, '350', 'F1', 1)");
            Sql($"Insert into Flavours (SeriesNumber, PriceInCents, [PostCode], Name, [IsActive]) values({AppHelper.SeedFlavourNum2}, '410', 'F2', 1)");
            Sql($"Insert into Flavours (SeriesNumber, PriceInCents, [PostCode], Name, [IsActive]) values({AppHelper.SeedFlavourNum3}, '250', 'F3', 1)");
            Sql($"Insert into Flavours (SeriesNumber, PriceInCents, [PostCode], Name, [IsActive]) values({AppHelper.SeedFlavourNum4}, '150', 'F4', 1)");
            Sql($"Insert into Flavours (SeriesNumber, PriceInCents, [PostCode], Name, [IsActive]) values({AppHelper.SeedFlavourNum5}, '550', 'F5', 1)");
            Sql($"Insert into Flavours (SeriesNumber, PriceInCents, [PostCode], Name, [IsActive]) values({AppHelper.SeedFlavourNum6}, '305', 'F6', 1)");
            Sql($"Insert into Flavours (SeriesNumber, PriceInCents, [PostCode], Name, [IsActive]) values({AppHelper.SeedFlavourNum7}, '380', 'F7', 1)");
            Sql($"Insert into Flavours (SeriesNumber, PriceInCents, [PostCode], Name, [IsActive]) values({AppHelper.SeedFlavourNum8}, '820', 'F8', 1)");
            Sql($"Insert into Flavours (SeriesNumber, PriceInCents, [PostCode], Name, [IsActive]) values({AppHelper.SeedFlavourNum9}, '1150', 'F9', 1)");
            Sql($"Insert into Flavours (SeriesNumber, PriceInCents, [PostCode], Name, [IsActive]) values({AppHelper.SeedFlavourNum10}, '2330', 'F10', 1)");

        }
        
        public override void Down()
        {
            DropTable("dbo.Flaviours");
        }
    }
}
