using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    public class invTransferDetail
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("invTransferMaster")]
        public int trId  { get; set; }
        public virtual invTransferMaster invTransferMaster { get; set; }

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
        [Display(Name = "Rate")]

        [System.ComponentModel.DefaultValue(false)]
        public float rate { get; set; }

    }
}