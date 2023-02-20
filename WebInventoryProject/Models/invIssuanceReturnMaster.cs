using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("invIssuanceReturnMaster")]
    public class invIssuanceReturnMaster
    {

        [Key]
        public int issuanceReturnId { get; set; }
        //set getdate by default
        [Display(Name = "Issuance Return Date")]
        [Column(TypeName = "datetime2")]
        public DateTime issuanceReturnDate { get; set; }
        [Display(Name = "Iss Return No")]
        public string issuanceReturnNo { get; set; }

        [Display(Name = "Branch")]
        [ForeignKey("settingBranch")]
        public int branchId { get; set; }
        public virtual settingBranch settingBranch { get; set; }

        [Display(Name = "Department")]
        [ForeignKey("settingDepartment")]
        public int departmentId { get; set; }
        public virtual settingDepartment settingDepartment { get; set; }
        [Display(Name = "Issuance")]
        [ForeignKey("invIssuanceMaster")]
        public int issuanceId { get; set; }
        public virtual invIssuanceMaster invIssuanceMaster { get; set; }

        [ForeignKey("loginUser")]
        public int userId { get; set; }
        public virtual loginUser loginUser { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime dateTime { get; set; }

        [ForeignKey("loginUsr")]
        public int modifiedBy { get; set; }
        public virtual loginUser loginUsr { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime modifiedDate { get; set; }
        public string workStation { get; set; }

        [System.ComponentModel.DefaultValue(false)]
        public bool isPost { get; set; }

        [ForeignKey("loginUser1")]
        public int postUserId { get; set; }
        public virtual loginUser loginUser1 { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime postDate { get; set; }



        //composite forignkey error occured cause of data type of columns could be different

    }
}
