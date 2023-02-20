using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class InvPurchaseOrderViewModel
    {
        

        public IEnumerable<invPurchaseOrderMaster> PurchaseOrderMasterList { get; set; }
        public IEnumerable<invPurchaseOrderDetail> PurchaseOrderDetailList { get; set; }
        public IEnumerable<settingBranch> settingBranches { get; set; }      
        public settingBranch settingBr { get; set; }      
        public IEnumerable<settingDepartment> settingDepartments { get; set; }
        public settingDepartment settingDept { get; set; }
        public IEnumerable<Supplier> Supplier { get; set; }
        public IEnumerable<settingItem> settingItems { get; set; }
        public IEnumerable<settingUnit> settingUnit { get; set; }
        public invPurchaseOrderMaster invPurchaseOrderMaster { get; set; }
        public invPurchaseOrderDetail invPurchaseOrderDetail { get; set; }
        public string UserType { get; internal set; }

        public string code { get; set; }
        public DateTime poDate { get; set; }
    }
}