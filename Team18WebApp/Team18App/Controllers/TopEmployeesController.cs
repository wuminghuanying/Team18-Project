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
    public class TopEmployeesController : Controller
    {
        // GET: TopEmployees
        int x;
        int y;
        int z;
        Entities entity = new Entities();

        public ActionResult getParamsTE()

        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult getParamsTE(TopEmployeesFormModel tmp)
        {
            if (ModelState.IsValid)
            {
                x = tmp.HoursWorked;
                y = tmp.deptNum; z = tmp.deptNum;
                return RedirectToAction("getTopEmployees");
            }
            return View();
        }
        public ActionResult getTopEmployees()
        {
            //Entities entity = new Entities();
            return View(entity.getTopEmployees(x,y,z));
        }

    }
}