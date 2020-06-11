using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanMatKinh.Models
{
    [Table("Orderdetails")]
    public class modelOrderdetail
    {
        public int id { get; set; }
        public int orderid { get; set; }
        public int productid { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
        public float amount { get; set; }
    }
}