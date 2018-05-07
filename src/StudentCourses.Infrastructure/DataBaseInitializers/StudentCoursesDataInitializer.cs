using System.Data.Entity;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.DataContexts;

namespace StudentCourses.Infrastructure.DatabaseInitializers
{
    /// <summary>
    /// This class is used by the UnitTest to verify if the database is created and populated correctly.
    /// Must run tests once to initialize the database.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DropCreateDatabaseIfModelChanges{StudentCourses.Infrastructure.DataContexts.DataBaseContext}" />
    public class StudentCoursesDataInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        /// <summary>
        /// A method that should be overridden to actually add data to the context for seeding.
        /// </summary>
        /// <param name="context">The context to seed.</param>
        protected override void Seed(DataBaseContext context)
        {
            context.Students.Add(new Student { FirstName = "Jeff", LastName = "Loomis" });
            context.Students.Add(new Student { FirstName = "Paul", LastName = "Gilbert" });
            context.Students.Add(new Student { FirstName = "Ola", LastName = "Strandberg" });
            context.Students.Add(new Student { FirstName = "Yvette", LastName = "Young" });
            context.Students.Add(new Student { FirstName = "James", LastName = "Hetfield" });
            context.Students.Add(new Student { FirstName = "Jason", LastName = "Richardson" });
            context.Students.Add(new Student { FirstName = "Marty", LastName = "Friedman" });
            context.Students.Add(new Student { FirstName = "Manny", LastName = "Clark" });

            context.Courses.Add(new Course { Name = "Drawing 101" });
            context.Courses.Add(new Course { Name = "Mathematics 101" });
            context.Courses.Add(new Course { Name = "Csharp Basics" });
            context.Courses.Add(new Course { Name = "NET MVC" });
            context.Courses.Add(new Course { Name = "SQL Server 101" });
            context.Courses.Add(new Course { Name = "Music Theory" });

            context.Registrations.Add(new Registration
            {
                Student = context.Students.Find(1),
                Course = context.Courses.Find(2),
                RegisterKey = "1111aaaa"
            });
                        
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
