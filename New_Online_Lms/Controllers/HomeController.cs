using New_Online_Lms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_Online_Lms.Controllers
{
    public class HomeController : Controller
    {
       Lms_DbContext db= new Lms_DbContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password, string role)
        {
            
            var user = db.Users.FirstOrDefault(u =>
                u.Email == email && u.Password == password && u.Role == role);

            if (user != null)
            {
                
                Session["UserId"] = user.UserId;

               
                if (user.Role == "Admin")
                    return RedirectToAction("Index", "Admin");
                else if (user.Role == "Student")
                    return RedirectToAction("Index", "Student");
                else if (user.Role == "Instructor")
                    return RedirectToAction("Index", "Instructor");
            }

            
            TempData["Error"] = "Invalid email, password, or role.";
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
           
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
