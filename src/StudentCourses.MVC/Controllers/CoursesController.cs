using System.Web.Mvc;
using StudentCourses.Domain.Models;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Infrastructure.Repositories;

namespace StudentCourses.MVC.Controllers
{
    public class CoursesController : Controller
    {
        private IRepository<Course> _db = new CourseRepository();

        // GET: Courses
        public ActionResult Index()
        {
            return View(_db.GetAll());
        }

        // GET: Courses/Details/Id
        public ActionResult Details(int Id)
        {
            Course course = _db.FindById(Id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Course course)
        {
            if (ModelState.IsValid)
            {
                _db.Add(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/Id
        public ActionResult Edit(int Id)
        {
            Course course = _db.FindById(Id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/Id
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Course course)
        {
            if (ModelState.IsValid)
            {
                _db.Edit(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/Id
        public ActionResult Delete(int Id)
        {
            Course course = _db.FindById(Id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            _db.Remove(Id);
            return RedirectToAction("Index");
        }

    }
}
