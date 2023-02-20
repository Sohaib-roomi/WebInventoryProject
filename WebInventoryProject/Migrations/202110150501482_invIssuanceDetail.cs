namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invIssuanceDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invIssuanceDetail",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        issuanceId = c.Int(nullable: false),
                        itemId = c.Int(nullable: false),
                        unitId = c.Int(nullable: false),
                        qty = c.Single(nullable: false),
                        rate = c.Single(nullable: false),
                        demandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.invIssuanceMaster", t => t.issuanceId, cascadeDelete: false)
                .ForeignKey("dbo.settingItem", t => t.itemId, cascadeDelete: false)
                .ForeignKey("dbo.settingUnit", t => t.unitId, cascadeDelete: false)
                .Index(t => t.issuanceId)
                .Index(t => t.itemId)
                .Index(t => t.unitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invIssuanceDetail", "unitId", "dbo.settingUnit");
            DropForeignKey("dbo.invIssuanceDetail", "itemId", "dbo.settingItem");
            DropForeignKey("dbo.invIssuanceDetail", "issuanceId", "dbo.invIssuanceMaster");
            DropIndex("dbo.invIssuanceDetail", new[] { "unitId" });
            DropIndex("dbo.invIssuanceDetail", new[] { "itemId" });
            DropIndex("dbo.invIssuanceDetail", new[] { "issuanceId" });
            DropTable("dbo.invIssuanceDetail");
        }
    }
}
