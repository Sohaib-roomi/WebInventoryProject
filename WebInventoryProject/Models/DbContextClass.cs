using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    public class DbContextClass : DbContext
    {
        public DbContextClass() : base("Name=DbContextClass")
        {
            
        }
        public virtual DbSet<loginUser> loginUser { get; set; }
        public virtual DbSet<settingBranch> settingBranch { get; set; }
        public virtual DbSet<settingDepartment> settingDepartment { get; set; }
        public virtual DbSet<settingCategory> settingCategory { get; set; }
        public virtual DbSet<settingSubCategory> settingSubCategory { get; set; }
        public virtual DbSet<settingUnit> settingUnit { get; set; }
        public virtual DbSet<settingItem> SettingItem { get; set; }
        public virtual DbSet<settingItemParlevel> SettingItemParlevels { get; set; }
        public virtual DbSet<invDemandDetail> invDemandDetail { get; set; }
        public virtual DbSet<invDemandMaster> invDemandMaster { get; set; }
        public virtual DbSet<invPurchaseOrderMaster> invPurchaseOrderMaster { get; set; }
        public virtual DbSet<invPurchaseOrderDetail> invPurchaseOrderDetail { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<invRecipeMaster> invRecipeMaster { get; set; }
        public virtual DbSet<invRecipeDetail> invRecipeDetail { get; set; }
        public virtual DbSet<invGRNMaster> invGRNMaster { get; set; }
        public virtual DbSet<invGRNDetail> invGRNDetail { get; set; }
        public virtual DbSet<invWareHouse> invWareHouse { get; set; }
        public virtual DbSet<invTransferMaster> invTransferMaster { get; set; }
        public virtual DbSet<invTransferDetail> invTransferDetail { get; set; }
        public virtual DbSet<invOpeningMaster> invOpeningMaster { get; set; }
        public virtual DbSet<invOpeningDetail> invOpeningDetail { get; set; }
        public virtual DbSet<invPhysicalStockMaster> invPhysicalStockMaster { get; set; }
        public virtual DbSet<invPhysicalStockDetail> invPhysicalStockDetail { get; set; }
        public virtual DbSet<invDirectPurchaseMaster> invDirectPurchaseMaster { get; set; }
        public virtual DbSet<invDirectPurchaseDetail> invDirectPurchaseDetail { get; set; }
        public virtual DbSet<invIssuanceMaster> invIssuanceMaster { get; set; }
        public virtual DbSet<invIssuanceDetail> invIssuanceDetail { get; set; }
        public virtual DbSet<invIssuanceReturnMaster> invIssuanceReturnMaster { get; set; }
        public virtual DbSet<invIssuanceReturnDetail> invIssuanceReturnDetail { get; set; }
        public virtual DbSet<invProductionMaster> invProductionMaster { get; set; }
        public virtual DbSet<invProductionDetail> invProductionDetail { get; set; }
        public virtual DbSet<invWastageMaster> invWastageMaster { get; set; }
        public virtual DbSet<invWastageDetail> invWastageDetail { get; set; }
        public virtual DbSet<settingUserInventoryRights> settingUserInventoryRights { get; set; }
        public virtual DbSet<invDiscardMaster> invDiscardMaster { get; set; }
        public virtual DbSet<invDiscardDetail> invDiscardDetail { get; set; }


    }
}