namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablePKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.invDemandDetails", "demandId", "dbo.invDemandMasters");
            RenameColumn(table: "dbo.invDemandDetails", name: "demandId", newName: "demand_Id");
            RenameIndex(table: "dbo.invDemandDetails", name: "IX_demandId", newName: "IX_demand_Id");
            DropPrimaryKey("dbo.invDemandMasters");
            AddColumn("dbo.invDemandMasters", "demand_Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.invDemandMasters", "demand_Id");
            AddForeignKey("dbo.invDemandDetails", "demand_Id", "dbo.invDemandMasters", "demand_Id", cascadeDelete: true);
            DropColumn("dbo.invDemandMasters", "demandId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.invDemandMasters", "demandId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.invDemandDetails", "demand_Id", "dbo.invDemandMasters");
            DropPrimaryKey("dbo.invDemandMasters");
            DropColumn("dbo.invDemandMasters", "demand_Id");
            AddPrimaryKey("dbo.invDemandMasters", "demandId");
            RenameIndex(table: "dbo.invDemandDetails", name: "IX_demand_Id", newName: "IX_demandId");
            RenameColumn(table: "dbo.invDemandDetails", name: "demand_Id", newName: "demandId");
            AddForeignKey("dbo.invDemandDetails", "demandId", "dbo.invDemandMasters", "demandId", cascadeDelete: true);
        }
    }
}
