using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("settingSubcategory")]
    public class settingSubCategory
    {              
            [Key]
            public int subcategoryId { get; set; }
            [ForeignKey("settingCategory")]
            [Display(Name = "Category")]
            public int categoryId { get; set; }
            public virtual settingCategory settingCategory { get; set; }
            [Required]
            [Display(Name = "Code")]
            public string subcategoryCode { get; set; }
            [Required]
            [Display(Name = "Subcategory")]
            public string subcategoryName { get; set; }
            [Required]
            [Display(Name = "Enable")]
            public bool isActive { get; set; }

        
    }
}