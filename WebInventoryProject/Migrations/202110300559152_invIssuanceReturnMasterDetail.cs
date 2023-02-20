namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invIssuanceReturnMasterDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invIssuanceReturnDetail",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        issuanceReturnId = c.Int(nullable: false),
                        itemId = c.Int(nullable: false),
                        unitId = c.Int(nullable: false),
                        qty = c.Single(nullable: false),
                        rate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.invIssuanceReturnMaster", t => t.issuanceReturnId, cascadeDelete: false)
                .ForeignKey("dbo.settingItem", t => t.itemId, cascadeDelete: false)
                .ForeignKey("dbo.settingUnit", t => t.unitId, cascadeDelete: false)
                .Index(t => t.issuanceReturnId)
                .Index(t => t.itemId)
                .Index(t => t.unitId);
            
            CreateTable(
                "dbo.invIssuanceReturnMaster",
                c => new
                    {
                        issuanceReturnId = c.Int(nullable: false, identity: true),
                        issuanceReturnDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        issuanceReturnNo = c.String(),
                        branchId = c.Int(nullable: false),
                        departmentId = c.Int(nullable: false),
                        issuanceId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        modifiedBy = c.Int(nullable: false),
                        modifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        workStation = c.String(),
                        isPost = c.Boolean(nullable: false),
                        postUserId = c.Int(nullable: false),
                        postDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.issuanceReturnId)
                .ForeignKey("dbo.invIssuanceMaster", t => t.issuanceId, cascadeDelete: false)
                .ForeignKey("dbo.loginUser", t => t.userId, cascadeDelete: false)
                .ForeignKey("dbo.loginUser", t => t.postUserId, cascadeDelete: false)
                .ForeignKey("dbo.loginUser", t => t.modifiedBy, cascadeDelete: false)
                .ForeignKey("dbo.settingBranch", t => t.branchId, cascadeDelete: false)
                .ForeignKey("dbo.settingDepartment", t => t.departmentId, cascadeDelete: false)
                .Index(t => t.branchId)
                .Index(t => t.departmentId)
                .Index(t => t.issuanceId)
                .Index(t => t.userId)
                .Index(t => t.modifiedBy)
                .Index(t => t.postUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invIssuanceReturnDetail", "unitId", "dbo.settingUnit");
            DropForeignKey("dbo.invIssuanceReturnDetail", "itemId", "dbo.settingItem");
            DropForeignKey("dbo.invIssuanceReturnDetail", "issuanceReturnId", "dbo.invIssuanceReturnMaster");
            DropForeignKey("dbo.invIssuanceReturnMaster", "departmentId", "dbo.settingDepartment");
            DropForeignKey("dbo.invIssuanceReturnMaster", "branchId", "dbo.settingBranch");
            DropForeignKey("dbo.invIssuanceReturnMaster", "modifiedBy", "dbo.loginUser");
            DropForeignKey("dbo.invIssuanceReturnMaster", "postUserId", "dbo.loginUser");
            DropForeignKey("dbo.invIssuanceReturnMaster", "userId", "dbo.loginUser");
            DropForeignKey("dbo.invIssuanceReturnMaster", "issuanceId", "dbo.invIssuanceMaster");
            DropIndex("dbo.invIssuanceReturnMaster", new[] { "postUserId" });
            DropIndex("dbo.invIssuanceReturnMaster", new[] { "modifiedBy" });
            DropIndex("dbo.invIssuanceReturnMaster", new[] { "userId" });
            DropIndex("dbo.invIssuanceReturnMaster", new[] { "issuanceId" });
            DropIndex("dbo.invIssuanceReturnMaster", new[] { "departmentId" });
            DropIndex("dbo.invIssuanceReturnMaster", new[] { "branchId" });
            DropIndex("dbo.invIssuanceReturnDetail", new[] { "unitId" });
            DropIndex("dbo.invIssuanceReturnDetail", new[] { "itemId" });
            DropIndex("dbo.invIssuanceReturnDetail", new[] { "issuanceReturnId" });
            DropTable("dbo.invIssuanceReturnMaster");
            DropTable("dbo.invIssuanceReturnDetail");
        }
    }
}
