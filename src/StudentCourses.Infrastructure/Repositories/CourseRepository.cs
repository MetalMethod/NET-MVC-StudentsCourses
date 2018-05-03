using System.Linq;
using System.Collections.Generic;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.DataContexts;

namespace StudentCourses.Infrastructure.Repositories
{
    /// <summary>
    /// This is the implementation of the repository for the Course entity
    /// </summary>
    /// <seealso cref="StudentCourses.Domain.Interfaces.IRepository<T>
    public class CourseRepository : IRepository<Course>
    {
        /// <summary>
        /// The database context object.
        /// </summary>
        private DataBaseContext context = new DataBaseContext();

        /// <summary>
        /// Adds the specified course.
        /// </summary>
        /// <param name="course">The course.</param>
        public void Add(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        /// <summary>
        /// Edits the specified course.
        /// </summary>
        /// <param name="course">The course.</param>
        public void Edit(Course course)
        {
            context.Entry(course).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        /// <summary>
        /// Removes the specified course by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void Remove(int Id)
        {
            Course course = context.Courses.Find(Id);
            context.Courses.Remove(course);
            context.SaveChanges();
        }

        /// <summary>
        /// Gets all existing courses.
        /// </summary>
        public IEnumerable<Course> GetAll()
        {
            return context.Courses;
        }

        /// <summary>
        /// Finds the course by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public Course FindById(int Id)
        {
            var result = (from item in context.Courses where item.Id == Id select item).FirstOrDefault();
            return result;
        }
    }
}
