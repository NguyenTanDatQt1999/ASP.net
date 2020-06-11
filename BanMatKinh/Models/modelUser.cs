using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanMatKinh.Models
{
    [Table("Users")]
    public class modelUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string fullname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int gender { get; set; }
        public string phone { get; set; }
        public string img { get; set; }
        public int access { get; set; }
        public string created_at { get; set; }
        public int created_by { get; set; }
        public string update_at { get; set; }
        public int update_by { get; set; }
        public int status { get; set; }
    }
}