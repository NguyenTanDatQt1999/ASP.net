using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanMatKinh.Models
{
    [Table("Products")]
    public class modelProduct
    {
        public int id { get; set; }
        public int catid { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string img { get; set; }
        public string imglist { get; set; }
        public string detail { get; set; }
        public int number { get; set; }
        public float price { get; set; }
        public float pricesale { get; set; }
        public string metakey { get; set; }
        public string metadesc { get; set; }
        public string created_at { get; set; }
        public int created_by { get; set; }
        public string update_at  { get; set; }
        public int update_by { get; set; }
        public int status { get; set; }
    }
}