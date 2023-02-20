using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
    [Table("loginUser")]
    public class loginUser
    {
        [Key]
        public int userId { get; set; }

        [Required(ErrorMessage = "Enter Your Email")]
        [EmailAddress]
        [MaxLength(30)]
        [Display(Name ="Email")]
        public string email { get; set; }

        [Required(ErrorMessage ="Enter Your Password")]
        [MaxLength(20)]
        [Display(Name = "Password")]
        public string password { get; set; }

        //[Required]
        //[Compare("Password")]
        //public string confirmPassword { get; set; }


        [Required(ErrorMessage = "Please Enter Name e.g. John Doe")]
        [StringLength(30, MinimumLength = 3)]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Please Enter Name e.g. John Doe")]
        [StringLength(30, MinimumLength = 3)]
        public string lastName { get; set; }

        [DisplayName("Contact Number")]
        [StringLength(30, MinimumLength = 7)]
        [DataType(DataType.PhoneNumber)]
        public string contactNo { get; set; }

    }
}