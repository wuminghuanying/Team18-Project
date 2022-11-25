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
    public class WorksOnController : Controller
    {
        private team18dbEntities db = new team18dbEntities();

        // GET: WorksOn
        public ActionResult Index()
        {
            var worksOns = db.WorksOns.Include(w => w.Employee).Include(w => w.Project);
            return View(worksOns.ToList());
        }

        // GET: WorksOn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorksOn worksOn = db.WorksOns.Find(id);
            if (worksOn == null)
            {
                return HttpNotFound();
            }
            return View(worksOn);
        }

        // GET: WorksOn/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Fname");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectStatus");
            return View();
        }

        // POST: WorksOn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorksOnID,HoursWorked,ProjectID,EmployeeID")] WorksOn worksOn)
        {
            if (ModelState.IsValid)
            {
                db.WorksOns.Add(worksOn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Fname", worksOn.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectStatus", worksOn.ProjectID);
            return View(worksOn);
        }

        // GET: WorksOn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorksOn worksOn = db.WorksOns.Find(id);
            if (worksOn == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Fname", worksOn.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectStatus", worksOn.ProjectID);
            return View(worksOn);
        }

        // POST: WorksOn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorksOnID,HoursWorked,ProjectID,EmployeeID")] WorksOn worksOn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worksOn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Fname", worksOn.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectStatus", worksOn.ProjectID);
            return View(worksOn);
        }

        // GET: WorksOn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorksOn worksOn = db.WorksOns.Find(id);
            if (worksOn == null)
            {
                return HttpNotFound();
            }
            return View(worksOn);
        }

        // POST: WorksOn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorksOn worksOn = db.WorksOns.Find(id);
            db.WorksOns.Remove(worksOn);
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
