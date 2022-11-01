using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Team18App.Models;

namespace Team18App.Controllers
{
    public class AccountController : Controller
    {
        Entities entity = new Entities();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExists = entity.UsersTbls.Any(x => x.Email == credentials.Email && x.Passccode == credentials.Password);
            UsersTbl u = entity.UsersTbls.FirstOrDefault(x => x.Email == credentials.Email && x.Passccode == credentials.Password);
            if (userExists)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Username or Password is wrong");

            return View();
        }
        [HttpPost]
        public ActionResult Signup(UsersTbl userinfo)
        {
            entity.UsersTbls.Add(userinfo);
            entity.SaveChanges();
            return RedirectToAction("Login");
        }
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}