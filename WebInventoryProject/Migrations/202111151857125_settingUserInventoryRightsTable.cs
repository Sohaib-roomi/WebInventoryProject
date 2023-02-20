namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settingUserInventoryRightsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.settingUserInventoryRights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        branchId = c.Int(nullable: false),
                        formId = c.Int(nullable: false),
                        save = c.Boolean(nullable: false),
                        edit = c.Boolean(nullable: false),
                        delete = c.Boolean(nullable: false),
                        post = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.loginUser", t => t.userId, cascadeDelete: false)
                .ForeignKey("dbo.settingBranch", t => t.branchId, cascadeDelete: false)
                .Index(t => t.userId)
                .Index(t => t.branchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.settingUserInventoryRights", "branchId", "dbo.settingBranch");
            DropForeignKey("dbo.settingUserInventoryRights", "userId", "dbo.loginUser");
            DropIndex("dbo.settingUserInventoryRights", new[] { "branchId" });
            DropIndex("dbo.settingUserInventoryRights", new[] { "userId" });
            DropTable("dbo.settingUserInventoryRights");
        }
    }
}
