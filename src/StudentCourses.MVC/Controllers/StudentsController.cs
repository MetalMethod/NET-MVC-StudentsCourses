using System.Web.Mvc;
using StudentCourses.Domain.Models;
using StudentCourses.Domain.Interfaces;

namespace StudentCourses.MVC.Controllers
{
    /// <summary>
    /// The Student Controller class.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class StudentsController : Controller
    {
        /// <summary>
        /// The student repository instance.
        /// </summary>
        private IRepository<Student> _studentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentsController"/> class.
        /// Using Unity Dependency Injection
        /// </summary>
        /// <param name="_studentRepository">The student service.</param>
        public StudentsController(IRepository<Student> _studentRepository)
        {
            this._studentRepository = _studentRepository;
        }

        /// GET: Students
        public ActionResult Index()
        {
            return View(_studentRepository.GetAll());
        }

        /// GET: Students/Details/Id
        public ActionResult Details(int Id)
        {
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            Student student = _studentRepository.FindById(Id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        /// GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        /// POST: Students/Create
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Add(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        /// GET: Students/Edit/Id
        public ActionResult Edit(int Id)
        {
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            Student student = _studentRepository.FindById(Id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        /// POST: Students/Edit/Id
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Edit(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        /// GET: Students/Delete/Id
        public ActionResult Delete(int Id)
        {
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            Student student = _studentRepository.FindById(Id);
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
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            _studentRepository.Remove(Id);
            return RedirectToAction("Index");
        }
  
    }
}
