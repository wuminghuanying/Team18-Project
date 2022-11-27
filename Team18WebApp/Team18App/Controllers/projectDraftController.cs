using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team18App.Models;

namespace Team18App.Controllers
{
    public class projectDraftController : Controller
    {
        team18dbEntities db = new team18dbEntities();
        // GET: projectDraft
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }
        [HttpPost]
        public ActionResult Index(int id)
        {
            return View(db.projectDraft(id));
        }
    }
}