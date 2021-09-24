using DevelopmentTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevelopmentTask.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult All()
        {
            if (string.IsNullOrEmpty((string)Session["Employee_ID"]))
            {
                return RedirectToAction("ToRoyal", "Home");
            }
            return View();
        }
        public ActionResult MyTask() {
            if (string.IsNullOrEmpty((string)Session["Employee_ID"]))
            {
                return RedirectToAction("ToRoyal", "Home");
            }
            return View();
        }


        // == AJAX Functions ==
        public JsonResult GetMyTask(string search)
        {
            string id = Session["Employee_ID"].ToString();

            TasksModel tm = new TasksModel();
            return Json(new { details = tm.GetUserTask(id, search).ToArray() }, JsonRequestBehavior.AllowGet);
        }
        
        // == AJAX Functions ==
        public JsonResult GetAllTask(string search)
        {
            TasksModel tm = new TasksModel();
            return Json(new { details = tm.GetAllTask(search).ToArray() }, JsonRequestBehavior.AllowGet);
        }
        
        // GET: System List
        public JsonResult SystemList()
        {
            TasksModel tm = new TasksModel();
            return Json(new { details = SystemsModel.GetList("").ToArray() }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllMIS()
        {
            TasksModel tm = new TasksModel();
            return Json(new { details = tm.GetAllMIS().ToArray() }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllEmployee()
        {
            TasksModel tm = new TasksModel();
            return Json(new { details = tm.GetAllEmployee().ToArray() }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AddTask(Task obj)
        {
            obj.EncBy = Session["Employee_ID"].ToString();
            TasksModel tm = new TasksModel();
            return Json(new { details = tm.AddTask(obj) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DoneTask(Task obj)
        {
            obj.DoneBy = Session["Employee_ID"].ToString();
            TasksModel tm = new TasksModel();
            return Json(new { details = tm.DoneTask(obj) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTask(int id)
        {
            TasksModel tm = new TasksModel();
            return Json(new { details = tm.GetTask(id) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateTask(Task obj)
        {
            obj.ModBy = Session["Employee_ID"].ToString();
            TasksModel tm = new TasksModel();
            return Json(new { details = tm.UpdateTask(obj) }, JsonRequestBehavior.AllowGet);
        }


        // API : GetSystemTask
        public JsonResult API_SystemTask(string _code) {

            TasksModel tm = new TasksModel();
            return Json(new { details = tm.API_SystemTask(_code) },JsonRequestBehavior.AllowGet); 
        }
    }
}