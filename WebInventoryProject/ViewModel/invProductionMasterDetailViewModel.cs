using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class invProductionMasterDetailViewModel
    {
        public IEnumerable<invProductionMaster> invProductionMasters { get; set; }
        public IEnumerable<invProductionDetail> invProductionDetails { get; set; }
        public IEnumerable<settingBranch> settingBranches { get; set; }
        public settingBranch settingBr { get; set; }
        public settingDepartment settingDept { get; set; }
        public IEnumerable<settingDepartment> settingDepartments { get; set; }        
        public IEnumerable<settingItem> settingItems { get; set; }
        public IEnumerable<settingUnit> settingUnit { get; set; }
        public invProductionMaster invProductionMaster { get; set; }
        public invProductionDetail invProductionDetail { get; set; }
        public string UserType { get; set; }

        public string code { get; set; }
        public DateTime date { get; set; }
    }
}