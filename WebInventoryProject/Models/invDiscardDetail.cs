using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("invDiscardDetail")]
    public class invDiscardDetail
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("invDiscardMaster")]
        public int discardId { get; set; }
        public virtual invDiscardMaster invDiscardMaster { get; set; }

        [Display(Name = "Item")]
        [ForeignKey("settingItem")]
        public int itemId { get; set; }
        public virtual settingItem settingItem { get; set; }
        
        [Display(Name = "Quantity")]
        public float qty { get; set; }
        [Display(Name = "Desc")]

        [StringLength(500)]
        public string desc { get; set; }
        
    }
}