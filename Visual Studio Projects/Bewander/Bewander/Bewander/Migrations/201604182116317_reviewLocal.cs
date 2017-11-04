namespace Bewander.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviewLocal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "TravelLocations", c => c.String());
            AddColumn("dbo.Review", "Local", c => c.Int(nullable: false));
            DropColumn("dbo.UserProfile", "TavelLocations");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfile", "TavelLocations", c => c.String());
            DropColumn("dbo.Review", "Local");
            DropColumn("dbo.UserProfile", "TravelLocations");
        }
    }
}
