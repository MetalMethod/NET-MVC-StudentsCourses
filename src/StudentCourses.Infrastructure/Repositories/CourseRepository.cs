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
        /// Retrieved from DataContext Singleton
        /// </summary>
        private DataBaseContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseRepository"/> class.
        /// </summary>
        public CourseRepository()
        {
            this._context = DataBaseContext.GetInstance();
        }

        /// <summary>
        /// Adds the specified course.
        /// </summary>
        /// <param name="course">The course.</param>
        public void Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        /// <summary>
        /// Edits the specified course.
        /// </summary>
        /// <param name="course">The course.</param>
        public void Edit(Course courseToEdit)
        {
            var currentCourse = FindById(courseToEdit.Id);
            _context.Entry(currentCourse).CurrentValues.SetValues(courseToEdit);
            _context.SaveChanges();
        }

        /// <summary>
        /// Removes the specified course by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void Remove(int Id)
        {
            Course course = _context.Courses.Find(Id);
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all existing courses.
        /// </summary>
        public IEnumerable<Course> GetAll()
        {
            return _context.Courses;
        }

        /// <summary>
        /// Finds the course by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public Course FindById(int Id)
        {
            var result = (from item in _context.Courses where item.Id == Id select item).FirstOrDefault();
            return result;
        }
    }
}
