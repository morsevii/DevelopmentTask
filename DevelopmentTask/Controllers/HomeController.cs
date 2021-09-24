using DevelopmentTask.Models;
using DevelopmentTask.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevelopmentTask.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Redirect(string uid = "")
        {
            try
            {
                if (uid != "")
                {
                    //uid = uid.Decrypt();
                    string[] uids = uid.Split('|');
                    Session["Employee_ID"] = uids[0];
                    Session["System_level"] = uids[1];

                    GetUserInfo(uids[0]);

                    return RedirectToAction("MyTask", "Tasks");
                }
                else {
                    return RedirectToAction("ToRoyal", "Home");
                }

            }
            catch (Exception)
            {
                return RedirectToAction("ToRoyal", "Home");
            }
        }

        public void ToRoyal()
        {
            Response.Redirect(UsefulTools.GetBaseURL("dashboard.aspx"));
        }

        public void GetUserInfo(string username) {
            User u = new User();
            u = username.GetUserInfo();
            Session["FirstName"] = u.FirstName;
            Session["MiddleName"] = u.MiddleName;
            Session["LastName"] = u.LastName;
            Session["FullName"] = u.Fullname;
            Session["Department"] = u.Department;
            Session["Position"] = u.Position;
        } 
    }
}