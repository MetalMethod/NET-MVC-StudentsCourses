using System;
using System.Linq;
using System.Web.Mvc;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Domain.Models;
using StudentCourses.MVC.ViewModels;

namespace StudentCourses.MVC.Controllers
{
    /// <summary>
    /// THe Registration Controller class
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class RegistrationsController : Controller
    {
        /// <summary>
        /// The registration service instance
        /// </summary>
        private IRepositoryService<Registration> registrationService;

        /// <summary>
        /// The student service instance
        /// </summary>
        private IRepositoryService<Student> studentService;

        /// <summary>
        /// The course service instance
        /// </summary>
        private IRepositoryService<Course> courseService;

        /// <summary>
        /// The registration view model instance
        /// </summary>
        public RegistrationViewModel registrationViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationsController"/> class.
        /// Using Unity Dependency Injection
        /// </summary>
        /// <param name="registrationService">The registration service.</param>
        public RegistrationsController(
            IRepositoryService<Registration> registrationService,
            IRepositoryService<Student> studentService,
            IRepositoryService<Course> courseService
            )
        {
            this.registrationService = registrationService;
            this.studentService = studentService;
            this.courseService = courseService;

            this.registrationViewModel = new RegistrationViewModel();
        }

        /// GET: Registrations
        public ActionResult Index()
        {
            registrationViewModel.AvaliableStudents = studentService.GetAll().ToList();
            registrationViewModel.AvaliableCourses = courseService.GetAll().ToList();

            registrationViewModel.CurrentRegistrations = registrationService.GetAll().ToList();
  

            return View(registrationViewModel);
        }

        /// GET: Registrations/Details/5
        public ActionResult Details(int Id)
        {
            Registration registration = registrationService.Details(Id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        /// GET: Registrations/Create
        public ActionResult Create()
        {
            registrationViewModel.AvaliableStudents = studentService.GetAll().ToList();
            registrationViewModel.AvaliableCourses = courseService.GetAll().ToList();
            
            return View(registrationViewModel);
        }

        /// POST: Registrations/Create
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentToRegister, CourseToRegister")] RegistrationViewModel registrationViewmodel)
        {
            if (ModelState.IsValid)
            {
                int StudentToAdd = Int32.Parse(registrationViewmodel.StudentToRegister);
                int CourseToAdd = Int32.Parse(registrationViewmodel.CourseToRegister);

                Registration registrationToAdd = new Registration
                {
                    StudentId = StudentToAdd,
                    CourseId = CourseToAdd,
                    RegisterKey = "formSubmitted"
                };

                registrationService.Add(registrationToAdd);
                return RedirectToAction("Index");
            }

            return View(registrationViewmodel);
        }

        /// GET: Registrations/Edit/Id
        public ActionResult Edit(int Id)
        {
            Registration registration = registrationService.ToEdit(Id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        /// POST: Registrations/Edit/Id
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, StudentId, CourseId, RegisterKey")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                registrationService.Edit(registration);
                return RedirectToAction("Index");
            }
            return View(registration);
        }

        /// GET: Registrations/Delete/Id
        public ActionResult Delete(int Id)
        {
            Registration registration = registrationService.ToDelete(Id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        /// POST: Registrations/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            registrationService.DeleteConfirmed(Id);
            return RedirectToAction("Index");
        }
    }
}
