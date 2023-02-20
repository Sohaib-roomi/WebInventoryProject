namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableInvOpeningDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invOpeningDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        openInvId = c.Int(nullable: false),
                        itemId = c.Int(nullable: false),
                        unitId = c.Int(nullable: false),
                        qty = c.Single(nullable: false),
                        rate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.invOpeningMaster", t => t.openInvId, cascadeDelete: true)
                .ForeignKey("dbo.settingItem", t => t.itemId, cascadeDelete: true)
                .ForeignKey("dbo.settingUnit", t => t.unitId, cascadeDelete: true)
                .Index(t => t.openInvId)
                .Index(t => t.itemId)
                .Index(t => t.unitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invOpeningDetails", "unitId", "dbo.settingUnit");
            DropForeignKey("dbo.invOpeningDetails", "itemId", "dbo.settingItem");
            DropForeignKey("dbo.invOpeningDetails", "openInvId", "dbo.invOpeningMaster");
            DropIndex("dbo.invOpeningDetails", new[] { "unitId" });
            DropIndex("dbo.invOpeningDetails", new[] { "itemId" });
            DropIndex("dbo.invOpeningDetails", new[] { "openInvId" });
            DropTable("dbo.invOpeningDetails");
        }
    }
}
