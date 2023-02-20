using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("invRecipeMaster")]
    public class invRecipeMaster
    {
        public invRecipeMaster()
        {
            this.InvRecipeDetails = new HashSet<invRecipeDetail>();
        }
        [Key]
        public int RecipeId { get; set; }
        public int ProductId { get; set; }
        public string Comments { get; set; }
        public string Workstation { get; set; }
        [Display(Name = "SubRecipe")]
        [System.ComponentModel.DefaultValue("true")]
        public bool isSubRecipe { get; set; }
        public int userId { get; set; }
        [Display(Name = "Date")]
        [Column(TypeName = "datetime2")]
        public DateTime dateTime { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime modifiedDate { get; set; }
        public string modifiedBy { get; set; }
        public virtual ICollection<invRecipeDetail> InvRecipeDetails { get; set; }
    }
}
