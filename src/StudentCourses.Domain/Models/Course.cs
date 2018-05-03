using System.ComponentModel.DataAnnotations;

namespace StudentCourses.Domain.Models
{
    /// <summary>
    /// The Course POCO
    /// </summary>
    public class Course
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The Course name.
        /// </value>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}