using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebInventoryProject.Models
{
    [Table("invProductionDetail")]
    public class invProductionDetail
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("invProductionMaster")]
        public int prId { get; set; }
        public virtual invProductionMaster invProductionMaster { get; set; }

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