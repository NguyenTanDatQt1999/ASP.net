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
    public class SlidersController : Controller
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: admin/Sliders
        public ActionResult Index()
        {
            return View(db.Sliders.ToList());
        }

        // GET: admin/Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelSlider modelSlider = db.Sliders.Find(id);
            if (modelSlider == null)
            {
                return HttpNotFound();
            }
            return View(modelSlider);
        }

        // GET: admin/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,url,position,img,orders,created_at,created_by,update_at,update_by,status")] modelSlider modelSlider)
        {
            if (ModelState.IsValid)
            {
                db.Sliders.Add(modelSlider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelSlider);
        }

        // GET: admin/modelSliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelSlider modelSlider = db.Sliders.Find(id);
            if (modelSlider == null)
            {
                return HttpNotFound();
            }
            return View(modelSlider);
        }

        // POST: admin/modelSliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,url,position,img,orders,created_at,created_by,update_at,update_by,status")] modelSlider modelSlider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelSlider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelSlider);
        }

        // GET: admin/modelSliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelSlider modelSlider = db.Sliders.Find(id);
            if (modelSlider == null)
            {
                return HttpNotFound();
            }
            return View(modelSlider);
        }

        // POST: admin/modelSliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modelSlider modelSlider = db.Sliders.Find(id);
            db.Sliders.Remove(modelSlider);
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
