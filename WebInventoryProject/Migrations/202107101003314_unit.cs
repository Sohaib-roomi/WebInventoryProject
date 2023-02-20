namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unit : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.settingUnits", newName: "settingUnit");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.settingUnit", newName: "settingUnits");
        }
    }
}
