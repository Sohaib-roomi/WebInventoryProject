using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
   
        [Table("invTransferMaster")]
        public class invTransferMaster
        {
            [Key]
            public int trId { get; set; }
            //set getdate by default
            [Display(Name = "Transfer Date")]
        [Column(TypeName = "datetime2")]
            public DateTime trDate { get; set; }
            [Display(Name = "Transfer No")]
            public string trNo { get; set; }
            [Column(TypeName = "datetime2")]
            public DateTime dateTime { get; set; }

            [Display(Name = "From Department")]
            [ForeignKey("settingDepartment")]
            public int fromDepartmentId { get; set; }
            public virtual settingDepartment settingDepartment { get; set; }

            [Display(Name = "To Department")]
            [ForeignKey("settingDept")]
            public int toDepartmentId { get; set; }
            public virtual settingDepartment settingDept { get; set; }

            [System.ComponentModel.DefaultValue(false)]
            public bool isPost { get; set; }

            [Display(Name = "From Branch")]
            [ForeignKey("settingBranch")]
            public int fromBranchId { get; set; }
            public virtual settingBranch settingBranch { get; set; }

            [Display(Name = "To Branch")]
            [ForeignKey("settingBr")]
            public int toBranchId { get; set; }
            public virtual settingBranch settingBr { get; set; }

            [ForeignKey("loginUser")]
            public int userId { get; set; }
            public virtual loginUser loginUser { get; set; }
            //composite forignkey error occured cause of data type of columns could be different
            [ForeignKey("loginUsr")]
            public int modifiedBy { get; set; }
            public virtual loginUser loginUsr { get; set; }
           [Column(TypeName = "datetime2")]
            public DateTime modifiedDate { get; set; }
            [System.ComponentModel.DefaultValue(false)]
            public bool isReceive { get; set; }
            public int postUserId { get; set; }
         [Column(TypeName = "datetime2")]
        public DateTime postDate { get; set; }

        }
    }
