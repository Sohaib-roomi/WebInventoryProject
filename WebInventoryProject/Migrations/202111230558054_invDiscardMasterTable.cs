namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invDiscardMasterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invDiscardMaster",
                c => new
                    {
                        discardId = c.Int(nullable: false, identity: true),
                        discardDate = c.DateTime(nullable: false),
                        discardNo = c.String(),
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
                .PrimaryKey(t => t.discardId)
                .ForeignKey("dbo.loginUser", t => t.userId, cascadeDelete: false)
                .ForeignKey("dbo.loginUser", t => t.postUserId, cascadeDelete: false)
                .ForeignKey("dbo.loginUser", t => t.modifiedBy, cascadeDelete: false)
                .ForeignKey("dbo.settingBranch", t => t.branchId, cascadeDelete: false)
                .ForeignKey("dbo.settingDepartment", t => t.departmentId, cascadeDelete: true)
                .Index(t => t.branchId)
                .Index(t => t.departmentId)
                .Index(t => t.userId)
                .Index(t => t.modifiedBy)
                .Index(t => t.postUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invDiscardMaster", "departmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invDiscardMaster", "branchId", "dbo.settingBranch");
            DropForeignKey("dbo.invDiscardMaster", "modifiedBy", "dbo.loginUser");
            DropForeignKey("dbo.invDiscardMaster", "postUserId", "dbo.loginUser");
            DropForeignKey("dbo.invDiscardMaster", "userId", "dbo.loginUser");
            DropIndex("dbo.invDiscardMaster", new[] { "postUserId" });
            DropIndex("dbo.invDiscardMaster", new[] { "modifiedBy" });
            DropIndex("dbo.invDiscardMaster", new[] { "userId" });
            DropIndex("dbo.invDiscardMaster", new[] { "departmentId" });
            DropIndex("dbo.invDiscardMaster", new[] { "branchId" });
            DropTable("dbo.invDiscardMaster");
        }
    }
}
