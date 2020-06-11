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
    public class PostsController : Controller
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: admin/Posts
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        // GET: admin/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelPost modelPost = db.Posts.Find(id);
            if (modelPost == null)
            {
                return HttpNotFound();
            }
            return View(modelPost);
        }

        // GET: admin/Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,topid,title,slug,detail,img,type,metakey,metadesc,created_at,created_by,update_at,update_by,status")] modelPost modelPost)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(modelPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelPost);
        }

        // GET: admin/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelPost modelPost = db.Posts.Find(id);
            if (modelPost == null)
            {
                return HttpNotFound();
            }
            return View(modelPost);
        }

        // POST: admin/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,topid,title,slug,detail,img,type,metakey,metadesc,created_at,created_by,update_at,update_by,status")] modelPost modelPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelPost);
        }

        // GET: admin/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelPost modelPost = db.Posts.Find(id);
            if (modelPost == null)
            {
                return HttpNotFound();
            }
            return View(modelPost);
        }

        // POST: admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modelPost modelPost = db.Posts.Find(id);
            db.Posts.Remove(modelPost);
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
