using System.Linq;
using System.Collections.Generic;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.EntityModel;
using StudentCourses.Infrastructure.AutoMapper;

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
        private StudentsCoursesDBfirstEntities _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseRepository"/> class.
        /// </summary>
        public CourseRepository()
        {
            _context = new StudentsCoursesDBfirstEntities();
        }

        /// <summary>
        /// Adds the specified course.
        /// </summary>
        /// <param name="course">The course.</param>
        public void Add(Course course)
        {
            var destinationModel = Mapping.Mapper.Map<CourseEntityModel>(course);
            
            _context.Courses.Add(destinationModel);
            _context.SaveChanges();
        }

        /// <summary>
        /// Edits the specified course.
        /// </summary>
        /// <param name="course">The course.</param>
        public void Edit(Course courseToEdit)
        {
            var currentCourse = _context.Courses.Find(courseToEdit.ID);

            var courseToEditMapped = Mapping.Mapper.Map<CourseEntityModel>(courseToEdit);

            _context.Entry(currentCourse).CurrentValues.SetValues(courseToEditMapped);
            _context.SaveChanges();
        }

        /// <summary>
        /// Removes the specified course by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void Remove(int Id)
        {
            _context.Courses.Remove(_context.Courses.Find(Id));
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all existing courses.
        /// </summary>
        public IEnumerable<Course> GetAll()
        {
            return Mapping.Mapper.Map<ICollection<CourseEntityModel>, ICollection<Course>>(_context.Courses.ToList());
        }

        /// <summary>
        /// Finds the course by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public Course FindById(int Id)
        {
            return Mapping.Mapper.Map<CourseEntityModel, Course>(_context.Courses.Find(Id));
        }
    }
}
