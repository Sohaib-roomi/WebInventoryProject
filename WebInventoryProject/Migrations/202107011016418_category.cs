namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.loginUsers", newName: "loginUser");
            CreateIndex("dbo.SettingCategory", "categoryCode", unique: true);
            CreateIndex("dbo.SettingCategory", "categoryName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.SettingCategory", new[] { "categoryName" });
            DropIndex("dbo.SettingCategory", new[] { "categoryCode" });
            RenameTable(name: "dbo.loginUser", newName: "loginUsers");
        }
    }
}
