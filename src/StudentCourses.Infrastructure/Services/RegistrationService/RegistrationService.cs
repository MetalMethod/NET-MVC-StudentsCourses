using System.Collections.Generic;
using StudentCourses.Domain.Models;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Infrastructure.Repositories;

namespace StudentCourses.Infrastructure.Services.RegistrationService
{
    /// <summary>
    /// Service class for Registration entity, containing Repositories Reference and Business Logic if needed.
    /// </summary>
    public class RegistrationService : IRepositoryService<Registration>
    {
        /// <summary>
        /// The registration repository instance.
        /// </summary>
        private IRepository<Registration> registrationRepository = new RegistrationRepository();

        /// <summary>
        /// Gets all registrations.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Registration> GetAll()
        {
            return registrationRepository.GetAll();
        }

        /// <summary>
        /// Detailses the specified registration by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Registration Details(int Id)
        {
            return registrationRepository.FindById(Id);
        }

        /// <summary>
        /// Adds the specified registration.
        /// </summary>
        /// <param name="registration">The registration.</param>
        /// <returns></returns>
        public Registration Add(Registration registration)
        {
            registrationRepository.Add(registration);
            return registration;
        }

        /// <summary>
        /// Return the registration to edit.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Registration ToEdit(int Id)
        {
            return registrationRepository.FindById(Id);
        }

        /// <summary>
        /// Edits the specified registration.
        /// </summary>
        /// <param name="registration">The registration.</param>
        /// <returns></returns>
        public Registration Edit(Registration registration)
        {
            registrationRepository.Edit(registration);
            return registration;
        }

        /// <summary>
        /// Returns the registration to delete.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Registration ToDelete(int Id)
        {
            return registrationRepository.FindById(Id);
        }

        /// <summary>
        /// Deletes the confirmed registration.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void DeleteConfirmed(int Id)
        {
            registrationRepository.Remove(Id);
        }

        public Registration FindById(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
