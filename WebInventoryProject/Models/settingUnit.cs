using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("settingUnit")]
    public class settingUnit
    {
        [Key]
        public int unitId { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name ="Unit")]
        [Index(IsUnique = true)]
        public string  unitName { get; set; }

        [Required]
        [Display(Name = "Enable")]
        public bool isActive { get; set; }
    }
}