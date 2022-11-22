using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team18App.Models;

namespace Team18App.Controllers
{
    public class UsersTblsController : Controller
    {
        private Entities db = new Entities();

        // GET: UsersTbls
        public ActionResult Index()
        {
            return View(db.UsersTbls.ToList());
        }

        // GET: UsersTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersTbl usersTbl = db.UsersTbls.Find(id);
            if (usersTbl == null)
            {
                return HttpNotFound();
            }
            return View(usersTbl);
        }

        // GET: UsersTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Username,Email,Passccode,RoleId")] UsersTbl usersTbl)
        {
            if (ModelState.IsValid)
            {
                db.UsersTbls.Add(usersTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usersTbl);
        }

        // GET: UsersTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersTbl usersTbl = db.UsersTbls.Find(id);
            if (usersTbl == null)
            {
                return HttpNotFound();
            }
            return View(usersTbl);
        }

        // POST: UsersTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Username,Email,Passccode,RoleId")] UsersTbl usersTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usersTbl);
        }

        // GET: UsersTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersTbl usersTbl = db.UsersTbls.Find(id);
            if (usersTbl == null)
            {
                return HttpNotFound();
            }
            return View(usersTbl);
        }

        // POST: UsersTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersTbl usersTbl = db.UsersTbls.Find(id);
            db.UsersTbls.Remove(usersTbl);
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
