﻿using System.Linq;
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

        [TestInitialize]
        public void TestSetup()
        {
            StudentCoursesDataInitializer database = new StudentCoursesDataInitializer();
            System.Data.Entity.Database.SetInitializer(database);
            studentRepository = new StudentRepository();
            courseRepository = new CourseRepository();
        }

        // STUDENT REPOSITORY TESTS

        [TestMethod]
        public void IsStudentRepositoryGetAllCorrectly()
        {
            var result = studentRepository.GetAll();
            Assert.AreEqual(result.Count(), 9);
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
                Id = 9,
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
            Student studentToEdit = new Student
            {
                Id = 9,
                FirstName = "Steve",
                LastName = "Harris"
            };

            studentRepository.Edit(studentToEdit);
            var result = studentRepository.FindById(9);
            Assert.AreEqual(studentToEdit.Id, result.Id);
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
            Assert.AreEqual(result.Count(), 8);
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
                Id = 7,
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
                Id = 8,
                Name = "Canvas drawing"
            };

            courseRepository.Edit(courseToEdit);
            var result = courseRepository.FindById(8);
            Assert.AreEqual(courseToEdit.Id, result.Id);
        }

        [TestMethod]
        public void IsCourseRepositoryRemoveCorrectly()
        {
            var initalCount = courseRepository.GetAll().Count();
            courseRepository.Remove(8);
            var removedCount = courseRepository.GetAll().Count();
            Assert.AreNotEqual(initalCount, removedCount);
        }

    }
}
