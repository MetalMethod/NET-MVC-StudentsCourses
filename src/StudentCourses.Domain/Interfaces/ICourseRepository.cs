using System.Collections.Generic;
using StudentCourses.Domain.Models;

namespace StudentCourses.Domain.Interfaces
{
    /// <summary>
    /// This is the repository interface for the Course entity.
    /// </summary>
    public interface ICourseRepository
    {
        /// <summary>
        /// Adds the specified course.
        /// </summary>
        /// <param name="course">The course.</param>
        void Add(Course course);

        /// <summary>
        /// Edits the specified course.
        /// </summary>
        /// <param name="course">The student.</param>
        void Edit(Course course);

        /// <summary>
        /// Removes the specified course by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        void Remove(int Id);

        /// <summary>
        /// Gets all existing courses.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Course> GetAll();

        /// <summary>
        /// Finds the course by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Course FindById(int Id);
    }
}
