using System.Web.Mvc;
using StudentCourses.Domain.Models;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Infrastructure.Repositories;

namespace StudentCourses.MVC.Controllers
{
    public class StudentsController : Controller
    {
        private IRepository<Student> _db = new StudentRepository();

        // GET: Students
        public ActionResult Index()
        {
            return View(_db.GetAll());
        }

        // GET: Students/Details/Id
        public ActionResult Details(int Id)
        {
            Student student = _db.FindById(Id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Add(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/Id
        public ActionResult Edit(int Id)
        {
            Student student = _db.FindById(Id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/Id
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Edit(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/Id
        public ActionResult Delete(int Id)
        {
            Student student = _db.FindById(Id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            _db.Remove(Id);
            return RedirectToAction("Index");
        }

    }
}
