using System;
using System.Linq;
using System.Collections.Generic;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.EntityModel;
using StudentCourses.Infrastructure.AutoMapper;
using StudentCourses.Infrastructure.Exceptions;

namespace StudentCourses.Infrastructure.Repositories
{
    /// <summary>
    /// This is the implementation of the repository for the Student entity
    /// </summary>
    /// <seealso cref="StudentCourses.Domain.Interfaces.IRepository<T>
    public class StudentRepository : IRepository<Student>
    {
        /// <summary>
        /// The database context object.
        /// </summary>
        private StudentsCoursesDBfirstEntities _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepository"/> class.
        /// </summary>
        public StudentRepository()
        {
            _context = new StudentsCoursesDBfirstEntities();
        }

        /// <summary>
        /// Adds the specified student.
        /// </summary>
        /// <param name="student">The student.</param>
        public void Add(Student student)
        {
            StudentEntityModel destinationModel = Mapping.Mapper.Map<StudentEntityModel>(student);

            try
            {
                _context.Students.Add(destinationModel);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new RepositoryAddElementException<Student>(student, exception, "Could not add element in Student Repository.");
            }
        }

        /// <summary>
        /// Edits the specified student.
        /// </summary>
        /// <param name="student">The student.</param>
        public void Edit(Student studentToEdit)
        {
            StudentEntityModel currentStudent;
            StudentEntityModel studentToEditMapped = Mapping.Mapper.Map<StudentEntityModel>(studentToEdit);

            try
            {
                currentStudent = _context.Students.Find(studentToEdit.ID);
            }
            catch (Exception exception)
            {
                throw new RepositoryElementNotFoundByIdException<Student>(studentToEdit, studentToEdit.ID, exception, "Student to edit not found by Id");
            }

            try
            {
                _context.Entry(currentStudent).CurrentValues.SetValues(studentToEditMapped);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new RepositoryUpdateElementException<Student>(studentToEdit, studentToEdit.ID, exception, "Could not update Student. ");
            }
        }

        /// <summary>
        /// Removes the specified student by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void Remove(int Id)
        {
            try
            {
                _context.Students.Remove(_context.Students.Find(Id));
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new RepositoryRemoveElementException<Student>(Id, exception, "Could not remove the Student.");
            }
        }

        /// <summary>
        /// Gets all existing students.
        /// </summary>
        public IEnumerable<Student> GetAll()
        {
            return Mapping.Mapper.Map<ICollection<StudentEntityModel>, ICollection<Student>>(_context.Students.ToList());
        }

        /// <summary>
        /// Finds the student by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public Student FindById(int Id)
        {
            return Mapping.Mapper.Map<StudentEntityModel, Student>(_context.Students.Find(Id));
        }
    }
}
