using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class invDirectPurchaseMasterDetailViewModel
    {
        public IEnumerable<invDirectPurchaseMaster> InvDirectPurchaseMasterList { get; set; }
        public IEnumerable<invDirectPurchaseDetail> InvDirectPurchaseDetailList { get; set; }
        public IEnumerable<settingBranch> settingBranches { get; set; }
        public settingBranch settingBr { get; set; }
        public IEnumerable<settingDepartment> settingDepartments { get; set; }
        public settingDepartment settingDept { get; set; }
        public IEnumerable<settingItem> settingItems { get; set; }
        public IEnumerable<settingUnit> settingUnit { get; set; }
        public invDirectPurchaseMaster invDirectPurchaseMaster { get; set; }
        public invDirectPurchaseDetail invDirectPurchaseDetail { get; set; }
        public DateTime directPurchaseDate { get; set; }
        public string UserType { get; set; }
    }
}