using System.Web.Mvc;
using StudentCourses.Domain.Models;
using StudentCourses.Domain.Interfaces;

namespace StudentCourses.MVC.Controllers
{
    /// <summary>
    /// The Course Controller class.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class CoursesController : Controller
    {
        /// <summary>
        /// The course repository instance.
        /// </summary>
        private IRepository<Course> _courseRepository;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CoursesController"/> class.
        /// Using Unity Dependency Injection.
        /// </summary>
        /// <param name="_courseRepository">The course service.</param>
        public CoursesController(IRepository<Course> courseRepository)
        {
            this._courseRepository = courseRepository;
        }

        /// GET: Courses
        public ActionResult Index()
        {
            return View(_courseRepository.GetAll());
        }

        /// GET: Courses/Details/Id
        public ActionResult Details(int Id)
        {
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            Course course = _courseRepository.FindById(Id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        /// GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        /// POST: Courses/Create
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Vacancies")] Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Add(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        /// GET: Courses/Edit/Id
        public ActionResult Edit(int Id)
        {
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            Course course = _courseRepository.FindById(Id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        /// POST: Courses/Edit/Id
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name, Vacancies")] Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Edit(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        /// GET: Courses/Delete/Id
        public ActionResult Delete(int Id)
        {
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            Course course = _courseRepository.FindById(Id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        /// POST: Courses/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            _courseRepository.Remove(Id);
            return RedirectToAction("Index");
        }

    }
}
