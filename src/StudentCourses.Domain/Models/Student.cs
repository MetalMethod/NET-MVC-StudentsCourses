using System.Collections.Generic;
using StudentCourses.Domain.Interfaces;

namespace StudentCourses.Domain.Models
{
    /// <summary>
    /// The Student POCO
    /// </summary>
    public class Student : IDomainModel
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

        public List<Registration> Registrations { get; set; }

        public void Register(Registration registration)
        {
            Registrations.Add(registration);
        }

    }
}