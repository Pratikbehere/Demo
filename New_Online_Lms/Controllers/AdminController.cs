using New_Online_Lms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_Online_Lms.Controllers
{
    public class AdminController : Controller
    {
        private Lms_DbContext db = new Lms_DbContext();

       
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Message = "Welcome to Admin Dashboard";
            ViewBag.UserId = Session["UserId"];
            return View();
        }

        
        public ActionResult ManageCourses()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Index", "Home");

            var courses = db.Courses.ToList();
            return View(courses);
        }

       
        public ActionResult AddCourse()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Index", "Home");

            return View();
        }

       
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("ManageCourses");
            }
            return View(course);
        }

        
        public ActionResult AssignInstructor(int id)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Index", "Home");

            var course = db.Courses.Find(id);
            if (course == null)
                return HttpNotFound();

            ViewBag.Instructors = new SelectList(db.Users.Where(u => u.Role == "Instructor"), "UserId", "Name");
            return View(course);
        }

     
        [HttpPost]
        public ActionResult AssignInstructor(int id, int instructorId)
        {
            var course = db.Courses.Find(id);
            if (course == null)
                return HttpNotFound();

            course.InstructorId = instructorId;
            db.SaveChanges();
            return RedirectToAction("ManageCourses");
        }

      
        public ActionResult ViewEnrollments()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Index", "Home");

            
            var enrollments = db.Enrollments.Include("Course").Include("Student").ToList();
            return View(enrollments);
        }
    }
}