using System.Collections.Generic;
using StudentCourses.Domain.Interfaces;

namespace StudentCourses.Domain.Models
{
    /// <summary>
    /// The Course POCO
    /// </summary>
    public class Course : IDomainModel
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

        public int Vacancies { get; set; }

        public List<Registration> Registrations { get; set; }

        public void Register(Registration registration)
        {
            Registrations.Add(registration);
            Vacancies = Vacancies--;
        }

    }
}