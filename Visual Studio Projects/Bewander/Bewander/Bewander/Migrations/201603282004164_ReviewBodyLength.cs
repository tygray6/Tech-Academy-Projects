namespace Bewander.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewBodyLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Review", "Body", c => c.String(nullable: false, maxLength: 700));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Review", "Body", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
