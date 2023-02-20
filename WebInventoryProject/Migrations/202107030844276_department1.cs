namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class department1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.settingDepartment",
                c => new
                    {
                        departmentId = c.Int(nullable: false, identity: true),
                        branchId = c.Int(nullable: false),
                        departmentCode = c.String(nullable: false, maxLength: 10),
                        departmentName = c.String(nullable: false, maxLength: 30),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.departmentId)
                .ForeignKey("dbo.settingBranch", t => t.branchId, cascadeDelete: true)
                .Index(t => t.branchId)
                .Index(t => t.departmentCode, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.settingDepartment", "branchId", "dbo.settingBranch");
            DropIndex("dbo.settingDepartment", new[] { "departmentCode" });
            DropIndex("dbo.settingDepartment", new[] { "branchId" });
            DropTable("dbo.settingDepartment");
        }
    }
}
