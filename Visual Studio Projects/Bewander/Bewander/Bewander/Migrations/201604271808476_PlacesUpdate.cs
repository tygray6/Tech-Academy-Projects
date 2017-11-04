namespace Bewander.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlacesUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Place", "Lat", c => c.Single(nullable: false));
            AddColumn("dbo.Place", "Lng", c => c.Single(nullable: false));
            AddColumn("dbo.Place", "Website", c => c.String());
            AddColumn("dbo.Place", "UserProfile_UserProfileID", c => c.Int());
            AlterColumn("dbo.Place", "PostalCode", c => c.String());
            CreateIndex("dbo.Place", "UserProfile_UserProfileID");
            AddForeignKey("dbo.Place", "UserProfile_UserProfileID", "dbo.UserProfile", "UserProfileID");
            DropColumn("dbo.UserProfile", "TravelLocations");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfile", "TravelLocations", c => c.String());
            DropForeignKey("dbo.Place", "UserProfile_UserProfileID", "dbo.UserProfile");
            DropIndex("dbo.Place", new[] { "UserProfile_UserProfileID" });
            AlterColumn("dbo.Place", "PostalCode", c => c.Int(nullable: false));
            DropColumn("dbo.Place", "UserProfile_UserProfileID");
            DropColumn("dbo.Place", "Website");
            DropColumn("dbo.Place", "Lng");
            DropColumn("dbo.Place", "Lat");
        }
    }
}
