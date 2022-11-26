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
        [Authorize]
    public class ProjectsController : Controller
    {
        private team18dbEntities db = new team18dbEntities();
        // GET: Projects
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.Department).Include(p => p.Employee);
            return View(projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            ViewBag.ProjectDept = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            ViewBag.ProjectManagerID = new SelectList(db.Employees, "EmployeeID", "Fname");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectID,ProjectDept,ProjectManagerID,ProjectBudget,CurrentExpenses,ProjectDeadline,ProjectName")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectDept = new SelectList(db.Departments, "DepartmentID", "DepartmentName", project.ProjectDept);
            ViewBag.ProjectManagerID = new SelectList(db.Employees, "EmployeeID", "Fname", project.ProjectManagerID);
            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectDept = new SelectList(db.Departments, "DepartmentID", "DepartmentName", project.ProjectDept);
            ViewBag.ProjectManagerID = new SelectList(db.Employees, "EmployeeID", "Fname", project.ProjectManagerID);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectID,ProjectDept,ProjectManagerID,ProjectBudget,CurrentExpenses,ProjectDeadline,ProjectName")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectDept = new SelectList(db.Departments, "DepartmentID", "DepartmentName", project.ProjectDept);
            ViewBag.ProjectManagerID = new SelectList(db.Employees, "EmployeeID", "Fname", project.ProjectManagerID);
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
