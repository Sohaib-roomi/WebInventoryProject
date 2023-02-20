namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invProductionMasterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invProductionMaster",
                c => new
                    {
                        prId = c.Int(nullable: false, identity: true),
                        prDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        prNo = c.String(),
                        branchId = c.Int(nullable: false),
                        departmentId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        modifiedBy = c.Int(nullable: false),
                        modifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        workStation = c.String(),
                        isPost = c.Boolean(nullable: false),
                        postUserId = c.Int(nullable: false),
                        postDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.prId)
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
            DropForeignKey("dbo.invProductionMaster", "departmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invProductionMaster", "branchId", "dbo.settingBranch");
            DropForeignKey("dbo.invProductionMaster", "modifiedBy", "dbo.loginUser");
            DropForeignKey("dbo.invProductionMaster", "postUserId", "dbo.loginUser");
            DropForeignKey("dbo.invProductionMaster", "userId", "dbo.loginUser");
            DropIndex("dbo.invProductionMaster", new[] { "postUserId" });
            DropIndex("dbo.invProductionMaster", new[] { "modifiedBy" });
            DropIndex("dbo.invProductionMaster", new[] { "userId" });
            DropIndex("dbo.invProductionMaster", new[] { "departmentId" });
            DropIndex("dbo.invProductionMaster", new[] { "branchId" });
            DropTable("dbo.invProductionMaster");
        }
    }
}
