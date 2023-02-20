namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invDiscardDetailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invDiscardDetail",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        discardId = c.Int(nullable: false),
                        itemId = c.Int(nullable: false),
                        qty = c.Single(nullable: false),
                        desc = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.invDiscardMaster", t => t.discardId, cascadeDelete: false)
                .ForeignKey("dbo.settingItem", t => t.itemId, cascadeDelete: false)
                .Index(t => t.discardId)
                .Index(t => t.itemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invDiscardDetail", "itemId", "dbo.settingItem");
            DropForeignKey("dbo.invDiscardDetail", "discardId", "dbo.invDiscardMaster");
            DropIndex("dbo.invDiscardDetail", new[] { "itemId" });
            DropIndex("dbo.invDiscardDetail", new[] { "discardId" });
            DropTable("dbo.invDiscardDetail");
        }
    }
}
