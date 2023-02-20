using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class invWastageMasterDetailViewModel
    {      
        public IEnumerable<invWastageMaster> invWastageMaster { get; set; }
        public IEnumerable<invWastageDetail> invWastageDetail { get; set; }
        public IEnumerable<settingBranch> settingBranches { get; set; }
        public settingBranch settingBr { get; set; }
        public IEnumerable<settingDepartment> settingDepartments { get; set; }
        public settingDepartment settingDept { get; set; }
        public IEnumerable<settingItem> settingItems { get; set; }
        public IEnumerable<settingUnit> settingUnit { get; set; }
        public invWastageMaster invWastMaster { get; set; }
        public invWastageDetail invWastDetail { get; set; }
        public DateTime wastageDate { get; set; }
        public string UserType { get; internal set; }
    }
}