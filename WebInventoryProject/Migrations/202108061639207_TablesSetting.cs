namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesSetting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.invDemandMasters", "demandId", "dbo.invDemandDetails");
            DropIndex("dbo.invDemandMasters", new[] { "demandId" });
            DropPrimaryKey("dbo.invDemandMasters");
            AlterColumn("dbo.invDemandMasters", "demandId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.invDemandMasters", "demandDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.invDemandMasters", "dateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.invDemandMasters", "modifiedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddPrimaryKey("dbo.invDemandMasters", "demandId");
            CreateIndex("dbo.invDemandDetails", "demandId");
            AddForeignKey("dbo.invDemandDetails", "demandId", "dbo.invDemandMasters", "demandId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invDemandDetails", "demandId", "dbo.invDemandMasters");
            DropIndex("dbo.invDemandDetails", new[] { "demandId" });
            DropPrimaryKey("dbo.invDemandMasters");
            AlterColumn("dbo.invDemandMasters", "modifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.invDemandMasters", "dateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.invDemandMasters", "demandDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.invDemandMasters", "demandId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.invDemandMasters", "demandId");
            CreateIndex("dbo.invDemandMasters", "demandId");
            AddForeignKey("dbo.invDemandMasters", "demandId", "dbo.invDemandDetails", "id");
        }
    }
}
