using System.Web.Mvc;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.Services.StudentService;

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
        private StudentService studentService = new StudentService();

        /// GET: Students
        public ActionResult Index()
        {
            return View(studentService.GetAll());
        }

        /// GET: Students/Details/Id
        public ActionResult Details(int Id)
        {
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
            Student student = studentService.StudentToEdit(Id);
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
            Student student = studentService.StudentToDelete(Id);
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
            studentService.DeleteConfirmed(Id);
            return RedirectToAction("Index");
        }
  
    }
}
