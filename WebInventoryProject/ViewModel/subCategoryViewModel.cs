using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class SubcategoryViewModel
    {
        public settingSubCategory settingSubCategory { get; set; }
        public IEnumerable<settingCategory> settingCategory { get; set; }
    }
}