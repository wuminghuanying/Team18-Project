using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Team18App.Models;
using System.Linq;

namespace Team18App.Controllers
{
    public class AccountsController : Controller
    {
        team18dbEntities entity = new team18dbEntities();
        // GET: Accounts
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
            bool userExist = entity.Users.Any(x => x.userName == credentials.Username && x.password == credentials.Password);
            User u = entity.Users.FirstOrDefault(x => x.userName == credentials.Username && x.password == credentials.Password);
            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.userName, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Username or Password is wrong");
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User userinfo)
        {
            userinfo.role = 3;
            entity.Users.Add(userinfo);
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