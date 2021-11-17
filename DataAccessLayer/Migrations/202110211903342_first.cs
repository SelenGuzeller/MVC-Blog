namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryTypes", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.CategoryTypes", new[] { "Category_CategoryID" });
            DropColumn("dbo.CategoryTypes", "Category_CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoryTypes", "Category_CategoryID", c => c.Int());
            CreateIndex("dbo.CategoryTypes", "Category_CategoryID");
            AddForeignKey("dbo.CategoryTypes", "Category_CategoryID", "dbo.Categories", "CategoryID");
        }
    }
}
