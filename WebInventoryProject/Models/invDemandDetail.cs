using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    public class invDemandDetail
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("invDemandMaster")]
        public int demand_Id { get; set; }
        public virtual invDemandMaster invDemandMaster { get; set; }

        [Display(Name = "itemId")]
        [ForeignKey("settingItem")]
        public int itemId { get; set; }
        public virtual settingItem settingItem { get; set; }
        [Display(Name = "Unit")]
        [ForeignKey("settingUnit")]
        public int unitId { get; set; }
        public virtual settingUnit settingUnit { get; set; }
        [Display(Name = "Quantity")]
        public float qty { get; set; }
        [Display(Name = "Balance")]

        [System.ComponentModel.DefaultValue(true)]
        public float balance { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        [Display(Name = "Enable")]
        public bool isActive { get; set; }
        [Display(Name = "Stock")]
        public float stock { get; set; }
    }
}