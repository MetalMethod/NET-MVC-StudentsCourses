using System.Collections.Generic;
using StudentCourses.Domain.Models;

namespace StudentCourses.Domain.Interfaces
{
    /// <summary>
    /// This is the repository interface for the Course entity.
    /// </summary>
    public interface IRegistrationRepository
    {
        /// <summary>
        /// Adds the specified registration.
        /// </summary>
        /// <param name="registration">The registration.</param>
        void Add(Registration registration);

        /// <summary>
        /// Edits the specified registration.
        /// </summary>
        /// <param name="registration">The registration.</param>
        void Edit(Registration registration);

        /// <summary>
        /// Removes the specified registration by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        void Remove(int Id);

        /// <summary>
        /// Gets all existing registration.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Registration> GetAll();

        /// <summary>
        /// Finds the registration by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Registration FindById(int Id);
    }
}
