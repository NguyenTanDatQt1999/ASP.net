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
    public class TopicsController : Controller
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: admin/Topics
        public ActionResult Index()
        {
            return View(db.Topics.ToList());
        }

        // GET: admin/Topics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelTopic modelTopic = db.Topics.Find(id);
            if (modelTopic == null)
            {
                return HttpNotFound();
            }
            return View(modelTopic);
        }

        // GET: admin/Topics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Topics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,slug,parentid,orders,metakey,metadesc,created_at,created_by,update_at,update_by,status")] modelTopic modelTopic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(modelTopic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelTopic);
        }

        // GET: admin/Topics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelTopic modelTopic = db.Topics.Find(id);
            if (modelTopic == null)
            {
                return HttpNotFound();
            }
            return View(modelTopic);
        }

        // POST: admin/Topics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,slug,parentid,orders,metakey,metadesc,created_at,created_by,update_at,update_by,status")] modelTopic modelTopic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelTopic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelTopic);
        }

        // GET: admin/Topics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelTopic modelTopic = db.Topics.Find(id);
            if (modelTopic == null)
            {
                return HttpNotFound();
            }
            return View(modelTopic);
        }

        // POST: admin/Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modelTopic modelTopic = db.Topics.Find(id);
            db.Topics.Remove(modelTopic);
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
