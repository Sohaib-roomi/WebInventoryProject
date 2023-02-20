using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class invOpeningMasterDetailViewModel
    {
        public IEnumerable<invOpeningMaster> InvOpeningMasterList { get; set; }
        public IEnumerable<invOpeningDetail> InvOpeningDetailList { get; set; }
        public IEnumerable<settingBranch> settingBranches { get; set; }
        public settingBranch settingBr{ get; set; }
        public IEnumerable<settingDepartment> settingDepartments { get; set; }
        public settingDepartment settingDept { get; set; }
        public IEnumerable<settingItem> settingItems { get; set; }
        public IEnumerable<settingUnit> settingUnit { get; set; }
        public invOpeningMaster invOpeningMaster { get; set; }
        public invOpeningDetail invOpeningDetail { get; set; }

        public DateTime date { get; set; }

        public string UserType { get; set; }
    }
}