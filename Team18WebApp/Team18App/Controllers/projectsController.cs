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
    public class projectsController : Controller
    {
        private Entities db = new Entities();

        // GET: projects
        public ActionResult Index()
        {
            var projects = db.projects.Include(p => p.department).Include(p => p.employee);
            return View(projects.ToList());
        }

        // GET: projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            project project = db.projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: projects/Create
        public ActionResult Create()
        {
            ViewBag.PROJECT_DEPT = new SelectList(db.departments, "DEPT_NUM", "dept_name");
            ViewBag.project_manager = new SelectList(db.employees, "SSN", "Fname");
            return View();
        }

        // POST: projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PROJECT_NUM,PROJECT_DEPT,project_manager,PROJECT_BUDGET,CURRENT_EXPENSES,project_deadline,project_status,project_name")] project project)
        {
            if (ModelState.IsValid)
            {
                db.projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PROJECT_DEPT = new SelectList(db.departments, "DEPT_NUM", "dept_name", project.PROJECT_DEPT);
            ViewBag.project_manager = new SelectList(db.employees, "SSN", "Fname", project.project_manager);
            return View(project);
        }

        // GET: projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            project project = db.projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROJECT_DEPT = new SelectList(db.departments, "DEPT_NUM", "dept_name", project.PROJECT_DEPT);
            ViewBag.project_manager = new SelectList(db.employees, "SSN", "Fname", project.project_manager);
            return View(project);
        }

        // POST: projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PROJECT_NUM,PROJECT_DEPT,project_manager,PROJECT_BUDGET,CURRENT_EXPENSES,project_deadline,project_status,project_name")] project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PROJECT_DEPT = new SelectList(db.departments, "DEPT_NUM", "dept_name", project.PROJECT_DEPT);
            ViewBag.project_manager = new SelectList(db.employees, "SSN", "Fname", project.project_manager);
            return View(project);
        }

        // GET: projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            project project = db.projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            project project = db.projects.Find(id);
            db.projects.Remove(project);
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
