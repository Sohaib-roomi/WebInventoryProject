namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unit1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.settingUnit", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.settingUnit", "isActive");
        }
    }
}
