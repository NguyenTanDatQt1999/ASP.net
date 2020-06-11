using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BanMatKinh.Models
{
    public class ShopDBContext:DbContext
    {
        public ShopDBContext() : base("name=StrConn") { }
        public DbSet<modelCategory> Categories { get; set; }
        public DbSet<modelContact> Contacts { get; set; }
        public DbSet<modelMenu> Menus { get; set; }
        public DbSet<modelOrder> Orders { get; set; }
        public DbSet<modelOrderdetail> Orderdetails { get; set; }
        public DbSet<modelPost> Posts { get; set; }
        public DbSet<modelProduct> Products { get; set; }
        public DbSet<modelSlider> Sliders { get; set; }
        public DbSet<modelTopic> Topics { get; set; }
        public DbSet<modelUser> Users { get; set; }
    }
}