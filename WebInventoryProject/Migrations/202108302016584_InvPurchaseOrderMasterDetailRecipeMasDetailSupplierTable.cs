namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvPurchaseOrderMasterDetailRecipeMasDetailSupplierTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invPurchaseOrderDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        poId = c.Int(nullable: false),
                        itemId = c.Int(nullable: false),
                        unitId = c.Int(nullable: false),
                        qty = c.Single(nullable: false),
                        rate = c.Single(nullable: false),
                        grnQty = c.Single(nullable: false),
                        demandId = c.Int(nullable: false),
                        status = c.Boolean(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        stock = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.invPurchaseOrderMasters", t => t.poId, cascadeDelete: true)
                .ForeignKey("dbo.settingItem", t => t.itemId, cascadeDelete: false)
                .ForeignKey("dbo.settingUnit", t => t.unitId, cascadeDelete: false)
                .Index(t => t.poId)
                .Index(t => t.itemId)
                .Index(t => t.unitId);
            
            CreateTable(
                "dbo.invPurchaseOrderMasters",
                c => new
                    {
                        poId = c.Int(nullable: false, identity: true),
                        poDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        poNo = c.String(),
                        desc = c.String(),
                        SPId = c.Int(nullable: false),
                        totalAmount = c.Single(nullable: false),
                        userId = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        status = c.Boolean(nullable: false),
                        modifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        modifiedBy = c.Int(nullable: false),
                        branchId = c.Int(nullable: false),
                        departmentId = c.Int(nullable: false),
                        workStation = c.String(),
                        isPost = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.poId)
                .ForeignKey("dbo.settingBranch", t => t.branchId, cascadeDelete: false)
                .ForeignKey("dbo.settingDepartment", t => t.departmentId, cascadeDelete: false)
                .ForeignKey("dbo.Suppliers", t => t.SPId, cascadeDelete: false)
                .Index(t => t.SPId)
                .Index(t => t.branchId)
                .Index(t => t.departmentId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SPId = c.Int(nullable: false, identity: true),
                        Vendor = c.String(),
                        VendorCode = c.String(),
                        Address = c.String(),
                        CellNo = c.String(),
                        CAId = c.Int(nullable: false),
                        COId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SPId);
            
            CreateTable(
                "dbo.invRecipeDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        DineIn = c.Boolean(nullable: false),
                        TakeAway = c.Boolean(nullable: false),
                        Delivery = c.Boolean(nullable: false),
                        Workstation = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.invRecipeMaster", t => t.RecipeId, cascadeDelete: false)
                .ForeignKey("dbo.settingItem", t => t.IngredientId, cascadeDelete: false)
                .Index(t => t.RecipeId)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.invRecipeMaster",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Comments = c.String(),
                        Workstation = c.String(),
                        isSubRecipe = c.Boolean(nullable: false),
                        userId = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        modifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        modifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invRecipeDetails", "IngredientId", "dbo.settingItem");
            DropForeignKey("dbo.invRecipeDetails", "RecipeId", "dbo.invRecipeMaster");
            DropForeignKey("dbo.invPurchaseOrderDetails", "unitId", "dbo.settingUnit");
            DropForeignKey("dbo.invPurchaseOrderDetails", "itemId", "dbo.settingItem");
            DropForeignKey("dbo.invPurchaseOrderDetails", "poId", "dbo.invPurchaseOrderMasters");
            DropForeignKey("dbo.invPurchaseOrderMasters", "SPId", "dbo.Suppliers");
            DropForeignKey("dbo.invPurchaseOrderMasters", "departmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invPurchaseOrderMasters", "branchId", "dbo.settingBranch");
            DropIndex("dbo.invRecipeDetails", new[] { "IngredientId" });
            DropIndex("dbo.invRecipeDetails", new[] { "RecipeId" });
            DropIndex("dbo.invPurchaseOrderMasters", new[] { "departmentId" });
            DropIndex("dbo.invPurchaseOrderMasters", new[] { "branchId" });
            DropIndex("dbo.invPurchaseOrderMasters", new[] { "SPId" });
            DropIndex("dbo.invPurchaseOrderDetails", new[] { "unitId" });
            DropIndex("dbo.invPurchaseOrderDetails", new[] { "itemId" });
            DropIndex("dbo.invPurchaseOrderDetails", new[] { "poId" });
            DropTable("dbo.invRecipeMaster");
            DropTable("dbo.invRecipeDetails");
            DropTable("dbo.Suppliers");
            DropTable("dbo.invPurchaseOrderMasters");
            DropTable("dbo.invPurchaseOrderDetails");
        }
    }
}
