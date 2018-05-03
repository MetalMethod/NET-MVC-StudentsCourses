using System.ComponentModel.DataAnnotations;

namespace StudentCourses.Domain.Models
{
    /// <summary>
    /// The Registration POCO
    /// </summary>
    public class Registration
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the student.
        /// </summary>
        /// <value>
        /// The student.
        /// </value>
        [Required]
        public Student student { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>
        /// The course.
        /// </value>
        [Required]
        public Course course { get; set; }

        /// <summary>
        /// Gets or sets the register key.
        /// </summary>
        /// <value>
        /// The generated register key.
        /// </value>
        [Required]
        public string registerKey { get; set; }
    }
}