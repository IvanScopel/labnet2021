using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tp07.MVC.Models
{
    public class ShippersView
    {
        public int ShipperID { get; set; }

        [Required]
        [MaxLength(length: 40)]
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }
}