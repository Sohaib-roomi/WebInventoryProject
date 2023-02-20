using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class InvTransferMasterDetailViewModel
    {
        public IEnumerable<invTransferMaster> InvDemandMasterList { get; set; }
        public IEnumerable<invTransferDetail> InvDemandDetailList { get; set; }
        public IEnumerable<settingBranch> settingBranches { get; set; }
        public settingBranch settingBr { get; set; }
        public IEnumerable<settingDepartment> settingDepartments { get; set; }
        public settingDepartment settingDept { get; set; }
        public IEnumerable<settingItem> settingItems { get; set; }
        public IEnumerable<settingUnit> settingUnit { get; set; }
        public invTransferMaster invTransferMaster { get; set; }
        public invTransferDetail invTransferDetail { get; set; }
        public string UserType { get; set; }

        public string code { get; set; }
        public DateTime date { get; set; }
    }
}