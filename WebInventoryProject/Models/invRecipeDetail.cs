using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    public class invRecipeDetail
    {
        [Key]
        public int id { get; set; }
        
        [ForeignKey("invRecipeMaster")]
        public int RecipeId { get; set; }
        public virtual invRecipeMaster invRecipeMaster { get; set; }
        [Display(Name = "Ingredient")]
        [ForeignKey("settingItem")]
        public int IngredientId { get; set; }
        public virtual settingItem settingItem { get; set; }
        [Display(Name = "Quantity")]
        public int Qty { get; set; }
        public bool DineIn { get; set; }
        public bool TakeAway { get; set; }
        public bool Delivery { get; set; }
        public string Workstation { get; set; }
    }
}