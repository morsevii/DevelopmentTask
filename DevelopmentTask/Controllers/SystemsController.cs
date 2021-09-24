using DevelopmentTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevelopmentTask.Controllers
{
    public class SystemsController : Controller
    {
        // GET: Systems
        public ActionResult List()
        {
            if (string.IsNullOrEmpty((string)Session["Employee_ID"]))
            {
                return RedirectToAction("ToRoyal", "Home");
            }
            return View();
        }

        // GET: Tasks of System
        public ActionResult Tasks(string id,string id2)
        {
            if (id2 != null) ViewBag.SystemName = id2.Replace('_', ' ');
            ViewBag.SystemCode = id;

            return View();
        }

        // === AJAX Functions ===

        public JsonResult GetSystemList(string Search)
        {
            return Json(new { details = SystemsModel.GetList(Search) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSystemTask(string Code, string search) {
            TasksModel tm = new TasksModel();
            return Json(new { details = tm.GetSystemTask(Code, search) }, JsonRequestBehavior.AllowGet);
        }
    }
}