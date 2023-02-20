using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebInventoryProject.Models
{
  
    public class Supplier
    {
        [Key]
        public int SPId { get; set; }
        public string Vendor { get; set; }
        public string VendorCode { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string CellNo { get; set; }
        //Apply Foreign Key from ChartOfAccount
        public int CAId { get; set; }
        public int COId { get; set; }

    }
}