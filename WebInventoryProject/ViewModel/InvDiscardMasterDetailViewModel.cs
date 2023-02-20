using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class InvDiscardMasterDetailViewModel
    {
        public IEnumerable<settingItem> settingItem { get; set; }
        public IEnumerable<settingBranch> settingBranch { get; set; }
        public settingBranch settingBr { get; set; }
        public IEnumerable<settingDepartment> settingDepartment { get; set; }
        public settingDepartment settingDept { get; set; }
        public IEnumerable<invDiscardMaster> invDiscardMasterList { get; set; }
        public IEnumerable<invDiscardDetail> invDiscardDetailList { get; set; }
        public invDiscardMaster invDiscardMaster { get; set; }
        public invDiscardDetail invDiscardDetail { get; set; }
        public string UserType { get; set; }
        public DateTime discardDate { get; set; }
    }
}