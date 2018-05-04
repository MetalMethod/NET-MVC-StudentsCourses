using System.Collections.Generic;
using StudentCourses.Domain.Models;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Infrastructure.Repositories;

namespace StudentCourses.Infrastructure.Services.StudentService
{
    /// <summary>
    /// Service class for Student entity, containing Repositories Reference and Business Logic if needed.
    /// </summary>
    public class StudentService
    {
        /// <summary>
        /// The student repository instance.
        /// </summary>
        private IRepository<Student> studentRepository = new StudentRepository();

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetAll()
        {
            return studentRepository.GetAll();
        }

        /// <summary>
        /// Detailses the specified student by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Student Details(int Id)
        {
            return studentRepository.FindById(Id);
        }

        /// <summary>
        /// Adds the specified student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        public Student Add(Student student)
        {
            studentRepository.Add(student);
            return student;
        }

        /// <summary>
        /// Return the student to edit.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Student StudentToEdit(int Id)
        {
            return studentRepository.FindById(Id);
        }

        /// <summary>
        /// Edits the specified student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        public Student Edit(Student student)
        { 
            studentRepository.Edit(student);
            return student;
        }

        /// <summary>
        /// Returns the student to delete.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Student StudentToDelete(int Id)
        {
            return studentRepository.FindById(Id);
        }

        /// <summary>
        /// Deletes the confirmed student.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void DeleteConfirmed(int Id)
        {
            studentRepository.Remove(Id);
        }
    }
}
