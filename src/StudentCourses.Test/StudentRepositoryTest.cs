using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentCourses.Infrastructure.Repositories;
using StudentCourses.Infrastructure.DatabaseInitializers;
using StudentCourses.Domain.Models;

namespace StudentCourses.Test
{
    [TestClass]
    public class StudentRepositoryTest
    {
        StudentRepository repository;

        [TestInitialize]
        public void TestSetup()
        {
            StudentDataInitializer database = new StudentDataInitializer();
            System.Data.Entity.Database.SetInitializer(database);
            repository = new StudentRepository();
        }

        [TestMethod]
        public void IsRepositoryInitializedWithValidNumberOfData()
        {
            //Test if the database is correctly created
            var result = repository.GetAll();
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
                Id = 9,
                FirstName = "Steve",
                LastName = "Harris"
            };

            repository.Add(studentToAdd);
            //If student is inserted correctly rows number will be 9
            var result = repository.GetAll();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(9, numberOfRecords);
        }
    }
}
