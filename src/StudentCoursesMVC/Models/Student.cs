﻿
namespace StudentCoursesMVC.Models
{
    /// <summary>
    /// The Student POCO
    /// </summary>
    public class Student
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
        /// The Students First name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The Students Last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has a registration.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is registrated; otherwise, <c>false</c>.
        /// </value>
        public bool IsRegistrated { get; set; }
    }
}