using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("invWareHouse")]
    public class invWareHouse
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Date")]
       
        public DateTime Date { get; set; }      

        [Display(Name = "Item")]
        [ForeignKey("settingItem")]
        public int itemId { get; set; }
        public virtual settingItem settingItem { get; set; }
        [Display(Name = "Unit")]
        [ForeignKey("settingUnit")]
        public int unitId { get; set; }
        public virtual settingUnit settingUnit { get; set; }
        //ask about voucherId TA
        public int VoucherId { get; set; }

        [Display(Name = "Quantity")]
        public float qty { get; set; }
        [Display(Name = "Rate")]
        public float rate { get; set; }
        public string Type { get; set; }
        public string Desc { get; set; }
        public float AvgRate { get; set; }
        public float LastRate { get; set; }
        
        [Column(TypeName = "datetime2")]
        public DateTime ExpiryDate { get; set; }

        public string VN { get; set; }
        [System.ComponentModel.DefaultValue(false)]
        [Display(Name = "Balance")]
        public float balance { get; set; }
        [Display(Name = "Amount")]
        public float amount { get; set; }

        [Display(Name = "Branch")]
        [ForeignKey("settingBranch")]
        public int branchId { get; set; }
        public virtual settingBranch settingBranch { get; set; }

        [Display(Name = "Department")]
        [ForeignKey("settingDepartment")]
        public int departmentId { get; set; }
       public virtual settingDepartment settingDepartment { get; set; }
        public DateTime dateTime { get; set; }
        public string workStation { get; set; }

    }
}