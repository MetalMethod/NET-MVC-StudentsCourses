using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentCoursesMVC.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class CourseDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
    }

}