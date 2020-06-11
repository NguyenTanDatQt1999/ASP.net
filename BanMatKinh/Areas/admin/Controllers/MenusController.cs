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
    public class MenusController : Controller
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: admin/Menus
        public ActionResult Index()
        {
            return View(db.Menus.ToList());
        }

        // GET: admin/Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelMenu modelMenu = db.Menus.Find(id);
            if (modelMenu == null)
            {
                return HttpNotFound();
            }
            return View(modelMenu);
        }

        // GET: admin/Menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,type,link,tableid,parentid,orders,position,created_at,created_by,update_at,update_by,status")] modelMenu modelMenu)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(modelMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelMenu);
        }

        // GET: admin/Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelMenu modelMenu = db.Menus.Find(id);
            if (modelMenu == null)
            {
                return HttpNotFound();
            }
            return View(modelMenu);
        }

        // POST: admin/Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,type,link,tableid,parentid,orders,position,created_at,created_by,update_at,update_by,status")] modelMenu modelMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelMenu);
        }

        // GET: admin/Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelMenu modelMenu = db.Menus.Find(id);
            if (modelMenu == null)
            {
                return HttpNotFound();
            }
            return View(modelMenu);
        }

        // POST: admin/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modelMenu modelMenu = db.Menus.Find(id);
            db.Menus.Remove(modelMenu);
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
