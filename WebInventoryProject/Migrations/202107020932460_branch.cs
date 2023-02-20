namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class branch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.settingBranch",
                c => new
                    {
                        branchId = c.Int(nullable: false, identity: true),
                        branchCode = c.String(nullable: false, maxLength: 10),
                        branchName = c.String(nullable: false, maxLength: 30),
                        isHeadOfficeBranch = c.Boolean(nullable: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.branchId)
                .Index(t => t.branchCode, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.settingBranch", new[] { "branchCode" });
            DropTable("dbo.settingBranch");
        }
    }
}
