namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invPhysicalStockDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invPhysicalStockDetail",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        psId = c.Int(nullable: false),
                        itemId = c.Int(nullable: false),
                        unitId = c.Int(nullable: false),
                        qty = c.Single(nullable: false),
                        rate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.invPhysicalStockMaster", t => t.psId, cascadeDelete: true)
                .ForeignKey("dbo.settingItem", t => t.itemId, cascadeDelete: true)
                .ForeignKey("dbo.settingUnit", t => t.unitId, cascadeDelete: true)
                .Index(t => t.psId)
                .Index(t => t.itemId)
                .Index(t => t.unitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invPhysicalStockDetail", "unitId", "dbo.settingUnit");
            DropForeignKey("dbo.invPhysicalStockDetail", "itemId", "dbo.settingItem");
            DropForeignKey("dbo.invPhysicalStockDetail", "psId", "dbo.invPhysicalStockMaster");
            DropIndex("dbo.invPhysicalStockDetail", new[] { "unitId" });
            DropIndex("dbo.invPhysicalStockDetail", new[] { "itemId" });
            DropIndex("dbo.invPhysicalStockDetail", new[] { "psId" });
            DropTable("dbo.invPhysicalStockDetail");
        }
    }
}
