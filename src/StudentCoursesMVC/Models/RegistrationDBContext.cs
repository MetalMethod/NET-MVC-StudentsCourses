using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudentCoursesMVC.Models.EntityModels
{
    public class RegistrationDBContext : DbContext
    {
        public DbSet<Students> Students { get; set; }
    }
}