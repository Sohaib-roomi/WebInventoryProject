namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.settingItem",
                c => new
                    {
                        itemId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.itemId);
            
            CreateTable(
                "dbo.settingItemParlevel",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.settingUnits",
                c => new
                    {
                        unitId = c.Int(nullable: false, identity: true),
                        unitName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.unitId)
                .Index(t => t.unitName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.settingUnits", new[] { "unitName" });
            DropTable("dbo.settingUnits");
            DropTable("dbo.settingItemParlevel");
            DropTable("dbo.settingItem");
        }
    }
}
