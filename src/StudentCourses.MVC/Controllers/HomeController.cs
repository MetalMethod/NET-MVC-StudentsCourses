using System.Web.Mvc;

namespace StudentCourses.MVC.Controllers
{
    /// <summary>
    /// Home Page View Controller.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Abouts this App.
        /// Currently not used.
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Developed in Visual Studio 2017, as trainning for .NET entrepise applications development.";

            return View();
        }
    }
}