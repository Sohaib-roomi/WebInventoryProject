using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("settingUserInventoryRights")]
    public class settingUserInventoryRights
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("loginUser")]
        public int userId { get; set; }
        public virtual loginUser loginUser { get; set; }

        [Display(Name = "Branch")]
        [ForeignKey("settingBranch")]
        public int branchId { get; set; }
        public virtual settingBranch settingBranch { get; set; }

        [Display(Name ="Department")]
        [ForeignKey("settingDepartment")]
        public int departmentId { get; set; }
        public virtual settingDepartment settingDepartment { get; set; }
        public int formId { get; set; }

        [System.ComponentModel.DefaultValue(false)]
        public bool save { get; set; }
        [System.ComponentModel.DefaultValue(false)]
        public bool edit { get; set; }
        [System.ComponentModel.DefaultValue(false)]
        public bool delete { get; set; }
        [System.ComponentModel.DefaultValue(false)]
        public bool post { get; set; }
        [Display(Name ="User Type")]
        public string UserType { get; set; }


    }
}