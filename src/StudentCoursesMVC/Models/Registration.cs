
namespace StudentCoursesMVC.Models
{
    /// <summary>
    /// The Course POCO
    /// </summary>
    public class Registration
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
        public Student student { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>
        /// The course.
        /// </value>
        public Course course { get; set; }

        /// <summary>
        /// Gets or sets the register key.
        /// </summary>
        /// <value>
        /// The generated register key.
        /// </value>
        public string registerKey { get; set; }
    }
}