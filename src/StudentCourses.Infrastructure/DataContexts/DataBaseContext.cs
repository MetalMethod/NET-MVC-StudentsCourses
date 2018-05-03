using System.Collections.Generic;
using System.Data.Entity;
using StudentCourses.Domain.Models;


namespace StudentCourses.Infrastructure.DataContexts
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("name=StudentCoursesConnectionString")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Registration> Registrations { get; set; }

    }
}
