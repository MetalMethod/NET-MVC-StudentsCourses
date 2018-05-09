using System.Linq;
using System.Collections.Generic;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.DataContext;

namespace StudentCourses.Infrastructure.Repositories
{
    /// <summary>
    /// This is the implementation of the repository for the Registration entity
    /// </summary>
    public class RegistrationRepository : IRepository<Registration>
    {
        /// <summary>
        /// The database context object.
        /// </summary>
        private DataBaseContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationRepository"/> class.
        /// </summary>
        public RegistrationRepository()
        {
            _context = new DataBaseContext();
        }

        /// <summary>
        /// Adds the specified registration.
        /// </summary>
        /// <param name="course">The course.</param>
        public void Add(Registration registration)
        {
            _context.Registrations.Add(registration);
            _context.SaveChanges();
        }

        /// <summary>
        /// Edits the specified registration.
        /// </summary>
        /// <param name="course">The registration.</param>
        public void Edit(Registration registrationToEdit)
        {
            var currentRegistration = FindById(registrationToEdit.Id);
            _context.Entry(currentRegistration).CurrentValues.SetValues(registrationToEdit);
            _context.SaveChanges();
        }

        /// <summary>
        /// Removes the specified registration by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void Remove(int Id)
        {
            Registration registration = _context.Registrations.Find(Id);
            _context.Registrations.Remove(registration);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all existing registrations.
        /// </summary>
        public IEnumerable<Registration> GetAll() => _context.Registrations;

        /// <summary>
        /// Finds the registration by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public Registration FindById(int Id)
        {
            var result = (from item in _context.Registrations where item.Id == Id select item).FirstOrDefault();
            return result;
        }
    }
}
