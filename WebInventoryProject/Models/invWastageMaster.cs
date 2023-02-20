using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("invWastageMaster")]
    public class invWastageMaster
    {
        [Key]
        public int wastageId { get; set; }
        public DateTime wastageDate { get; set; }
        [Display(Name = "WNo")]
        public string wastageNo { get; set; }

        [Display(Name = "Branch")]
        [ForeignKey("settingBranch")]
        public int branchId { get; set; }
        public virtual settingBranch settingBranch { get; set; }

        [Display(Name = "Deptartment")]
        [ForeignKey("settingDepartment")]
        public int departmentId { get; set; }
        public virtual settingDepartment settingDepartment { get; set; }

        [ForeignKey("loginUser")]
        public int userId { get; set; }
        public virtual loginUser loginUser { get; set; }
        public DateTime dateTime { get; set; }

        [ForeignKey("loginUsr")]
        public int modifiedBy { get; set; }
        public virtual loginUser loginUsr { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime modifiedDate { get; set; }
        public string workStation { get; set; }

        [System.ComponentModel.DefaultValue(false)]
        public bool isPost { get; set; }

        [ForeignKey("loginUser1")]
        public int postUserId { get; set; }
        public virtual loginUser loginUser1 { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime postDate { get; set; }

    }
}