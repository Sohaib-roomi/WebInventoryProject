namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MasterDetailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invDemandDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        demandId = c.Int(nullable: false),
                        itemId = c.Int(nullable: false),
                        unitId = c.Int(nullable: false),
                        qty = c.Single(nullable: false),
                        balance = c.Single(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        stock = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.settingItem", t => t.itemId, cascadeDelete: false)
                .ForeignKey("dbo.settingUnit", t => t.unitId, cascadeDelete: false)
                .Index(t => t.itemId)
                .Index(t => t.unitId);
            
            CreateTable(
                "dbo.invDemandMasters",
                c => new
                    {
                        demandId = c.Int(nullable: false),
                        demandDate = c.DateTime(nullable: false),
                        demandNo = c.String(),
                        branchId = c.Int(nullable: false),
                        departmentId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        modifiedBy = c.String(),
                        modifiedDate = c.DateTime(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        workStation = c.String(),
                        isPost = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.demandId)
                .ForeignKey("dbo.invDemandDetails", t => t.demandId)
                .ForeignKey("dbo.settingBranch", t => t.branchId, cascadeDelete: false)
                .ForeignKey("dbo.settingDepartment", t => t.departmentId, cascadeDelete: false)
                .Index(t => t.demandId)
                .Index(t => t.branchId)
                .Index(t => t.departmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invDemandMasters", "departmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invDemandMasters", "branchId", "dbo.settingBranch");
            DropForeignKey("dbo.invDemandMasters", "demandId", "dbo.invDemandDetails");
            DropForeignKey("dbo.invDemandDetails", "unitId", "dbo.settingUnit");
            DropForeignKey("dbo.invDemandDetails", "itemId", "dbo.settingItem");
            DropIndex("dbo.invDemandMasters", new[] { "departmentId" });
            DropIndex("dbo.invDemandMasters", new[] { "branchId" });
            DropIndex("dbo.invDemandMasters", new[] { "demandId" });
            DropIndex("dbo.invDemandDetails", new[] { "unitId" });
            DropIndex("dbo.invDemandDetails", new[] { "itemId" });
            DropTable("dbo.invDemandMasters");
            DropTable("dbo.invDemandDetails");
        }
    }
}
