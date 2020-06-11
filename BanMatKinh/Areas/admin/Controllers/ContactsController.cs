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
    public class ContactsController : Controller
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: admin/Contacts
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        // GET: admin/Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelContact modelContact = db.Contacts.Find(id);
            if (modelContact == null)
            {
                return HttpNotFound();
            }
            return View(modelContact);
        }

        // GET: admin/Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fullname,email,phone,title,detail,created_at,update_at,update_by,status")] modelContact modelContact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(modelContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelContact);
        }

        // GET: admin/Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelContact modelContact = db.Contacts.Find(id);
            if (modelContact == null)
            {
                return HttpNotFound();
            }
            return View(modelContact);
        }

        // POST: admin/Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fullname,email,phone,title,detail,created_at,update_at,update_by,status")] modelContact modelContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelContact);
        }

        // GET: admin/Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modelContact modelContact = db.Contacts.Find(id);
            if (modelContact == null)
            {
                return HttpNotFound();
            }
            return View(modelContact);
        }

        // POST: admin/Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modelContact modelContact = db.Contacts.Find(id);
            db.Contacts.Remove(modelContact);
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
