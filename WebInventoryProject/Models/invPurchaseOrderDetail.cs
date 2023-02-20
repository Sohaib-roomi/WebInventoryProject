using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    public class invPurchaseOrderDetail
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("invPurchaseOrderMaster")]
        public int poId { get; set; }
        public virtual invPurchaseOrderMaster invPurchaseOrderMaster { get; set; }

        [Display(Name = "Item")]
        [ForeignKey("settingItem")]
        public int itemId { get; set; }
        public virtual settingItem settingItem { get; set; }
        [Display(Name = "Unit")]
        [ForeignKey("settingUnit")]
        public int unitId { get; set; }
        public virtual settingUnit settingUnit { get; set; }
        [Display(Name = "Quantity")]
        public float qty { get; set; }
        [Display(Name = "Rate")]
        public float rate { get; set; }
        [Display(Name = "GrnQty")]
        [System.ComponentModel.DefaultValue(false)]
        public float grnQty { get; set; }
        public int demandId { get; set; }
        [System.ComponentModel.DefaultValue(false)]
        [Display(Name = "Status")]
        public bool status { get; set; }
        [System.ComponentModel.DefaultValue(false)]
        [Display(Name = "Enable")]
        public bool isActive { get; set; }
        [Display(Name = "Stock")]       
        public float stock { get; set; }

    }
}