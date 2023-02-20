using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("invPhysicalStockDetail")]
    public class invPhysicalStockDetail
    {
        //Modified Date and Post Date Columns get date as 01-01-0001 which cause out of range
       //for that we have used datetime2 data type
        [Key]
        public int id { get; set; }
        [ForeignKey("invPhysicalStockMaster")]
        public int psId { get; set; }
        public virtual invPhysicalStockMaster invPhysicalStockMaster { get; set; }

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