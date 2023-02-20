﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("invPhysicalStockMaster")]
    public class invPhysicalStockMaster
    {
        [Key]
        //composite foreignkey contrast check previous errors 
        //solution set cascade delete = false
        public int psId { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Date")]
        public DateTime psDate { get; set; }
        [Display(Name = "PS No")]
        public string psNo { get; set; }

        [Display(Name = "Branch")]
        [ForeignKey("settingBranch")]
        public int BranchId { get; set; }
        public virtual settingBranch settingBranch { get; set; }

        [Display(Name = "Department")]
        [ForeignKey("settingDepartment")]
        public int DepartmentId { get; set; }

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

        public int postUserId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime postDate { get; set; }




    }
}