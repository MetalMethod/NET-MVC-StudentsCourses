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
        /// The registration repository instance
        /// </summary>
        private IRepository<Registration> _registrationRepository;

        /// <summary>
        /// The student repository instance
        /// </summary>
        private IRepository<Student> _studentRepository;

        /// <summary>
        /// The course repository instance
        /// </summary>
        private IRepository<Course> _courseRepository;

        /// <summary>
        /// The registration view model instance
        /// </summary>
        public RegistrationViewModel registrationViewModel;

        /// <summary>
        /// The hashcode generator for new registrations
        /// </summary>
        private IHashGenerator _hashGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationsController"/> class.
        /// Using Unity Dependency Injection
        /// </summary>
        /// <param name="registrationService">The registration service.</param>
        public RegistrationsController(
            IRepository<Registration> registrationRepository,
            IRepository<Student> studentRepository,
            IRepository<Course> courseRepository,
            IHashGenerator hashGenerator
            )
        {
            this._registrationRepository = registrationRepository;
            this._studentRepository = studentRepository;
            this._courseRepository = courseRepository;
            this._hashGenerator = hashGenerator;

            this.registrationViewModel = new RegistrationViewModel();
        }

        /// GET: Registrations
        public ActionResult Index()
        {
            //registrationViewModel.AvaliableStudents = _studentRepository.GetAll().ToList();
            //registrationViewModel.AvaliableCourses = _courseRepository.GetAll().ToList();
            registrationViewModel.CurrentRegistrations = _registrationRepository.GetAll().ToList();
  
            return View(registrationViewModel);
        }

        /// GET: Registrations/Details/5
        public ActionResult Details(int Id)
        {
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            Registration registration = _registrationRepository.FindById(Id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        /// GET: Registrations/Create
        public ActionResult Create()
        {
            registrationViewModel.AvaliableStudents = _studentRepository.GetAll().ToList();
            registrationViewModel.AvaliableCourses = _courseRepository.GetAll().ToList();
            
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
                    Student_ID = StudentToAdd,
                    Course_ID = CourseToAdd,
                    Student = _studentRepository.FindById(StudentToAdd),
                    Course = _courseRepository.FindById(CourseToAdd),
                    RegistrationKey = _hashGenerator.Generate(_studentRepository.FindById(StudentToAdd), _courseRepository.FindById(CourseToAdd))
                };

                _registrationRepository.Add(registrationToAdd);
                return RedirectToAction("Index");
            }

            return View(registrationViewmodel);
        }

        /// GET: Registrations/Edit/Id
        public ActionResult Edit(int Id)
        {
            registrationViewModel.AvaliableStudents = _studentRepository.GetAll().ToList();
            registrationViewModel.AvaliableCourses = _courseRepository.GetAll().ToList();

            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            Registration registration = _registrationRepository.FindById(Id);

            if (registration == null)
            {
                return HttpNotFound();
            }

            registrationViewModel.RegistrationToEdit = registration;

            return View(registrationViewModel);
        }

        /// POST: Registrations/Edit/Id
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistrationToEdit, RegistrationToEdit.ID, RegistrationToEdit.Student_ID, RegistrationToEdit.Course_ID")] RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                var ID = registrationViewModel.RegistrationToEdit.ID;
                var registrationToEdit = _registrationRepository.FindById(ID);

                registrationToEdit.Student_ID = registrationViewModel.RegistrationToEdit.Student_ID;
                registrationToEdit.Course_ID = registrationViewModel.RegistrationToEdit.Course_ID;

                registrationToEdit.Student = _studentRepository.FindById(registrationViewModel.RegistrationToEdit.Student_ID);
                registrationToEdit.Course = _courseRepository.FindById(registrationViewModel.RegistrationToEdit.Course_ID);
                
                registrationToEdit.RegistrationKey = _hashGenerator.Generate(registrationToEdit.Student, registrationToEdit.Course);

                _registrationRepository.Edit(registrationToEdit);

                return RedirectToAction("Index");
            }
            return View("Index");
        }

        /// GET: Registrations/Delete/Id
        public ActionResult Delete(int Id)
        {
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            Registration registration = _registrationRepository.FindById(Id);
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
            if (Id.Equals(null))
            {
                return HttpNotFound();
            }

            _registrationRepository.Remove(Id);
            return RedirectToAction("Index");
        }
    }
}
