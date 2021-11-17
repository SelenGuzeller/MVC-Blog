namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class content_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        ContentValue = c.String(maxLength: 1000),
                        ContentDate = c.DateTime(nullable: false),
                        ContentStatus = c.Boolean(nullable: false),
                        HeadingID = c.Int(),
                        ArtID = c.Int(),
                        MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.ContentID)
                .ForeignKey("dbo.Arts", t => t.ArtID)
                .ForeignKey("dbo.Headings", t => t.HeadingID)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.HeadingID)
                .Index(t => t.ArtID)
                .Index(t => t.MemberId);
            
            AlterColumn("dbo.Arts", "ArtName", c => c.String());
            AlterColumn("dbo.Arts", "ArtDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Contents", "HeadingID", "dbo.Headings");
            DropForeignKey("dbo.Contents", "ArtID", "dbo.Arts");
            DropIndex("dbo.Contents", new[] { "MemberId" });
            DropIndex("dbo.Contents", new[] { "ArtID" });
            DropIndex("dbo.Contents", new[] { "HeadingID" });
            AlterColumn("dbo.Arts", "ArtDescription", c => c.String(maxLength: 200));
            AlterColumn("dbo.Arts", "ArtName", c => c.String(maxLength: 50));
            DropTable("dbo.Contents");
        }
    }
}
