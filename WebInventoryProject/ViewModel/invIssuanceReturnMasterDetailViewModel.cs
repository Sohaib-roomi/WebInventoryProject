using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Migrations;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class invIssuanceReturnMasterDetailViewModel
    {
        public IEnumerable<invIssuanceReturnMaster> invIssuanceReturnMasterList { get; set; }
        public IEnumerable<invIssuanceReturnDetail> invIssuanceReturnDetailList { get; set; }
        public IEnumerable<settingBranch> settingBranches { get; set; }
        public IEnumerable<settingDepartment> settingDepartments { get; set; }
        public IEnumerable<WebInventoryProject.Models.invIssuanceMaster> invIssuanceMaster { get; set; }
        public IEnumerable<settingItem> settingItems { get; set; }
        public IEnumerable<settingUnit> settingUnit { get; set; }
        public invIssuanceReturnMaster invIssuanceReturnMaster { get; set; }
        public invIssuanceReturnDetail invIssuanceReturnDetail { get; set; }
    }
}