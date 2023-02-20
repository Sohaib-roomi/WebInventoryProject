using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebInventoryProject.Models
{
    [Table("settingDepartment")]
    public class settingDepartment
    {
        [Key]
        public int departmentId { get; set; }

        [Required]
        [ForeignKey("settingBranch")]
        [Display(Name = "Branch")]
        public int branchId { get; set; }
        public virtual settingBranch settingBranch { get; set; }

        [Required]
        [MaxLength(10)]
        [Index(IsUnique = true)]
        [Display(Name = "Code")]
        public string departmentCode { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Department")]
        public string departmentName { get; set; }

        [Required]
        [Display(Name = "Enable")]
        public bool isActive { get; set; }
    }
}