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
    public class CategoryController : Controller
    {
       // private BanMatKinhContext db = new BanMatKinhContext();
        private ShopDBContext db = new ShopDBContext();
        // GET: admin/Category
        public ActionResult Index()
        {
            var list = db.Categories.Where(m=>m.status!=0).ToList();
            return View(list);
        }

        // GET: admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelCategory modelCategory = db.Categories.Find(id);
            if (modelCategory == null)
            {
                return HttpNotFound();
            }
            return View(modelCategory);
        }

        // GET: admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,slug,parentid,orders,metakey,metadesc,created_at,created_by,update_at,update_by,status")] modelCategory modelCategory)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(modelCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelCategory);
        }

        // GET: admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelCategory modelCategory = db.Categories.Find(id);
            if (modelCategory == null)
            {
                return HttpNotFound();
            }
            return View(modelCategory);
        }

        // POST: admin/Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,slug,parentid,orders,metakey,metadesc,created_at,created_by,update_at,update_by,status")] modelCategory modelCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelCategory);
        }

        // GET: admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelCategory modelCategory = db.Categories.Find(id);
            if (modelCategory == null)
            {
                return HttpNotFound();
            }
            return View(modelCategory);
        }

        // POST: admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modelCategory modelCategory = db.Categories.Find(id);
            db.Categories.Remove(modelCategory);
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
