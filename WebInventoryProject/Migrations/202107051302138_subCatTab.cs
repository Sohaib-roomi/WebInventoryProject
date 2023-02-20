namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subCatTab : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.settingSubcategory",
                c => new
                    {
                        subcategoryId = c.Int(nullable: false, identity: true),
                        categoryId = c.Int(nullable: false),
                        subcategoryCode = c.String(nullable: false),
                        subcategoryName = c.String(nullable: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.subcategoryId)
                .ForeignKey("dbo.settingCategory", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.categoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.settingSubcategory", "categoryId", "dbo.settingCategory");
            DropIndex("dbo.settingSubcategory", new[] { "categoryId" });
            DropTable("dbo.settingSubcategory");
        }
    }
}
