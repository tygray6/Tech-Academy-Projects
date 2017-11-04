namespace Bewander.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Places : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StateID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.Place",
                c => new
                    {
                        PlaceID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        StreetNumber = c.Int(nullable: false),
                        Route = c.String(),
                        PostalCode = c.Int(nullable: false),
                        CityID = c.Int(nullable: false),
                        StateID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlaceID);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StateID);
            
            AddColumn("dbo.Review", "PlaceID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Review", "PlaceID");
            DropTable("dbo.State");
            DropTable("dbo.Place");
            DropTable("dbo.Country");
            DropTable("dbo.City");
        }
    }
}
