using System.ComponentModel.DataAnnotations;
using StudentCourses.Domain.Interfaces;

namespace StudentCourses.Domain.Models
{
    /// <summary>
    /// The Student POCO
    /// </summary>
    public class Student : IModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The Students First name.
        /// </value>
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The Students Last name.
        /// </value>
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}