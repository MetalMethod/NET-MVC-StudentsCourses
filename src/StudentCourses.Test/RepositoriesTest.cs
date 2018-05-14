using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentCourses.Infrastructure.Repositories;
using StudentCourses.Domain.Models;

namespace StudentCourses.Test
{
    [TestClass]
    public class RepositoriesTest
    {
        private StudentRepository _studentRepository;
        private CourseRepository _courseRepository;
        private RegistrationRepository _registrationRepository;

        [TestInitialize]
        public void TestSetup()
        {
            _studentRepository = new StudentRepository();
            _courseRepository = new CourseRepository();
            _registrationRepository = new RegistrationRepository();
        }

        // STUDENT REPOSITORY TESTS

        [TestMethod]
        public void IsStudentRepositoryGetAllCorrectly()
        {
            var result = _studentRepository.GetAll();
            Assert.AreEqual(result.Count(), 8);
        }

        [TestMethod]
        public void IsStudentRepositoryAddingStudent()
        {
            Student studentToAdd = new Student
            {
                ID = 9,
                FirstName = "Steve",
                LastName = "Harris"
            };

            _studentRepository.Add(studentToAdd);
            //If student is inserted correctly rows number will be 9
            var result = _studentRepository.GetAll();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(9, numberOfRecords);
        }

        [TestMethod]
        public void IsStudentRepositoryFindByIdCorrectly()
        {
            var findObject = _studentRepository.FindById(2);
            Assert.AreEqual(findObject.FirstName, "Paul");
        }

        [TestMethod]
        public void IsStudentRepositoryEditingStudent()
        {
            var result = _studentRepository.FindById(1);

            Student studentToEdit = new Student
            {
                ID = 1,
                FirstName = "Steve",
                LastName = "Harris"
            };

            _studentRepository.Edit(studentToEdit);
            Assert.AreEqual(studentToEdit.ID, result.ID);
        }

        [TestMethod]
        public void IsStudentRepositoryRemoveCorrectly()
        {
            var initalCount = _studentRepository.GetAll().Count();
            _studentRepository.Remove(9);
            var removedCount = _studentRepository.GetAll().Count();
            Assert.AreNotEqual(initalCount, removedCount);
        }

        // COURSE REPOSITORY TESTS

        [TestMethod]
        public void IsCourseRepositoryGetAllCorrectly()
        {
            var result = _courseRepository.GetAll();
            Assert.AreEqual(result.Count(), 6);
        }

        [TestMethod]
        public void IsCourseRepositoryAddingCourse()
        {
            Course courseToAdd = new Course
            {
                ID = 7,
                Name = "Reactive Programming"
            };

            _courseRepository.Add(courseToAdd);
            //If course is inserted correctly rows number will be 7
            var result = _courseRepository.GetAll();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(7, numberOfRecords);
        }

        [TestMethod]
        public void IsCourseRepositoryFindByIdCorrectly()
        {
            var findObject = _courseRepository.FindById(4);
            Assert.AreEqual(findObject.Name, "NET MVC");
        }

        [TestMethod]
        public void IsCourseRepositoryEditingCourse()
        {
            Course courseToEdit = new Course
            {
                ID = 1,
                Name = "Canvas drawing"
            };

            var result = _courseRepository.FindById(1);
            _courseRepository.Edit(courseToEdit);
            Assert.AreEqual(courseToEdit.ID, result.ID);
        }

        [TestMethod]
        public void IsCourseRepositoryRemoveCorrectly()
        {
            var initalCount = _courseRepository.GetAll().Count();
            _courseRepository.Remove(7);
            var removedCount = _courseRepository.GetAll().Count();
            Assert.AreNotEqual(initalCount, removedCount);
        }

        // REGISTRATION REPOSITORY TESTS

        [TestMethod]
        public void IsRegistrationRepositoryGetAllCorrectly()
        {
            var result = _registrationRepository.GetAll();
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void IsRegistrationRepositoryAddingRegistration()
        {
            Registration registrationToAdd = new Registration
            {
                Student_ID = 1,
                Course_ID = 1,
                RegistrationKey = "3333cccc"
            };

            _registrationRepository.Add(registrationToAdd);
            //If course is inserted correctly rows number will be 3
            var result = _registrationRepository.GetAll();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(3, numberOfRecords);
        }

        [TestMethod]
        public void IsRegistrationRepositoryFindByIdCorrectly()
        {
            var findObject = _registrationRepository.FindById(2);
            Assert.AreEqual(findObject.RegistrationKey, "2222bbbb");
        }

        [TestMethod]
        public void IsRegistrationRepositoryEditingRegistration()
        {
            Registration registrationToEdit = new Registration
            {
                ID = 1,
                Student_ID = 4,
                Course_ID = 4,
                RegistrationKey = "editedKeyInTests"
            };

            var result = _registrationRepository.FindById(1);
            _registrationRepository.Edit(registrationToEdit);
            Assert.AreEqual(registrationToEdit.ID, result.ID);
        }

        [TestMethod]
        public void IsRegistrationRepositoryRemoveCorrectly()
        {
            var initalCount = _registrationRepository.GetAll().Count();
            _registrationRepository.Remove(2);
            var removedCount = _registrationRepository.GetAll().Count();
            Assert.AreNotEqual(initalCount, removedCount);
        }
    }
}
