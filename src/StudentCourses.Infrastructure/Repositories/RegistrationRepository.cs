using System.Linq;
using System.Collections.Generic;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.EntityModel;
using StudentCourses.Infrastructure.AutoMapper;

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
        private StudentsCoursesDBfirstEntities _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationRepository"/> class.
        /// </summary>
        public RegistrationRepository()
        {
            _context = new StudentsCoursesDBfirstEntities();
        }

        /// <summary>
        /// Adds the specified registration.
        /// </summary>
        /// <param name="course">The course.</param>
        public void Add(Registration registration)
        {
            var destinationModel = Mapping.Mapper.Map<RegistrationEntityModel>(registration);

            _context.Registrations.Add(destinationModel);
            _context.SaveChanges();
        }

        /// <summary>
        /// Edits the specified registration.
        /// </summary>
        /// <param name="course">The registration.</param>
        public void Edit(Registration registrationToEdit)
        {
            var currentRegistration = FindById(registrationToEdit.ID);

            var destinationModel = Mapping.Mapper.Map<RegistrationEntityModel>(currentRegistration);
            var studentToEditMapped = Mapping.Mapper.Map<RegistrationRepository>(destinationModel);

            _context.Entry(currentRegistration).CurrentValues.SetValues(registrationToEdit);
            _context.SaveChanges();
        }

        /// <summary>
        /// Removes the specified registration by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void Remove(int Id)
        {
            _context.Registrations.Remove(_context.Registrations.Find(Id));
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all existing registrations.
        /// </summary>
        public IEnumerable<Registration> GetAll()
        {
            return Mapping.Mapper.Map<ICollection<RegistrationEntityModel>, ICollection<Registration>>(_context.Registrations.ToList());
        }

        /// <summary>
        /// Finds the registration by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public Registration FindById(int Id)
        {
            return Mapping.Mapper.Map<RegistrationEntityModel, Registration>(_context.Registrations.Find(Id));
        }
    }
}
