using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoginSystem2.Models;

namespace LoginSystem2.Controllers
{
    public class UserdsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Userds
        public ActionResult Index()
        {
            return View(db.Userds.ToList());
        }

        // GET: Userds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userd userd = db.Userds.Find(id);
            if (userd == null)
            {
                return HttpNotFound();
            }
            return View(userd);
        }

        // GET: Userds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Userds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DOB,phone,address,group")] Userd userd)
        {
            if (ModelState.IsValid)
            {
                db.Userds.Add(userd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userd);
        }

        // GET: Userds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userd userd = db.Userds.Find(id);
            if (userd == null)
            {
                return HttpNotFound();
            }
            return View(userd);
        }

        // POST: Userds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DOB,phone,address,group")] Userd userd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userd);
        }

        // GET: Userds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userd userd = db.Userds.Find(id);
            if (userd == null)
            {
                return HttpNotFound();
            }
            return View(userd);
        }

        // POST: Userds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Userd userd = db.Userds.Find(id);
            db.Userds.Remove(userd);
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
