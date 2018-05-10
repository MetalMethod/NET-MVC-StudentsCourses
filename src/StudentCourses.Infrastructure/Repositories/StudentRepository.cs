using System.Linq;
using System.Collections.Generic;
using StudentCourses.Domain.Interfaces;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.EntityModel;
using StudentCourses.Infrastructure.AutoMapper;

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
            var destinationModel = Mapping.Mapper.Map<StudentEntityModel>(student);

            _context.Students.Add(destinationModel);
            _context.SaveChanges();
        }

        /// <summary>
        /// Edits the specified student.
        /// </summary>
        /// <param name="student">The student.</param>
        public void Edit(Student studentToEdit)
        {
            var currentStudent = FindById(studentToEdit.ID);
            
            //Automapper
            var destinationModel = Mapping.Mapper.Map<StudentEntityModel>(currentStudent);
            var studentToEditMapped = Mapping.Mapper.Map<StudentEntityModel>(destinationModel);

            _context.Entry(currentStudent).CurrentValues.SetValues(studentToEditMapped);
            _context.SaveChanges();
        }

        /// <summary>
        /// Removes the specified student by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void Remove(int Id)
        {
            Student student = FindById(Id);

            var destinationModel = Mapping.Mapper.Map<StudentEntityModel>(student);

            _context.Students.Remove(destinationModel);
            _context.SaveChanges();
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
            //var result = (from item in _context.Students where item.ID == Id select item).FirstOrDefault();
            return Mapping.Mapper.Map<StudentEntityModel, Student>(_context.Students.Find(Id));
        }
    }
}
