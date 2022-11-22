using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team18App.Models;

namespace Team18App.Controllers
{
    public class getTaskInfoController : Controller
    {
        // GET: getTaskInfo
        int x;

        Entities entity = new Entities();

        public ActionResult getParamsTI()

        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult getParamsTI(getTaskInfoModel tmp)
        {
            if (ModelState.IsValid)
            {
                x = tmp.projectCode;

                return RedirectToAction("getTaskInfo");
            }
            return View();
        }
        public ActionResult getTaskInfo()
        {
            //Entities entity = new Entities();
            return View(entity.getTaskInfo(x));
        }

    }
}