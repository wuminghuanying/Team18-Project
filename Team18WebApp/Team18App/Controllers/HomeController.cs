using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team18App.Models;
namespace Team18App.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private team18dbEntities db = new team18dbEntities();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ClientIndex()
        {
            return View();
        }
        public ActionResult EmployeeIndex()
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 3)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            return View();
        }
        public ActionResult DepartmentHeadIndex()
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role == 3 || u.role == 1)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            return View();
        }
        public ActionResult AdminIndex()
        {
            User u = db.Users.FirstOrDefault(x => x.userName == User.Identity.Name);
            if (u.role != 2)
            {
                return RedirectToAction("InsufficientPerms", "Home");
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult InsufficientPerms()
        {
            return View();
        }
    }
}