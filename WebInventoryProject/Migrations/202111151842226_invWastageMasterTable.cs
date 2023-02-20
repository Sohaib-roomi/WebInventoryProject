namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invWastageMasterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invWastageMaster",
                c => new
                    {
                        wastageId = c.Int(nullable: false, identity: true),
                        wastageDate = c.DateTime(nullable: false),
                        wastageNo = c.String(),
                        branchId = c.Int(nullable: false),
                        departmentId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        modifiedBy = c.Int(nullable: false),
                        modifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        workStation = c.String(),
                        isPost = c.Boolean(nullable: false),
                        postUserId = c.Int(nullable: false),
                        postDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.wastageId)
                .ForeignKey("dbo.loginUser", t => t.userId, cascadeDelete: false)
                .ForeignKey("dbo.loginUser", t => t.postUserId, cascadeDelete: false)
                .ForeignKey("dbo.loginUser", t => t.modifiedBy, cascadeDelete: false)
                .ForeignKey("dbo.settingBranch", t => t.branchId, cascadeDelete: false)
                .ForeignKey("dbo.settingDepartment", t => t.departmentId, cascadeDelete: false)
                .Index(t => t.branchId)
                .Index(t => t.departmentId)
                .Index(t => t.userId)
                .Index(t => t.modifiedBy)
                .Index(t => t.postUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invWastageMaster", "departmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invWastageMaster", "branchId", "dbo.settingBranch");
            DropForeignKey("dbo.invWastageMaster", "modifiedBy", "dbo.loginUser");
            DropForeignKey("dbo.invWastageMaster", "postUserId", "dbo.loginUser");
            DropForeignKey("dbo.invWastageMaster", "userId", "dbo.loginUser");
            DropIndex("dbo.invWastageMaster", new[] { "postUserId" });
            DropIndex("dbo.invWastageMaster", new[] { "modifiedBy" });
            DropIndex("dbo.invWastageMaster", new[] { "userId" });
            DropIndex("dbo.invWastageMaster", new[] { "departmentId" });
            DropIndex("dbo.invWastageMaster", new[] { "branchId" });
            DropTable("dbo.invWastageMaster");
        }
    }
}
