namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableInvOpeningMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invOpeningMaster",
                c => new
                    {
                        openInvId = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BranchId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        isPost = c.Boolean(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        modifiedBy = c.Int(nullable: false),
                        modifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        workStation = c.String(),
                    })
                .PrimaryKey(t => t.openInvId)
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
            DropForeignKey("dbo.invOpeningMaster", "DepartmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invOpeningMaster", "BranchId", "dbo.settingBranch");
            DropForeignKey("dbo.invOpeningMaster", "modifiedBy", "dbo.loginUser");
            DropForeignKey("dbo.invOpeningMaster", "userId", "dbo.loginUser");
            DropIndex("dbo.invOpeningMaster", new[] { "modifiedBy" });
            DropIndex("dbo.invOpeningMaster", new[] { "userId" });
            DropIndex("dbo.invOpeningMaster", new[] { "DepartmentId" });
            DropIndex("dbo.invOpeningMaster", new[] { "BranchId" });
            DropTable("dbo.invOpeningMaster");
        }
    }
}
