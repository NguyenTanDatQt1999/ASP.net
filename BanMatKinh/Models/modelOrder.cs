using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanMatKinh.Models
{
    [Table("Olders")]
    public class modelOrder
    {
        public int id { get; set; }
        public int code { get; set; }
        public int userid { get; set; }
        public string createdate { get; set; }
        public string exportdate { get; set; }
        public string deliveryadress { get; set; }
        public string deliveryname { get; set; }
        public string deliveryphone { get; set; }
        public string deliveryemail { get; set; }
        public string update_at { get; set; }
        public int update_by { get; set; }
        public int status { get; set; }
    }
}