using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class InvMasterDetailViewModel
    {
        public IEnumerable<invDemandMaster> InvDemandMasterList { get; set; }
        public IEnumerable<InvDemandMasterDetail> InvDemandMasterDetail { get; set; }
        public IEnumerable<invDemandDetail> InvDemandDetailList { get; set; }
        public IEnumerable<settingBranch> settingBranches { get; set; }
        public settingBranch settingBr { get; set; }
        public IEnumerable<settingDepartment> settingDepartments { get; set; }
        public settingDepartment settingDept { get; set; }
        public IEnumerable<settingItem> settingItems { get; set; }
        public IEnumerable<settingUnit> settingUnit { get; set; }
        public invDemandMaster invDemandMaster { get; set; }
        public invDemandDetail InvDemandDetail { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public DateTime demandDate { get; set; }
        public string code { get; set; }
        public List<DemandList> DemandLists { get; set; }
        public class DemandList //created sub class in main class to pass the data to it
        {
            public int ItemId { get; set; }
            public int unitId { get; set; }
            public string ItemName { get; set; }
            public string unitName { get; set; }
            public int qty { get; set; }
            public int Rate { get; set; }
        }
    }
    public class InvDemandMasterDetail
    {
        public int demand_Id { get; set; }
        public DateTime demandDate { get; set; }
        public string demandNo { get; set; }
        public int branchId { get; set; }
        public int departmentId { get; set; }
        public int userId { get; set; }
        public DateTime dateTime { get; set; }
        public string modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public bool isActive { get; set; }
        public string workStation { get; set; }
        public bool isPost { get; set; }
        public IEnumerable<settingBranch> settingBranches { get; set; }
        public IEnumerable<settingDepartment> settingDepartments { get; set; }
        public int id { get; set; }
        public int itemId { get; set; }
        public int unitId { get; set; }
        public float qty { get; set; }
        public float balance { get; set; }
        public float stock { get; set; }
        public string departmentName { get; set; }
        public string branchName { get; set; }
        public string itemName { get; set; }
        public string unitName { get; set; }


        public IEnumerable<settingItem> settingItems { get; set; }
        public IEnumerable<settingUnit> settingUnit { get; set; }

       

    }
}