namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TblItem : DbMigration
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
            AddColumn("dbo.settingItem", "subcategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.settingItem", "itemCode", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.settingItem", "itemName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.settingItem", "purchaseUnitId", c => c.Int(nullable: false));
            AddColumn("dbo.settingItem", "issuanceUnitId", c => c.Int(nullable: false));
            AddColumn("dbo.settingItem", "recipeUnitId", c => c.Int(nullable: false));
            AddColumn("dbo.settingItem", "purchaseIssuanceConv", c => c.Single(nullable: false));
            AddColumn("dbo.settingItem", "issuanceRecipeConv", c => c.Single(nullable: false));
            AddColumn("dbo.settingItem", "isActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.settingItem", "dateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.settingItem", "itemType", c => c.String());
            CreateIndex("dbo.settingItem", "subcategoryId");
            CreateIndex("dbo.settingItem", "itemCode", unique: true);
            CreateIndex("dbo.settingItem", "purchaseUnitId");
            CreateIndex("dbo.settingItem", "issuanceUnitId");
            CreateIndex("dbo.settingItem", "recipeUnitId");
            AddForeignKey("dbo.settingItem", "issuanceUnitId", "dbo.settingUnit", "unitId", cascadeDelete: false);
            AddForeignKey("dbo.settingItem", "subcategoryId", "dbo.settingSubcategory", "subcategoryId", cascadeDelete: false);
            AddForeignKey("dbo.settingItem", "recipeUnitId", "dbo.settingUnit", "unitId", cascadeDelete: false);
            AddForeignKey("dbo.settingItem", "purchaseUnitId", "dbo.settingUnit", "unitId", cascadeDelete: false);
 
        }
        
        public override void Down()
        {
           
            //CreateTable(
            //    "dbo.settingItemParlevel",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //DropForeignKey("dbo.settingItem", "purchaseUnitId", "dbo.settingUnit");
            //DropForeignKey("dbo.settingItem", "recipeUnitId", "dbo.settingUnit");
            //DropForeignKey("dbo.settingItem", "subcategoryId", "dbo.settingSubcategory");
            //DropForeignKey("dbo.settingItem", "issuanceUnitId", "dbo.settingUnit");
            //DropIndex("dbo.settingItem", new[] { "recipeUnitId" });
            //DropIndex("dbo.settingItem", new[] { "issuanceUnitId" });
            //DropIndex("dbo.settingItem", new[] { "purchaseUnitId" });
            //DropIndex("dbo.settingItem", new[] { "itemCode" });
            //DropIndex("dbo.settingItem", new[] { "subcategoryId" });
            //DropColumn("dbo.settingItem", "itemType");
            //DropColumn("dbo.settingItem", "dateAdded");
            //DropColumn("dbo.settingItem", "isActive");
            //DropColumn("dbo.settingItem", "issuanceRecipeConv");
            //DropColumn("dbo.settingItem", "purchaseIssuanceConv");
            //DropColumn("dbo.settingItem", "recipeUnitId");
            //DropColumn("dbo.settingItem", "issuanceUnitId");
            //DropColumn("dbo.settingItem", "purchaseUnitId");
            //DropColumn("dbo.settingItem", "itemName");
            //DropColumn("dbo.settingItem", "itemCode");
            //DropColumn("dbo.settingItem", "subcategoryId");
        
        }
    }
}
