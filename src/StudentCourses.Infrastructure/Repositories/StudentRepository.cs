using System.Linq;
using System.Collections.Generic;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.DataContexts;

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
        private DataBaseContext context = new DataBaseContext();

        /// <summary>
        /// Adds the specified student.
        /// </summary>
        /// <param name="student">The student.</param>
        public void Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        /// <summary>
        /// Edits the specified student.
        /// </summary>
        /// <param name="student">The student.</param>
        public void Edit(Student student)
        {
            context.Entry(student).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        /// <summary>
        /// Removes the specified student by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void Remove(int Id)
        {
            Student student = context.Students.Find(Id);
            context.Students.Remove(student);
            context.SaveChanges();
        }

        /// <summary>
        /// Gets all existing students.
        /// </summary>
        public IEnumerable<Student> GetAll()
        {
            return context.Students;
        }

        /// <summary>
        /// Finds the student by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public Student FindById(int Id)
        {
            var result = (from item in context.Students where item.Id == Id select item).FirstOrDefault();
            return result;
        }
    }
}
