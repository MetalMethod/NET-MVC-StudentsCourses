using System.Data.Entity;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.DataContexts;

namespace StudentCourses.Infrastructure.DatabaseInitializers
{
    public class StudentCoursesDataInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
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

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
