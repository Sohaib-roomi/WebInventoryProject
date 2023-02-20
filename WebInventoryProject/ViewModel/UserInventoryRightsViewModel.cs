using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class UserInventoryRightsViewModel
    {
        public settingUserInventoryRights settingUserInventoryRights { get; set; }
        public IEnumerable<settingBranch> settingBranch { get; set; }
        public IEnumerable<settingDepartment> settingDepartment { get; set; }
        public IEnumerable<loginUser> loginUsers { get; set; }
        public string userType { get; set; }
        
    }
}