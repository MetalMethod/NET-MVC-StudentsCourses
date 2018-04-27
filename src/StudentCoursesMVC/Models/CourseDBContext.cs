using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudentCoursesMVC.Models
{
    public class CourseDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
    }
}