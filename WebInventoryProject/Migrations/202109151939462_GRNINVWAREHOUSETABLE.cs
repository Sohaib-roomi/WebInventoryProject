namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GRNINVWAREHOUSETABLE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invGRNDetail",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    grnId = c.Int(nullable: false),
                    itemId = c.Int(nullable: false),
                    unitId = c.Int(nullable: false),
                    poId = c.Int(nullable: false),
                    qty = c.Single(nullable: false),
                    rate = c.Single(nullable: false),
                    tax = c.Single(nullable: false),
                    discount = c.Single(nullable: false),
                    actualRate = c.Single(nullable: false),
                    finalRate = c.Single(nullable: false),
                    expiryDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),

                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.invGRNMaster", t => t.grnId, cascadeDelete: false)
                .ForeignKey("dbo.invPurchaseOrderMasters", t => t.poId, cascadeDelete: false)
                .ForeignKey("dbo.settingItem", t => t.itemId, cascadeDelete: false)
                .ForeignKey("dbo.settingUnit", t => t.unitId, cascadeDelete: false)
                .Index(t => t.grnId)
                .Index(t => t.itemId)
                .Index(t => t.unitId)
                .Index(t => t.poId);


            CreateTable(
                "dbo.invGRNMaster",
                c => new
                {
                    grnId = c.Int(nullable: false, identity: true),
                    grnDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    grnNo = c.String(),
                    SPId = c.Int(nullable: false),
                    referenceNo = c.String(maxLength: 50),
                    desc = c.String(),
                    amount = c.Single(nullable: false),
                    discount = c.Single(nullable: false),
                    totalTax = c.Single(nullable: false),
                    totalAmount = c.Single(nullable: false),
                    userId = c.Int(nullable: false),
                    dateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    modifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    modifiedBy = c.Int(nullable: false),
                    extraCharges = c.Single(nullable: false),
                    workStation = c.String(),
                    isPost = c.Boolean(nullable: false),
                    branchId = c.Int(nullable: false),
                    departmentId = c.Int(nullable: false),
                    postUserId = c.Int(nullable: false),
                    postDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                })
                .PrimaryKey(t => t.grnId)
                .ForeignKey("dbo.loginUser", t => t.userId, cascadeDelete: false)
                .ForeignKey("dbo.settingBranch", t => t.branchId, cascadeDelete: false)
                .ForeignKey("dbo.settingDepartment", t => t.departmentId, cascadeDelete: false)
                .ForeignKey("dbo.Suppliers", t => t.SPId, cascadeDelete: false)
                .Index(t => t.SPId)
                .Index(t => t.userId)
                .Index(t => t.branchId)
                .Index(t => t.departmentId);

            CreateTable(
                "dbo.invWareHouse",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    itemId = c.Int(nullable: false),
                    unitId = c.Int(nullable: false),
                    VoucherId = c.Int(nullable: false),
                    qty = c.Single(nullable: false),
                    rate = c.Single(nullable: false),
                    Type = c.String(),
                    Desc = c.String(),
                    AvgRate = c.Single(nullable: false),
                    LastRate = c.Single(nullable: false),
                    ExpiryDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    VN = c.String(),
                    balance = c.Single(nullable: false),
                    amount = c.Single(nullable: false),
                    branchId = c.Int(nullable: false),
                    departmentId = c.Int(nullable: false),
                    dateTime = c.DateTime(nullable: false),
                    workStation = c.String(),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.settingBranch", t => t.branchId, cascadeDelete: false)
                .ForeignKey("dbo.settingDepartment", t => t.departmentId, cascadeDelete: false)
                .ForeignKey("dbo.settingItem", t => t.itemId, cascadeDelete: false)
                .ForeignKey("dbo.settingUnit", t => t.unitId, cascadeDelete: false)
                .Index(t => t.itemId)
                .Index(t => t.unitId)
                .Index(t => t.branchId)
                .Index(t => t.departmentId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.invWareHouse", "unitId", "dbo.settingUnit");
            DropForeignKey("dbo.invWareHouse", "itemId", "dbo.settingItem");
            DropForeignKey("dbo.invWareHouse", "departmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invWareHouse", "branchId", "dbo.settingBranch");
            DropForeignKey("dbo.invGRNDetail", "unitId", "dbo.settingUnit");
            DropForeignKey("dbo.invGRNDetail", "itemId", "dbo.settingItem");
            DropForeignKey("dbo.invGRNDetail", "departmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invGRNDetail", "poId", "dbo.invPurchaseOrderMasters");
            DropForeignKey("dbo.invGRNDetail", "grnId", "dbo.invGRNMaster");
            DropForeignKey("dbo.invGRNMaster", "SPId", "dbo.Suppliers");
            DropForeignKey("dbo.invGRNMaster", "departmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invGRNMaster", "branchId", "dbo.settingBranch");
            DropForeignKey("dbo.invGRNMaster", "userId", "dbo.loginUser");
            DropIndex("dbo.invWareHouse", new[] { "departmentId" });
            DropIndex("dbo.invWareHouse", new[] { "branchId" });
            DropIndex("dbo.invWareHouse", new[] { "unitId" });
            DropIndex("dbo.invWareHouse", new[] { "itemId" });
            DropIndex("dbo.invGRNMaster", new[] { "departmentId" });
            DropIndex("dbo.invGRNMaster", new[] { "branchId" });
            DropIndex("dbo.invGRNMaster", new[] { "userId" });
            DropIndex("dbo.invGRNMaster", new[] { "SPId" });
            DropIndex("dbo.invGRNDetail", new[] { "departmentId" });
            DropIndex("dbo.invGRNDetail", new[] { "poId" });
            DropIndex("dbo.invGRNDetail", new[] { "unitId" });
            DropIndex("dbo.invGRNDetail", new[] { "itemId" });
            DropIndex("dbo.invGRNDetail", new[] { "grnId" });
            DropTable("dbo.invWareHouse");
            DropTable("dbo.invGRNMaster");
            DropTable("dbo.invGRNDetail");
        }
    }
}
