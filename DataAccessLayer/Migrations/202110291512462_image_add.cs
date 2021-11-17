namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "HeadingImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "HeadingImage");
        }
    }
}
