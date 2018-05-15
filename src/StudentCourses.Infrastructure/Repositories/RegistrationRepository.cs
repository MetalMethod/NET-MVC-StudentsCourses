using System.Linq;
using System.Collections.Generic;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.EntityModel;
using StudentCourses.Infrastructure.AutoMapper;
using System.Data.Entity.Validation;

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
            try
            {
                var destinationModel = Mapping.Mapper.Map<RegistrationEntityModel>(registration);

                destinationModel.Course = _context.Courses.Find(destinationModel.Course_ID);
                destinationModel.Student = _context.Students.Find(destinationModel.Student_ID);

                _context.Registrations.Add(destinationModel);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var errors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in errors.ValidationErrors)
                    {
                        // get the error message 
                        string errorMessage = validationError.ErrorMessage;
                    }
                }
            }
        }

        /// <summary>
        /// Edits the specified registration.
        /// </summary>
        /// <param name="Registration">The registration.</param>
        public void Edit(Registration registrationToEdit)
        {
            RegistrationEntityModel currentRegistration = _context.Registrations.Find(registrationToEdit.ID);

            var destinationModel = Mapping.Mapper.Map<RegistrationEntityModel>(registrationToEdit);
            //var studentToEditMapped = Mapping.Mapper.Map<RegistrationRepository>(destinationModel);

            //_context.Entry(currentRegistration).CurrentValues.SetValues(destinationModel);
            Remove(currentRegistration.ID);
            Add(registrationToEdit);
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
            ICollection<RegistrationEntityModel> registrationsEntity = _context.Registrations.ToList();

            return Mapping.Mapper.Map<ICollection<RegistrationEntityModel>, ICollection<Registration>>(registrationsEntity);

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
