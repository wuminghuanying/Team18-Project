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
    public class ErrorMessageController : Controller
    {
        private team18dbEntities db = new team18dbEntities();

        // GET: ErrorMessage
        public ActionResult Index()
        {
            var errorMessages = db.ErrorMessages.Include(e => e.Project);
            return View(errorMessages.ToList());
        }

        // GET: ErrorMessage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorMessage errorMessage = db.ErrorMessages.Find(id);
            if (errorMessage == null)
            {
                return HttpNotFound();
            }
            return View(errorMessage);
        }

        // GET: ErrorMessage/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            return View();
        }

        // POST: ErrorMessage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageID,ProjectID,ErrorDescription")] ErrorMessage errorMessage)
        {
            if (ModelState.IsValid)
            {
                db.ErrorMessages.Add(errorMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", errorMessage.ProjectID);
            return View(errorMessage);
        }

        // GET: ErrorMessage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorMessage errorMessage = db.ErrorMessages.Find(id);
            if (errorMessage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", errorMessage.ProjectID);
            return View(errorMessage);
        }

        // POST: ErrorMessage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageID,ProjectID,ErrorDescription")] ErrorMessage errorMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(errorMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", errorMessage.ProjectID);
            return View(errorMessage);
        }

        // GET: ErrorMessage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorMessage errorMessage = db.ErrorMessages.Find(id);
            if (errorMessage == null)
            {
                return HttpNotFound();
            }
            return View(errorMessage);
        }

        // POST: ErrorMessage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ErrorMessage errorMessage = db.ErrorMessages.Find(id);
            db.ErrorMessages.Remove(errorMessage);
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
