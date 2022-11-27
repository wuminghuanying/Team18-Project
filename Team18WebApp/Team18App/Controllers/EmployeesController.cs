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
    public class EmployeesController : Controller
    {
        private team18dbEntities db = new team18dbEntities();
        // GET: Employees
        public ActionResult Index()
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            var employees = db.Employees.Include(e => e.Department).Include(e => e.User);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
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
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            ViewBag.UserID = new SelectList(db.Users, "id", "userName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,EmployeeID,Fname,Minit,Lname,DOB,Sex,DepartmentID,Hourly_rate")] Employee employee)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                User x = db.Users.FirstOrDefault(z => z.id == employee.UserID);
                x.role = 1;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", employee.DepartmentID);
            ViewBag.UserID = new SelectList(db.Users, "id", "userName", employee.UserID);
            return View(employee);
        }

        // GET: Employees/Edit/5
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
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", employee.DepartmentID);
            ViewBag.UserID = new SelectList(db.Users, "id", "userName", employee.UserID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,EmployeeID,Fname,Minit,Lname,DOB,Sex,DepartmentID,Hourly_rate")] Employee employee)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", employee.DepartmentID);
            ViewBag.UserID = new SelectList(db.Users, "id", "userName", employee.UserID);
            return View(employee);
        }

        // GET: Employees/Delete/5
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
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            Employee employee = db.Employees.Find(id);
            User y = db.Users.FirstOrDefault(z => z.id == employee.UserID);
            y.role = 3;
            db.Employees.Remove(employee);
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
