namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableInvTransferMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invTransferMaster",
                c => new
                    {
                        trId = c.Int(nullable: false, identity: true),
                        trDate = c.DateTime(nullable: false, precision: 7),
                        trNo = c.String(),
                        dateTime = c.DateTime(nullable: false, precision: 7),
                        fromDepartmentId = c.Int(nullable: false),
                        toDepartmentId = c.Int(nullable: false),
                        isPost = c.Boolean(nullable: false),
                        fromBranchId = c.Int(nullable: false),
                        toBranchId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        modifiedBy = c.Int(nullable: false),
                        modifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        isReceive = c.Boolean(nullable: false),
                        postUserId = c.Int(nullable: false),
                        postDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.trId)
                .ForeignKey("dbo.loginUser", t => t.userId, cascadeDelete: false)
                .ForeignKey("dbo.loginUser", t => t.modifiedBy, cascadeDelete: false)
                .ForeignKey("dbo.settingBranch", t => t.toBranchId, cascadeDelete: false)
                .ForeignKey("dbo.settingBranch", t => t.fromBranchId, cascadeDelete: false)
                .ForeignKey("dbo.settingDepartment", t => t.fromDepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.settingDepartment", t => t.toDepartmentId, cascadeDelete: false)
                .Index(t => t.fromDepartmentId)
                .Index(t => t.toDepartmentId)
                .Index(t => t.fromBranchId)
                .Index(t => t.toBranchId)
                .Index(t => t.userId)
                .Index(t => t.modifiedBy);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invTransferMaster", "toDepartmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invTransferMaster", "fromDepartmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invTransferMaster", "fromBranchId", "dbo.settingBranch");
            DropForeignKey("dbo.invTransferMaster", "toBranchId", "dbo.settingBranch");
            DropForeignKey("dbo.invTransferMaster", "modifiedBy", "dbo.loginUser");
            DropForeignKey("dbo.invTransferMaster", "userId", "dbo.loginUser");
            DropIndex("dbo.invTransferMaster", new[] { "modifiedBy" });
            DropIndex("dbo.invTransferMaster", new[] { "userId" });
            DropIndex("dbo.invTransferMaster", new[] { "toBranchId" });
            DropIndex("dbo.invTransferMaster", new[] { "fromBranchId" });
            DropIndex("dbo.invTransferMaster", new[] { "toDepartmentId" });
            DropIndex("dbo.invTransferMaster", new[] { "fromDepartmentId" });
            AlterColumn("dbo.invWareHouse", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.invGRNMaster", "grnDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.invGRNDetail", "expiryDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropTable("dbo.invTransferMaster");
        }
    }
}
