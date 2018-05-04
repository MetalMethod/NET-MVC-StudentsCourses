using System.Collections.Generic;
using StudentCourses.Domain.Models;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Infrastructure.Repositories;

namespace StudentCourses.Infrastructure.Services.CourseService
{
    /// <summary>
    /// Service class for Course entity, containing Repositories Reference and Business Logic if needed.
    /// </summary>
    public class CourseService
    {
        /// <summary>
        /// The course repository instance.
        /// </summary>
        private IRepository<Course> courseRepository = new CourseRepository();

        /// <summary>
        /// Gets all courses.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Course> GetAll()
        {
            return courseRepository.GetAll();
        }

        /// <summary>
        /// Detailses the specified course by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Course Details(int Id)
        {
            return courseRepository.FindById(Id);
        }

        /// <summary>
        /// Adds the specified course.
        /// </summary>
        /// <param name="course">The course.</param>
        /// <returns></returns>
        public Course Add(Course course)
        {
            courseRepository.Add(course);
            return course;
        }

        /// <summary>
        /// Return the course to edit.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Course CourseToEdit(int Id)
        {
            return courseRepository.FindById(Id);
        }

        /// <summary>
        /// Edits the specified course.
        /// </summary>
        /// <param name="course">The course.</param>
        /// <returns></returns>
        public Course Edit(Course course)
        { 
            courseRepository.Edit(course);
            return course;
        }

        /// <summary>
        /// Returns the course to delete.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Course CourseToDelete(int Id)
        {
            return courseRepository.FindById(Id);
        }

        /// <summary>
        /// Deletes the confirmed course.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void DeleteConfirmed(int Id)
        {
            courseRepository.Remove(Id);
        }
    }
}
