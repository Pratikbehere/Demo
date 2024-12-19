using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_Online_Lms.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Message = "Welcome to Student Dashboard";
            ViewBag.UserId = Session["UserId"]; 
            return View();
        }
    }
}