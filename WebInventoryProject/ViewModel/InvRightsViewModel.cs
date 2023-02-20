using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class InvRightsViewModel
    {
        public List<settingCategory> settingCategory { get; set; }
        public bool save { get; set; }
        
        public bool edit { get; set; }
        
        public bool delete { get; set; }
        
        public bool post { get; set; }
    }
}