using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanMatKinh.Models;

namespace BanMatKinh.Areas.admin.Controllers
{
    public class OrdersController : Controller
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: admin/Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: admin/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelOrder modelOrder = db.Orders.Find(id);
            if (modelOrder == null)
            {
                return HttpNotFound();
            }
            return View(modelOrder);
        }

        // GET: admin/Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,code,userid,createdate,exportdate,deliveryadress,deliveryname,deliveryphone,deliveryemail,update_at,update_by,status")] modelOrder modelOrder)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(modelOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelOrder);
        }

        // GET: admin/Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelOrder modelOrder = db.Orders.Find(id);
            if (modelOrder == null)
            {
                return HttpNotFound();
            }
            return View(modelOrder);
        }

        // POST: admin/Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,code,userid,createdate,exportdate,deliveryadress,deliveryname,deliveryphone,deliveryemail,update_at,update_by,status")] modelOrder modelOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelOrder);
        }

        // GET: admin/Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelOrder modelOrder = db.Orders.Find(id);
            if (modelOrder == null)
            {
                return HttpNotFound();
            }
            return View(modelOrder);
        }

        // POST: admin/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modelOrder modelOrder = db.Orders.Find(id);
            db.Orders.Remove(modelOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
