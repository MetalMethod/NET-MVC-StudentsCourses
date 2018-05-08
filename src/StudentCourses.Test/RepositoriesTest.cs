using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentCourses.Infrastructure.Repositories;
using StudentCourses.Infrastructure.DatabaseInitializers;
using StudentCourses.Domain.Models;

namespace StudentCourses.Test
{
    [TestClass]
    public class RepositoriesTest
    {
        private StudentRepository studentRepository;
        private CourseRepository courseRepository;
        private RegistrationRepository registrationRepository;

        [TestInitialize]
        public void TestSetup()
        {
            StudentCoursesDataInitializer database = new StudentCoursesDataInitializer();
            System.Data.Entity.Database.SetInitializer(database);

            studentRepository = new StudentRepository();
            courseRepository = new CourseRepository();
            registrationRepository = new RegistrationRepository();
        }

        // STUDENT REPOSITORY TESTS

        [TestMethod]
        public void IsStudentRepositoryGetAllCorrectly()
        {
            var result = studentRepository.GetAll();
            Assert.AreEqual(result.Count(), 8);
        }

        [TestMethod]
        public void IsStudentRepositoryInitializedWithValidNumberOfData()
        {
            //Test if the database is correctly created
            var result = studentRepository.GetAll();
            Assert.IsNotNull(result);

            //Test if numbers of initil records is correct
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(8, numberOfRecords);
        }

        [TestMethod]
        public void IsStudentRepositoryAddingStudent()
        {
            Student studentToAdd = new Student
            {
                StudentId = 9,
                FirstName = "Steve",
                LastName = "Harris"
            };

            studentRepository.Add(studentToAdd);
            //If student is inserted correctly rows number will be 9
            var result = studentRepository.GetAll();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(9, numberOfRecords);
        }

        [TestMethod]
        public void IsStudentRepositoryFindByIdCorrectly()
        {
            var findObject = studentRepository.FindById(2);
            Assert.AreEqual(findObject.FirstName, "Paul");
        }

        [TestMethod]
        public void IsStudentRepositoryEditingStudent()
        {
            var result = studentRepository.FindById(1);

            Student studentToEdit = new Student
            {
                StudentId = 1,
                FirstName = "Steve",
                LastName = "Harris"
            };

            studentRepository.Edit(studentToEdit);
            Assert.AreEqual(studentToEdit.StudentId, result.StudentId);
        }

        [TestMethod]
        public void IsStudentRepositoryRemoveCorrectly()
        {
            var initalCount = studentRepository.GetAll().Count();
            studentRepository.Remove(9);
            var removedCount = studentRepository.GetAll().Count();
            Assert.AreNotEqual(initalCount, removedCount);
        }

        // COURSE REPOSITORY TESTS

        [TestMethod]
        public void IsCourseRepositoryGetAllCorrectly()
        {
            var result = courseRepository.GetAll();
            Assert.AreEqual(result.Count(), 6);
        }

        [TestMethod]
        public void IsCourseRepositoryInitializedWithValidNumberOfData()
        {
            // Test if the database is correctly created
            var result = courseRepository.GetAll();
            Assert.IsNotNull(result);

            //Test if number of initial records is correct
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(6, numberOfRecords);
        }

        [TestMethod]
        public void IsCourseRepositoryAddingCourse()
        {
            Course courseToAdd = new Course
            {
                CourseId = 7,
                Name = "Reactive Programming"
            };

            courseRepository.Add(courseToAdd);
            //If course is inserted correctly rows number will be 7
            var result = courseRepository.GetAll();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(7, numberOfRecords);
        }

        [TestMethod]
        public void IsCourseRepositoryFindByIdCorrectly()
        {
            var findObject = courseRepository.FindById(4);
            Assert.AreEqual(findObject.Name, "NET MVC");
        }

        [TestMethod]
        public void IsCourseRepositoryEditingCourse()
        {
            Course courseToEdit = new Course
            {
                CourseId = 1,
                Name = "Canvas drawing"
            };

            var result = courseRepository.FindById(1);
            courseRepository.Edit(courseToEdit);
            Assert.AreEqual(courseToEdit.CourseId, result.CourseId);
        }

        [TestMethod]
        public void IsCourseRepositoryRemoveCorrectly()
        {
            var initalCount = courseRepository.GetAll().Count();
            courseRepository.Remove(7);
            var removedCount = courseRepository.GetAll().Count();
            Assert.AreNotEqual(initalCount, removedCount);
        }

        // REGISTRATION REPOSITORY TESTS

        [TestMethod]
        public void IsRegistrationRepositoryGetAllCorrectly()
        {
            var result = registrationRepository.GetAll();
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void IsRegistrationRepositoryInitializedWithValidNumberOfData()
        {
            // Test if the database is correctly created
            var result = registrationRepository.GetAll();
            Assert.IsNotNull(result);

            //Test if number of initial records is correct
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(2, numberOfRecords);
        }

        [TestMethod]
        public void IsRegistrationRepositoryAddingRegistration()
        {
            Registration registrationToAdd = new Registration
            {
                StudentId = 1,
                CourseId = 1,
                RegisterKey = "3333cccc"
            };

            registrationRepository.Add(registrationToAdd);
            //If course is inserted correctly rows number will be 3
            var result = registrationRepository.GetAll();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(3, numberOfRecords);
        }

        [TestMethod]
        public void IsRegistrationRepositoryFindByIdCorrectly()
        {
            var findObject = registrationRepository.FindById(2);
            Assert.AreEqual(findObject.RegisterKey, "2222bbbb");
        }

        [TestMethod]
        public void IsRegistrationRepositoryEditingRegistration()
        {
            Registration registrationToEdit = new Registration
            {
                Id = 1,
                StudentId = 4,
                CourseId = 4,
                RegisterKey = "editedKeyInTests"
            };

            var result = registrationRepository.FindById(1);
            registrationRepository.Edit(registrationToEdit);
            Assert.AreEqual(registrationToEdit.CourseId, result.CourseId);
        }

        [TestMethod]
        public void IsRegistrationRepositoryRemoveCorrectly()
        {
            var initalCount = registrationRepository.GetAll().Count();
            registrationRepository.Remove(2);
            var removedCount = registrationRepository.GetAll().Count();
            Assert.AreNotEqual(initalCount, removedCount);
        }
    }
}
