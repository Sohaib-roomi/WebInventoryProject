namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invPhysicalStockMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invPhysicalStockMaster",
                c => new
                    {
                        psId = c.Int(nullable: false, identity: true),
                        psDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        psNo = c.String(),
                        BranchId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        modifiedBy = c.Int(nullable: false),
                        modifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        workStation = c.String(),
                        isPost = c.Boolean(nullable: false),
                        postUserId = c.Int(nullable: false),
                        postDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.psId)
                .ForeignKey("dbo.loginUser", t => t.userId, cascadeDelete: false)
                .ForeignKey("dbo.loginUser", t => t.modifiedBy, cascadeDelete: false)
                .ForeignKey("dbo.settingBranch", t => t.BranchId, cascadeDelete: false)
                .ForeignKey("dbo.settingDepartment", t => t.DepartmentId, cascadeDelete: false)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId)
                .Index(t => t.userId)
                .Index(t => t.modifiedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invPhysicalStockMaster", "DepartmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invPhysicalStockMaster", "BranchId", "dbo.settingBranch");
            DropForeignKey("dbo.invPhysicalStockMaster", "modifiedBy", "dbo.loginUser");
            DropForeignKey("dbo.invPhysicalStockMaster", "userId", "dbo.loginUser");
            DropIndex("dbo.invPhysicalStockMaster", new[] { "modifiedBy" });
            DropIndex("dbo.invPhysicalStockMaster", new[] { "userId" });
            DropIndex("dbo.invPhysicalStockMaster", new[] { "DepartmentId" });
            DropIndex("dbo.invPhysicalStockMaster", new[] { "BranchId" });
            DropTable("dbo.invPhysicalStockMaster");
        }
    }
}
