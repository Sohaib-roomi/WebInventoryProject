namespace WebInventoryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingDeptandBranch : DbMigration
    {
        public override void Up()
        {
            Sql("insert into settingBranch(branchCode,branchName,isHeadOfficeBranch,isActive)values(001,'Defence',1,1)");
            Sql("insert into settingDepartment(branchId,departmentCode,departmentName,isActive)values(1,001,'Kitchen',1)");
        }
        
        public override void Down()
        {
        }
    }
}
