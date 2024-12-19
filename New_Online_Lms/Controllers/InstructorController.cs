using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_Online_Lms.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Message = "Welcome to Instructor Dashboard";
            ViewBag.UserId = Session["UserId"]; // Pass UserId to the view
            return View();
        }
    }
}