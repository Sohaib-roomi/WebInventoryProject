namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblItemParLevel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.settingItemParlevel",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        itemId = c.Int(nullable: false),
                        branchId = c.Int(nullable: false),
                        departmentId = c.Int(nullable: false),
                        min = c.Single(nullable: false),
                        max = c.Single(nullable: false),
                        balance = c.Single(nullable: false),
                        lastRate = c.Single(nullable: false),
                        avgRate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.settingBranch", t => t.branchId, cascadeDelete: false)
                .ForeignKey("dbo.settingDepartment", t => t.departmentId, cascadeDelete: false)
                .ForeignKey("dbo.settingItem", t => t.itemId, cascadeDelete: false)
                .Index(t => t.itemId)
                .Index(t => t.branchId)
                .Index(t => t.departmentId);
            
        }
        
        public override void Down()
        {
         
        }
    }
}
