using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("settingItemParlevel")]
    public class settingItemParlevel
    {
        [Key]
        public int id { get; set; }
        [Required]
        [ForeignKey("settingItem")]
        [Display(Name = "Item")]
        public int itemId { get; set; }
        public virtual settingItem settingItem { get; set; }
        [Required]
        [ForeignKey("settingBranch")]
        [Display(Name = "Branch")]
        public int branchId { get; set; }
        public virtual settingBranch settingBranch { get; set; }

        [Required]
        [ForeignKey("SettingDepartment")]
        [Display(Name = "Department")]
        public int departmentId { get; set; }
        public virtual settingDepartment SettingDepartment { get; set; }

        [Required]
        [Display(Name = "Min")]
        [System.ComponentModel.DefaultValue(true)]
        public float min { get; set; }

        [Required]
        [Display(Name = "Max")]
        [System.ComponentModel.DefaultValue(true)]
        public float max { get; set; }

        [Required]
        [System.ComponentModel.DefaultValue(true)]
        public float balance { get; set; }

        [Required]
        [System.ComponentModel.DefaultValue(true)]
        public float lastRate { get; set; }

        [Required]
        [System.ComponentModel.DefaultValue(true)]
        public float avgRate { get; set; }

    }
}