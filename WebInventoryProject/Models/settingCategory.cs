using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("settingCategory")]
    public class settingCategory
    {
        [Key]
        public int categoryId { get; set; }

        [Required]
        [MaxLength(10)]
        [Index(IsUnique = true)]
        [Display(Name ="Code")]
        public string categoryCode { get; set; }

        [Required]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        [Display(Name = "Category")]
        public string categoryName { get; set; }

        [Required]
        [Display(Name = "Enable")]
        public bool isActive { get; set; }
    }
}