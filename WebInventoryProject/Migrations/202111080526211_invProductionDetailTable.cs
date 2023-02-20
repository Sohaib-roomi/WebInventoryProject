namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invProductionDetailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invProductionDetail",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        prId = c.Int(nullable: false),
                        itemId = c.Int(nullable: false),
                        unitId = c.Int(nullable: false),
                        qty = c.Single(nullable: false),
                        rate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.invProductionMaster", t => t.prId, cascadeDelete: false)
                .ForeignKey("dbo.settingItem", t => t.itemId, cascadeDelete: false)
                .ForeignKey("dbo.settingUnit", t => t.unitId, cascadeDelete: false)
                .Index(t => t.prId)
                .Index(t => t.itemId)
                .Index(t => t.unitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invProductionDetail", "unitId", "dbo.settingUnit");
            DropForeignKey("dbo.invProductionDetail", "itemId", "dbo.settingItem");
            DropForeignKey("dbo.invProductionDetail", "prId", "dbo.invProductionMaster");
            DropIndex("dbo.invProductionDetail", new[] { "unitId" });
            DropIndex("dbo.invProductionDetail", new[] { "itemId" });
            DropIndex("dbo.invProductionDetail", new[] { "prId" });
            DropTable("dbo.invProductionDetail");
        }
    }
}
