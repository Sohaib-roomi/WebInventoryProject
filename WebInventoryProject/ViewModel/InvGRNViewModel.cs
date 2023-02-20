using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class InvGRNViewModel
    {
        public IEnumerable<InvGRNViewModel> invGRNViewModels { get; set; }
        public IEnumerable<invGRNMaster> invGRNMasterList { get; set; }
        public IEnumerable<invGRNDetail> invGRNDetailList { get; set; }
        public IEnumerable<invPurchaseOrderMaster> invPurchaseOrderMasterList { get; set; }
        public invPurchaseOrderMaster invPurchaseOrderMaster { get; set; }
        public IEnumerable<settingBranch> settingBranches { get; set; }
        public settingBranch settingBr { get; set; }
        public IEnumerable<settingDepartment> settingDepartments { get; set; }
        public settingDepartment settingDept { get; set; }
        public IEnumerable<Supplier> Supplier { get; set; }
        public IEnumerable<settingItem> settingItems { get; set; }        
        public IEnumerable<settingUnit> settingUnit { get; set; }       
        public invGRNMaster invGRNMaster { get; set; }
        public invGRNDetail invGRNDetail{ get; set; }

        public string UserType { get; set; }

        public string code { get; set; }

        public DateTime grnDate { get; set; }
        public int poId { get; set; }
        public int itemId { get; set; }            
        public string itemName { get; set; }      
        public int unitId { get; set; }
        public int departmentId { get; set; }
        public string unitName { get; set; }
        public string departmentName { get; set; }
        public float qty { get; set; }
        public float rate { get; set; }
        public float discount { get; set; }
        public float tax { get; set; }
        public float actualRate { get; set; }
        public float finalRate { get; set; }
    }
}