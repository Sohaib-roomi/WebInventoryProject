using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebInventoryProject.Models
{
    [Table("settingBranch")]
    public class settingBranch
    {
        [Key]
        public int branchId { get; set; }

        [Required]
        [MaxLength(10)]
        [Index(IsUnique = true)]
        [Display(Name = "Code")]
        public string branchCode { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Branch")]
        public string branchName { get; set; }

        [Required]
        [Display(Name = "HeadOffice")]
        public bool isHeadOfficeBranch { get; set; }

        [Required]
        [Display(Name = "Enable")]
        public bool isActive { get; set; }
    }
}