using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanMatKinh.Models
{
    [Table("Contacts")]
    public class modelContact
    {
        public int  id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public string created_at { get; set; }
        public string update_at { get; set; }
        public int update_by { get; set; }
        public int status { get; set; }
    }
}