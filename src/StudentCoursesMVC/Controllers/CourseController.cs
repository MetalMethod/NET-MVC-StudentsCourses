using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCoursesMVC.Controllers
{
    public class CourseController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentList
        public string List()
        {
            return "this is a Course list page.";
        }

        // GET: PrintParams given in the URL
        public string PrintParams(string name, int ID = 1)
        {
            return HttpUtility.HtmlEncode("Course " + name + ", ID: " + ID);
        }
    }
}