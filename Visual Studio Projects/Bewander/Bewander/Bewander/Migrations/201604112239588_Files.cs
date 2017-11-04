namespace Bewander.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.File",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        UserID = c.String(),
                        UserProfile_UserProfileID = c.Int(),
                    })
                .PrimaryKey(t => t.FileID)
                .ForeignKey("dbo.UserProfile", t => t.UserProfile_UserProfileID)
                .Index(t => t.UserProfile_UserProfileID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.File", "UserProfile_UserProfileID", "dbo.UserProfile");
            DropIndex("dbo.File", new[] { "UserProfile_UserProfileID" });
            DropTable("dbo.File");
        }
    }
}
