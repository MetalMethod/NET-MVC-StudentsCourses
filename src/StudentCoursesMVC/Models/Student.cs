using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentCoursesMVC.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class StudentDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}