namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invWastageDetailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invWastageDetail",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        wastageId = c.Int(nullable: false),
                        itemId = c.Int(nullable: false),
                        unitId = c.Int(nullable: false),
                        qty = c.Single(nullable: false),
                        rate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.invWastageMaster", t => t.wastageId, cascadeDelete: false)
                .ForeignKey("dbo.settingItem", t => t.itemId, cascadeDelete: false)
                .ForeignKey("dbo.settingUnit", t => t.unitId, cascadeDelete: false)
                .Index(t => t.wastageId)
                .Index(t => t.itemId)
                .Index(t => t.unitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invWastageDetail", "unitId", "dbo.settingUnit");
            DropForeignKey("dbo.invWastageDetail", "itemId", "dbo.settingItem");
            DropForeignKey("dbo.invWastageDetail", "wastageId", "dbo.invWastageMaster");
            DropIndex("dbo.invWastageDetail", new[] { "unitId" });
            DropIndex("dbo.invWastageDetail", new[] { "itemId" });
            DropIndex("dbo.invWastageDetail", new[] { "wastageId" });
            DropTable("dbo.invWastageDetail");
        }
    }
}
