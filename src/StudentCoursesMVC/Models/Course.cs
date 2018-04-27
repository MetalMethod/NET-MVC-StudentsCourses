
namespace StudentCoursesMVC.Models
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
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The Course name.
        /// </value>
        public string Name { get; set; }
    }
}