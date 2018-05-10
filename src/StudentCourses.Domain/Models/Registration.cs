using StudentCourses.Domain.Interfaces;

namespace StudentCourses.Domain.Models
{
    /// <summary>
    /// The Registration POCO
    /// </summary>
    public class Registration : IDomainModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the student.
        /// </summary>
        /// <value>
        /// The student.
        /// </value>
        public int Student_ID { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>
        /// The course.
        /// </value>
        public int Course_ID { get; set; }

        /// <summary>
        /// Gets or sets the register key.
        /// </summary>
        /// <value>
        /// The generated register key.
        /// </value>
        public string RegistrationKey { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }

        public void Register(Student student, Course course)
        {
            this.Course = course;
            this.Student = student;
        }
    }
}