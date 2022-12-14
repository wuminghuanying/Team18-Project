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
    public class UsersController : Controller
    {
        private team18dbEntities db = new team18dbEntities();
        // GET: Users
        public ActionResult Index()
        {
            User z = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (z.role != 2)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            var users = db.Users.Include(u => u.Role1);
            return View(users.ToList());
        }

        public ActionResult SearchForm()
        {

            var users = db.Users.Include(u => u.Role1);
            return View();
        }

        public ActionResult ShowSearchResults(String SearchPhrase)
        {
            var users = db.Users.Include(u => u.Role1);
            return View("Index", users.Where(t => t.userName.Contains(SearchPhrase)).ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role != 2)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role != 2)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            ViewBag.role = new SelectList(db.Roles, "roleId", "roleName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,role,userName,password")] User user)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role != 2)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.role = new SelectList(db.Roles, "roleId", "roleName", user.role);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role != 2)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.role = new SelectList(db.Roles, "roleId", "roleName", user.role);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,role,userName,password")] User user)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role != 2)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.role = new SelectList(db.Roles, "roleId", "roleName", user.role);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role != 2)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role != 2)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
