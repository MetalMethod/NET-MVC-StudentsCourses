using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudentCoursesMVC.Models
{
    public class RegistrationDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}