namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableInvTransferDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invTransferDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        trId = c.Int(nullable: false),
                        itemId = c.Int(nullable: false),
                        unitId = c.Int(nullable: false),
                        qty = c.Single(nullable: false),
                        rate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.invTransferMaster", t => t.trId, cascadeDelete: true)
                .ForeignKey("dbo.settingItem", t => t.itemId, cascadeDelete: true)
                .ForeignKey("dbo.settingUnit", t => t.unitId, cascadeDelete: true)
                .Index(t => t.trId)
                .Index(t => t.itemId)
                .Index(t => t.unitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invTransferDetails", "unitId", "dbo.settingUnit");
            DropForeignKey("dbo.invTransferDetails", "itemId", "dbo.settingItem");
            DropForeignKey("dbo.invTransferDetails", "trId", "dbo.invTransferMaster");
            DropIndex("dbo.invTransferDetails", new[] { "unitId" });
            DropIndex("dbo.invTransferDetails", new[] { "itemId" });
            DropIndex("dbo.invTransferDetails", new[] { "trId" });
            DropTable("dbo.invTransferDetails");
        }
    }
}
