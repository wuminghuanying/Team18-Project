using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team18App.Models;

namespace Team18App.Controllers
{
    public class getProjectInfoController : Controller
    {
        // GET: getProjectInfo
        int x;
        Entities entity = new Entities();
        public ActionResult getParamsPI()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult getParamsPI(getProjectInfoFormModel tmp)
        {
            if(ModelState.IsValid)
            {
                x = tmp.project_ID;
                return RedirectToAction("getProjectInfo");
            }
            return View();
        }

        public ActionResult getProjectInfo()
        {
            return View(entity.getProjectInfo(x));
        }
    }
}