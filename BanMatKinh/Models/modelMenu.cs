using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanMatKinh.Models
{
    [Table("Menus")]
    public class modelMenu
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public int tableid { get; set; }
        public int parentid { get; set; }
        public int orders { get; set; }
        public string position { get; set; }
        public string created_at { get; set; }
        public int created_by { get; set; }
        public string update_at { get; set; }
        public int update_by { get; set; }
        public int status { get; set; }
    }
}