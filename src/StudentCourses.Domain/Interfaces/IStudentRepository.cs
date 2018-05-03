using System.Collections.Generic;
using StudentCourses.Domain.Models;

namespace StudentCourses.Domain.Interfaces
{
    /// <summary>
    /// This is the repository interface for the Student entity.
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Adds the specified student.
        /// </summary>
        /// <param name="student">The student.</param>
        void Add(Student student);

        /// <summary>
        /// Edits the specified student.
        /// </summary>
        /// <param name="student">The student.</param>
        void Edit(Student student);

        /// <summary>
        /// Removes the specified student by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        void Remove(int Id);

        /// <summary>
        /// Gets all existing students.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Student> GetAll();

        /// <summary>
        /// Finds the student by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Student FindById(int Id);
    }
}
