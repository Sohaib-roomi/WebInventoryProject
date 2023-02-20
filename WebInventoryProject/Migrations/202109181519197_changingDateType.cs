namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingDateType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.invTransferMaster", "postDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.invTransferMaster", "trDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.invTransferMaster", "dateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.invTransferMaster", "modifiedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.invTransferMaster", "postDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.invTransferMaster", "trDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.invTransferMaster", "dateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.invTransferMaster", "modifiedDate", c => c.DateTime(nullable: false));
        }
    }
}
