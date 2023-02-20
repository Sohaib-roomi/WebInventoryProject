namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.loginUsers",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        email = c.String(nullable: false, maxLength: 30),
                        password = c.String(nullable: false, maxLength: 20),
                        firstName = c.String(nullable: false, maxLength: 30),
                        lastName = c.String(nullable: false, maxLength: 30),
                        contactNo = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "dbo.SettingCategory",
                c => new
                    {
                        categoryId = c.Int(nullable: false, identity: true),
                        categoryCode = c.String(nullable: false, maxLength: 10),
                        categoryName = c.String(nullable: false, maxLength: 30),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.categoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SettingCategory");
            DropTable("dbo.loginUsers");
        }
    }
}
