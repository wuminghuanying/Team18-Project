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
    public class DepartmentsController : Controller
    {
        private team18dbEntities db = new team18dbEntities();
        // GET: Departments
        public ActionResult Index()
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            var departments = db.Departments.Include(d => d.Employee);
            if (u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            return View(departments.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            ViewBag.DepartmentManagerID = new SelectList(db.Employees, "EmployeeID", "Fname");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentID,DepartmentName,DepartmentManagerID")] Department department)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentManagerID = new SelectList(db.Employees, "EmployeeID", "Fname", department.DepartmentManagerID);
            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentManagerID = new SelectList(db.Employees, "EmployeeID", "Fname", department.DepartmentManagerID);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentID,DepartmentName,DepartmentManagerID")] Department department)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentManagerID = new SelectList(db.Employees, "EmployeeID", "Fname", department.DepartmentManagerID);
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
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
