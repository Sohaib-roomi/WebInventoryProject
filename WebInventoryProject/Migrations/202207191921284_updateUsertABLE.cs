namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUsertABLE : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.settingUserInventoryRights", "departmentId", c => c.Int(nullable: false));
            AddColumn("dbo.settingUserInventoryRights", "UserType", c => c.String());
            CreateIndex("dbo.settingUserInventoryRights", "departmentId");
            AddForeignKey("dbo.settingUserInventoryRights", "departmentId", "dbo.settingDepartment", "departmentId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.settingUserInventoryRights", "departmentId", "dbo.settingDepartment");
            DropIndex("dbo.settingUserInventoryRights", new[] { "departmentId" });
            DropColumn("dbo.settingUserInventoryRights", "UserType");
            DropColumn("dbo.settingUserInventoryRights", "departmentId");
        }
    }
}
