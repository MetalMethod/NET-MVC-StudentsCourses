using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentCourses.Domain.Models;

namespace StudentCourses.MVC.ViewModels
{
    public class RegistrationViewModel
    {
        public List<Student> AvaliableStudents { get; set; }
        public List<Course> AvaliableCourses { get; set; }
        public List<Registration> CurrentRegistrations { get; set; }

        public Student StudentToRegister { get; set; }
        public Course CourseToRegister { get; set; }

    }
}