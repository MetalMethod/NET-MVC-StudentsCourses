using System.Linq;
using System.Collections.Generic;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.DataContext;

namespace StudentCourses.Infrastructure.Repositories
{
    /// <summary>
    /// This is the implementation of the repository for the Student entity
    /// </summary>
    /// <seealso cref="StudentCourses.Domain.Interfaces.IRepository<T>
    public class StudentRepository : IRepository<Student>
    {
        /// <summary>
        /// The database context object.
        /// </summary>
        private DataBaseContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepository"/> class.
        /// </summary>
        public StudentRepository()
        {
            _context = new DataBaseContext();
        }

        /// <summary>
        /// Adds the specified student.
        /// </summary>
        /// <param name="student">The student.</param>
        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        /// <summary>
        /// Edits the specified student.
        /// </summary>
        /// <param name="student">The student.</param>
        public void Edit(Student studentToEdit)
        {
            var currentStudent = FindById(studentToEdit.StudentId);
            _context.Entry(currentStudent).CurrentValues.SetValues(studentToEdit);
            _context.SaveChanges();
        }

        /// <summary>
        /// Removes the specified student by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void Remove(int Id)
        {
            Student student = _context.Students.Find(Id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all existing students.
        /// </summary>
        public IEnumerable<Student> GetAll() => _context.Students;

        /// <summary>
        /// Finds the student by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public Student FindById(int Id)
        {
            var result = (from item in _context.Students where item.StudentId == Id select item).FirstOrDefault();
            return result;
        }
    }
}
