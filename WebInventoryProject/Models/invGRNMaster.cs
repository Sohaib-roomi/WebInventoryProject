using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("invGRNMaster")]
    public class invGRNMaster
    {
        [Key]
        public int grnId { get; set; }

        [Display(Name = "GRN Date")]
       
        public DateTime? grnDate { get; set; }
        [Display(Name = "GRN No")]
        public string grnNo { get; set; }

        [Display(Name = "Vendor")]
        [ForeignKey("Supplier")]
        public int SPId { get; set; }
        public virtual Supplier Supplier { get; set; }
        [Display(Name = "Ref No")]
        [StringLength(50)]
        public string referenceNo { get; set; }
        [Display(Name ="Desc")]
        public string desc { get; set; }
        [Display(Name ="Amount")]
        public float amount { get; set; }
        [Display(Name = "Total Discount")]
        public float discount { get; set; }
        [Display(Name = "Total Tax")]
        public float totalTax { get; set; }
        [Display(Name = "Total Amount")]
        public float totalAmount { get; set; }

        [ForeignKey("loginUser")]
        public int userId { get; set; }
        public virtual loginUser loginUser { get; set; }

        [Display(Name = "Date")]
        [Column(TypeName = "datetime2")]
        public DateTime dateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime modifiedDate { get; set; }
        //Modified By is Remaining (what to do with it)
        //[ForeignKey("loginUser")]
        public int modifiedBy { get; set; }
       // public virtual loginUser loginUsr { get; set; }
        [Display(Name ="Extra Charges")]
        public float extraCharges { get; set; }

        public string workStation { get; set; }
        [System.ComponentModel.DefaultValue(false)]
        public bool isPost { get; set; }

        [Display(Name = "Branch")]
        [ForeignKey("settingBranch")]
        public int branchId { get; set; }
        public virtual settingBranch settingBranch { get; set; }

        [Display(Name = "Department")]
        [ForeignKey("settingDepartment")]
        public int departmentId { get; set; }
        public virtual settingDepartment settingDepartment { get; set; }
        public int postUserId { get; set; }
        [Column(TypeName ="datetime2")]
        public DateTime postDate { get; set; }

    }
}