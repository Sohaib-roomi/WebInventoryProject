using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class invPhysicalStockMasterDetailViewModel
    {
        

        public IEnumerable<invPhysicalStockMaster> InvOpeningMasterList { get; set; }
        public IEnumerable<invPhysicalStockDetail> InvOpeningDetailList { get; set; }
        public IEnumerable<settingBranch> settingBranches { get; set; }
        public settingBranch settingBr { get; set; }
        public IEnumerable<settingDepartment> settingDepartments { get; set; }
        public settingDepartment settingDept { get; set; }
        public IEnumerable<settingItem> settingItems { get; set; }
        public IEnumerable<settingUnit> settingUnit { get; set; }
        public invPhysicalStockMaster invPhysicalStockMaster { get; set; }
        public invPhysicalStockDetail invPhysicalStockDetail { get; set; }
        public string UserType { get; internal set; }
        public DateTime psDate { get; set; }
    }
}