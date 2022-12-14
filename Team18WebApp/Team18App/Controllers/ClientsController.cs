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
    public class ClientsController : Controller
    {
        private team18dbEntities db = new team18dbEntities();
        // GET: Clients
        public ActionResult Index()
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            var clients = db.Clients.Include(c => c.User);
            return View(clients.ToList());
        }

        // GET: Clients/Details/5
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
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            ViewBag.UserID = new SelectList(db.Users, "id", "userName");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,UserID,Fname,Minit,Lname")] Client client)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "id", "userName", client.UserID);
            return View(client);
        }

        // GET: Clients/Edit/5
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
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "id", "userName", client.UserID);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,UserID,Fname,Minit,Lname")] Client client)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "id", "userName", client.UserID);
            return View(client);
        }

        // GET: Clients/Delete/5
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
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 1 || u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
