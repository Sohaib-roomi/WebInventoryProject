using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInventoryProject.Models;

namespace WebInventoryProject.ViewModel
{
    public class InvRecipeViewModel
    {
        public IEnumerable<settingItem> settingItem { get; set; }
        public IEnumerable<invRecipeMaster> invRecipeMasterList { get; set; }
        public IEnumerable<invRecipeDetail> invRecipeDetailList { get; set; }
        public invRecipeMaster invRecipeMaster { get; set; }
        public invRecipeDetail invRecipeDetail { get; set; }
        public string UserType { get; internal set; }
        public DateTime dateTime { get; set; }

    }
}