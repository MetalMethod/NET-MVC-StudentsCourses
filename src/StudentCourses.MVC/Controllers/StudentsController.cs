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
        /// The student service instance.
        /// </summary>
        private IRepositoryService<Student> studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentsController"/> class.
        /// Using Unity Dependency Injection
        /// </summary>
        /// <param name="studentService">The student service.</param>
        public StudentsController(IRepositoryService<Student> studentService)
        {
            this.studentService = studentService;
        }

        /// GET: Students
        public ActionResult Index()
        {
            return View(studentService.GetAll());
        }

        /// GET: Students/Details/Id
        public ActionResult Details(int Id)
        {
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            Student student = studentService.Details(Id);
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
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentService.Add(student);
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

            Student student = studentService.ToEdit(Id);
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
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentService.Edit(student);
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

            Student student = studentService.ToDelete(Id);
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

            studentService.DeleteConfirmed(Id);
            return RedirectToAction("Index");
        }
  
    }
}
