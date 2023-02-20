namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invIssuanceMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invIssuanceMaster",
                c => new
                    {
                        issuanceId = c.Int(nullable: false, identity: true),
                        issuanceDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        issuanceNo = c.String(),
                        fromBranchId = c.Int(nullable: false),
                        toBranchId = c.Int(nullable: false),
                        fromDepartmentId = c.Int(nullable: false),
                        toDepartmentId = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        userId = c.Int(nullable: false),
                        modifiedBy = c.Int(nullable: false),
                        modifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        workStation = c.String(),
                        isPost = c.Boolean(nullable: false),
                        isReceive = c.Boolean(nullable: false),
                        postUserId = c.Int(nullable: false),
                        postDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        postTime = c.String(),
                    })
                .PrimaryKey(t => t.issuanceId)
                .ForeignKey("dbo.loginUser", t => t.userId, cascadeDelete: false)
                .ForeignKey("dbo.loginUser", t => t.modifiedBy, cascadeDelete: false)
                .ForeignKey("dbo.settingBranch", t => t.toBranchId, cascadeDelete: false)
                .ForeignKey("dbo.settingBranch", t => t.fromBranchId, cascadeDelete: false)
                .ForeignKey("dbo.settingDepartment", t => t.fromDepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.settingDepartment", t => t.toDepartmentId, cascadeDelete: false)
                .Index(t => t.fromBranchId)
                .Index(t => t.toBranchId)
                .Index(t => t.fromDepartmentId)
                .Index(t => t.toDepartmentId)
                .Index(t => t.userId)
                .Index(t => t.modifiedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invIssuanceMaster", "toDepartmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invIssuanceMaster", "fromDepartmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invIssuanceMaster", "fromBranchId", "dbo.settingBranch");
            DropForeignKey("dbo.invIssuanceMaster", "toBranchId", "dbo.settingBranch");
            DropForeignKey("dbo.invIssuanceMaster", "modifiedBy", "dbo.loginUser");
            DropForeignKey("dbo.invIssuanceMaster", "userId", "dbo.loginUser");
            DropIndex("dbo.invIssuanceMaster", new[] { "modifiedBy" });
            DropIndex("dbo.invIssuanceMaster", new[] { "userId" });
            DropIndex("dbo.invIssuanceMaster", new[] { "toDepartmentId" });
            DropIndex("dbo.invIssuanceMaster", new[] { "fromDepartmentId" });
            DropIndex("dbo.invIssuanceMaster", new[] { "toBranchId" });
            DropIndex("dbo.invIssuanceMaster", new[] { "fromBranchId" });
            DropTable("dbo.invIssuanceMaster");
        }
    }
}
