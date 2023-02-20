using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    public class invPurchaseOrderMaster
    {
        public invPurchaseOrderMaster()
        {
            this.InvPurchaseOrderDetails = new HashSet<invPurchaseOrderDetail>();
        }
        [Key]
        public int poId { get; set; }

        [Display(Name = "Purchase Date")]
        [Column(TypeName ="datetime2")]       
        public DateTime poDate { get; set; }
        [Display(Name = "PONo")]
        public string poNo { get; set; }
        [Display(Name = "Description")]
        public string desc { get; set; }
       
        [Display(Name = "Vendor")]
        [ForeignKey("Supplier")]
        public int SPId { get; set; }
        public virtual Supplier Supplier { get; set; }
        [Display(Name = "Total Amount")]
        public float totalAmount  { get; set; }
        public int userId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime dateTime { get; set; }
        [Display(Name = "Status")]
        public bool status { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime modifiedDate { get; set; }
        public int modifiedBy { get; set; }
        [Display(Name = "Branch")]
        [ForeignKey("SettingBranch")]
        public int branchId { get; set; }
        public virtual settingBranch SettingBranch { get; set; }
        [ForeignKey("settingDepartment")]
        [Display(Name = "Department")]
        public int departmentId { get; set; }
        public settingDepartment settingDepartment { get; set; }
        public string workStation { get; set; }
        public bool isPost { get; set; }
        public virtual ICollection<invPurchaseOrderDetail> InvPurchaseOrderDetails { get; set; }

    }
}