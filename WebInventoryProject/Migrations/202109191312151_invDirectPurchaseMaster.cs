namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invDirectPurchaseMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invDirectPurchaseMaster",
                c => new
                    {
                        directPurchaseId = c.Int(nullable: false, identity: true),
                        directPurchaseDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        directPurchaseNo = c.String(),
                        BranchId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        totalAmount = c.Single(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        modifiedBy = c.Int(nullable: false),
                        modifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        workStation = c.String(),
                        isPost = c.Boolean(nullable: false),
                        postUserId = c.Int(nullable: false),
                        postDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.directPurchaseId)
                .ForeignKey("dbo.loginUser", t => t.postUserId, cascadeDelete: false)
                .ForeignKey("dbo.loginUser", t => t.userId, cascadeDelete: false)
                .ForeignKey("dbo.loginUser", t => t.modifiedBy, cascadeDelete: false)
                .ForeignKey("dbo.settingBranch", t => t.BranchId, cascadeDelete: false)
                .ForeignKey("dbo.settingDepartment", t => t.DepartmentId, cascadeDelete: false)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId)
                .Index(t => t.userId)
                .Index(t => t.modifiedBy)
                .Index(t => t.postUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invDirectPurchaseMaster", "DepartmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invDirectPurchaseMaster", "BranchId", "dbo.settingBranch");
            DropForeignKey("dbo.invDirectPurchaseMaster", "modifiedBy", "dbo.loginUser");
            DropForeignKey("dbo.invDirectPurchaseMaster", "userId", "dbo.loginUser");
            DropForeignKey("dbo.invDirectPurchaseMaster", "postUserId", "dbo.loginUser");
            DropIndex("dbo.invDirectPurchaseMaster", new[] { "postUserId" });
            DropIndex("dbo.invDirectPurchaseMaster", new[] { "modifiedBy" });
            DropIndex("dbo.invDirectPurchaseMaster", new[] { "userId" });
            DropIndex("dbo.invDirectPurchaseMaster", new[] { "DepartmentId" });
            DropIndex("dbo.invDirectPurchaseMaster", new[] { "BranchId" });
            DropTable("dbo.invDirectPurchaseMaster");
        }
    }
}
