using System.Data.Entity;
using StudentCourses.Domain.Models;

namespace StudentCourses.Infrastructure.DataContexts
{
    /// <summary>
    /// The DataBase context class for the Entity Framework.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class DataBaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseContext"/> class.
        /// </summary>
        public DataBaseContext() : base("name=StudentCoursesConnectionString")
        {
        }

        /// <summary>
        /// The Singleton context object
        /// </summary>
        public static DataBaseContext ContextObject;

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        /// <value>
        /// The students list.
        /// </value>
        public DbSet<Student> Students { get; set; }
        
        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>
        /// The courses list.
        /// </value>
        public DbSet<Course> Courses { get; set; }
        
        /// <summary>
        /// Gets or sets the registrations.
        /// </summary>
        /// <value>
        /// The registrations list.
        /// </value>
        public DbSet<Registration> Registrations { get; set; }
    }
}
