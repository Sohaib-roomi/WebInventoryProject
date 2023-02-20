using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class invIssuanceMasterDetailViewModel
    {
        public IEnumerable<invIssuanceMaster> invIssuanceMasters { get; set; }
        public IEnumerable<invIssuanceDetail> invIssuanceDetails { get; set; }
        public IEnumerable<settingBranch> settingBranches { get; set; }
        public IEnumerable<settingDepartment> settingDepartments { get; set; }
        public IEnumerable<invDemandMaster> invDemandMaster { get; set; }
        public IEnumerable<settingItem> settingItems { get; set; }
        public IEnumerable<settingUnit> settingUnit { get; set; }
        public invIssuanceMaster invIssuanceMaster { get; set; }
        public invIssuanceDetail invIssuanceDetail { get; set; }
        public string UserType { get; set; }

        public string code { get; set; }
        public DateTime issuanceDate { get; set; }
    }
}