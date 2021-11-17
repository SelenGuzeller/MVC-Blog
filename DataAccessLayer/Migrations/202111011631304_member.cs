namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class member : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        MemberName = c.String(maxLength: 50),
                        MemberSurName = c.String(maxLength: 50),
                        MemberImage = c.String(maxLength: 250),
                        MemberMail = c.String(maxLength: 200),
                        MemberPassword = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.MemberID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
