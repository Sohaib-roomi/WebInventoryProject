using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebInventoryProject.Models
{
    [Table("settingItem")]
    public class settingItem
    {
        [Key]
        public int itemId { get; set; }

        [Required]
        [ForeignKey("settingSubCategory")]
        [Display(Name = "SettingSubCategory")]
        public int subcategoryId { get; set; }
        public virtual settingSubCategory settingSubCategory { get; set; }

        [Required]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        [Display(Name = "Code")]
      
        public string itemCode { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Item")]
        public string itemName { get; set; }

        [Required]
        [Display(Name = "PurchaseUnit")]

        [ForeignKey("settingUnit")]
        public int purchaseUnitId { get; set; }
        public virtual settingUnit settingUnit { get; set; }

        [Required]

        [ForeignKey("setting")]
        public int issuanceUnitId { get; set; }
        public virtual settingUnit setting { get; set; }

        [Required]
        [ForeignKey("settingUni")]
        [Display(Name = "RecipeUnit")]
        public int recipeUnitId { get; set; }
        public virtual settingUnit settingUni { get; set; }
        [Required]
        [System.ComponentModel.DefaultValue(true)]
        public float purchaseIssuanceConv { get; set; }
        [Required]
        [System.ComponentModel.DefaultValue(true)]
        public float issuanceRecipeConv { get; set; }


        [Required]
        [Display(Name = "Enable")]
        [System.ComponentModel.DefaultValue(true)]
        public bool isActive { get; set; }

        public DateTime dateAdded { get; set; }
        public string itemType { get; set; }    
    }
}