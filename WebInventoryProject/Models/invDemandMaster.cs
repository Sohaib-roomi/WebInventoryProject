using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    public class invDemandMaster
    {
        public invDemandMaster()
        {
         this.InvDemandDetails = new HashSet<invDemandDetail>();
        }
        [Key]        
        public int demand_Id { get; set; }

        [Display (Name = "Demand Date")]
        [DataType(DataType.Date), Required]
        [Column(TypeName = "datetime2")]
        
        public DateTime demandDate { get; set; }
        [Display(Name = "Demand No")]
        public string demandNo { get; set; }
        [Display(Name = "Branch")]
        [ForeignKey("settingBranch")]        
        public int branchId { get; set; }
        public virtual settingBranch settingBranch { get; set; }
        [Display(Name = "Department")]
        [ForeignKey("settingDepartment")]
        public int departmentId { get; set; }
        public virtual settingDepartment settingDepartment { get; set; }
        //user id is remaining
        public int userId { get; set; }
        [Display(Name = "Date")]
        [Column(TypeName = "datetime2")]
        public DateTime dateTime { get; set; }

        public string modifiedBy { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime modifiedDate { get; set; }
        [Display(Name = "Enable")]
        [System.ComponentModel.DefaultValue("true")]
        public bool isActive { get; set; }
        public string workStation { get; set; }
        public bool isPost { get; set; }


        public virtual ICollection<invDemandDetail> InvDemandDetails { get; set; }
    }

}