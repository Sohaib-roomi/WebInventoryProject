using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("invGRNDetail")]
    public class invGRNDetail
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("invGRNMaster")]
        public int grnId { get; set; }
        public virtual invGRNMaster invGRNMaster { get; set; }

        [Display(Name = "item")]
        [ForeignKey("settingItem")]
        public int itemId { get; set; }
        public virtual settingItem settingItem { get; set; }
        [Display(Name = "Unit")]
        [ForeignKey("settingUnit")]
        public int unitId { get; set; }
        public virtual settingUnit settingUnit { get; set; }
        [Display(Name = "P O")]
        [System.ComponentModel.DefaultValue(false)]
        [ForeignKey("invPurchaseOrderMaster")]
        public int poId { get; set; }
        public virtual invPurchaseOrderMaster invPurchaseOrderMaster { get; set; }
        [Display(Name = "Quantity")]
        public float qty { get; set; }

        [Display(Name = "Rate")]
        [System.ComponentModel.DefaultValue(false)]
        public float rate { get; set; }

        [Display(Name = "tax")]
        [System.ComponentModel.DefaultValue(false)]
        public float tax { get; set; }

        [Display(Name = "Discount")]
        [System.ComponentModel.DefaultValue(false)]
        public float discount { get; set; }
        
        [Display(Name = "Actual Rate")]
        [System.ComponentModel.DefaultValue(false)]
        public float actualRate { get; set; }

        [Display(Name = "Final Rate")]
        [System.ComponentModel.DefaultValue(false)]
        public float finalRate { get; set; }

        [Display(Name = "Expiry Date")]
        
        public DateTime? expiryDate { get; set; }

        
    }
}