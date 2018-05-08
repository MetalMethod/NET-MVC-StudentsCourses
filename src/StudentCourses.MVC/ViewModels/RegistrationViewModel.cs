using System.Collections.Generic;
using StudentCourses.Domain.Models;

namespace StudentCourses.MVC.ViewModels
{
    /// <summary>
    /// The registration view model for MVC.
    /// </summary>
    public class RegistrationViewModel
    {
        /// <summary>
        /// Gets or sets the avaliable students.
        /// </summary>
        /// <value>
        /// The list of avaliable students.
        /// </value>
        public List<Student> AvaliableStudents { get; set; }

        /// <summary>
        /// Gets or sets the avaliable courses.
        /// </summary>
        /// <value>
        /// The list of avaliable courses.
        /// </value>
        public List<Course> AvaliableCourses { get; set; }

        /// <summary>
        /// Gets or sets the current registrations.
        /// </summary>
        /// <value>
        /// The list of current registrations.
        /// </value>
        public List<Registration> CurrentRegistrations { get; set; }

        /// <summary>
        /// Gets or sets the student to register.
        /// </summary>
        /// <value>
        /// The student to register.
        /// </value>
        public Student StudentToRegister { get; set; }

        /// <summary>
        /// Gets or sets the course to register.
        /// </summary>
        /// <value>
        /// The course to register.
        /// </value>
        public Course CourseToRegister { get; set; }
    }
}