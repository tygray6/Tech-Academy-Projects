namespace Bewander.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserProfileID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        About = c.String(),
                        HomeTown = c.String(),
                        TravelLocations = c.String(),
                        FavoriteLocation = c.String(),
                    })
                .PrimaryKey(t => t.UserProfileID);
            
            DropColumn("dbo.User", "About");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "About", c => c.String(maxLength: 50));
            DropTable("dbo.UserProfile");
        }
    }
}
