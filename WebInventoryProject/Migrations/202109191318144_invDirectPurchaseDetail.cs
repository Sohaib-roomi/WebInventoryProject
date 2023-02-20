namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invDirectPurchaseDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invDirectPurchaseDetail",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        directPurchaseId = c.Int(nullable: false),
                        itemId = c.Int(nullable: false),
                        unitId = c.Int(nullable: false),
                        qty = c.Single(nullable: false),
                        rate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.invDirectPurchaseMaster", t => t.directPurchaseId, cascadeDelete: true)
                .ForeignKey("dbo.settingItem", t => t.itemId, cascadeDelete: true)
                .ForeignKey("dbo.settingUnit", t => t.unitId, cascadeDelete: true)
                .Index(t => t.directPurchaseId)
                .Index(t => t.itemId)
                .Index(t => t.unitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invDirectPurchaseDetail", "unitId", "dbo.settingUnit");
            DropForeignKey("dbo.invDirectPurchaseDetail", "itemId", "dbo.settingItem");
            DropForeignKey("dbo.invDirectPurchaseDetail", "directPurchaseId", "dbo.invDirectPurchaseMaster");
            DropIndex("dbo.invDirectPurchaseDetail", new[] { "unitId" });
            DropIndex("dbo.invDirectPurchaseDetail", new[] { "itemId" });
            DropIndex("dbo.invDirectPurchaseDetail", new[] { "directPurchaseId" });
            DropTable("dbo.invDirectPurchaseDetail");
        }
    }
}
