namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "HeadingDescription", c => c.String());
            DropColumn("dbo.Headings", "HeadingStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Headings", "HeadingStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Headings", "HeadingDescription");
        }
    }
}
