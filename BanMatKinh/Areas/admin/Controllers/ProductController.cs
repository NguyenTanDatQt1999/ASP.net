using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanMatKinh.Areas.admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: admin/Product
        public ActionResult Index()
        {
            return View();
        }
    }
}