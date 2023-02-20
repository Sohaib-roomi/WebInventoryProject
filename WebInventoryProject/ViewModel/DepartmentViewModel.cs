using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class DepartmentViewModel
    {
        public settingDepartment settingDepartment { get; set; }
        public IEnumerable<settingBranch>  settingBranch { get; set; }
       
    }
}