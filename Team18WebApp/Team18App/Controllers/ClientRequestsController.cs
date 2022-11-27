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
    public class ClientRequestsController : Controller
    {
        private team18dbEntities db = new team18dbEntities();

        // GET: ClientRequests
        public ActionResult Index()
        {
            return View(db.ClientRequests.ToList());
        }

        // GET: ClientRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientRequest clientRequest = db.ClientRequests.Find(id);
            if (clientRequest == null)
            {
                return HttpNotFound();
            }
            return View(clientRequest);
        }

        // GET: ClientRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestDesc,RequestID")] ClientRequest clientRequest)
        {
            if (ModelState.IsValid)
            {
                db.ClientRequests.Add(clientRequest);
                db.SaveChanges();
                User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
                if (u.role == 3)
                {
                    return RedirectToAction("ClientIndex", "Home");
                }
                return RedirectToAction("Index");
            }

            return View(clientRequest);
        }

        // GET: ClientRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientRequest clientRequest = db.ClientRequests.Find(id);
            if (clientRequest == null)
            {
                return HttpNotFound();
            }
            return View(clientRequest);
        }

        // POST: ClientRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestDesc,RequestID")] ClientRequest clientRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientRequest);
        }

        // GET: ClientRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientRequest clientRequest = db.ClientRequests.Find(id);
            if (clientRequest == null)
            {
                return HttpNotFound();
            }
            return View(clientRequest);
        }

        // POST: ClientRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientRequest clientRequest = db.ClientRequests.Find(id);
            db.ClientRequests.Remove(clientRequest);
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
