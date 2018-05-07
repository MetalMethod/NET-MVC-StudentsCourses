using System.ComponentModel.DataAnnotations;
using StudentCourses.Domain.Interfaces;

namespace StudentCourses.Domain.Models
{
    /// <summary>
    /// The Registration POCO
    /// </summary>
    public class Registration : IModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the student.
        /// </summary>
        /// <value>
        /// The student.
        /// </value>
        public Student Student { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>
        /// The course.
        /// </value>
        public Course Course { get; set; }

        /// <summary>
        /// Gets or sets the register key.
        /// </summary>
        /// <value>
        /// The generated register key.
        /// </value>
        public string RegisterKey { get; set; }
    }
}