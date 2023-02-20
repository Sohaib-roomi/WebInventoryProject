using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{

    public class ParLevelViewModel
    {
        public IEnumerable<ParLevelViewModel> ParLevelViewModels { get; set; }
        public IEnumerable<settingSubCategory> settingSubCategories { get; set; }
        public IEnumerable<settingUnit> settingUnits { get; set; }
        public settingItem SettingItem { get; set; }
        public int branchId { get; set; }
        public int departmentId { get; set; }
        public string branchName { get; set; }
        public string departmentName { get; set; }
        public int ItemId { get; set; }
        [Required]
        [Display(Name = "Min")]
        [System.ComponentModel.DefaultValue(true)]
        public float min { get; set; }

        [Required]
        [Display(Name = "Max")]
        [System.ComponentModel.DefaultValue(true)]
        public float max { get; set; }


    }
}