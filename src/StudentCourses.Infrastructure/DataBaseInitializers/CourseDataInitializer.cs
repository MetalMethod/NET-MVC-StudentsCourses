using System.Data.Entity;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.DataContexts;

namespace StudentCourses.Infrastructure.DatabaseInitializers
{
    public class CourseDataInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            context.Courses.Add(new Course {  Name = "Drawing 101"});
            context.Courses.Add(new Course {  Name = "Mathematics 101" });
            context.Courses.Add(new Course {  Name = "Csharp Basics" });
            context.Courses.Add(new Course {  Name = "NET MVC" });
            context.Courses.Add(new Course {  Name = "SQL Server 101"});
            context.Courses.Add(new Course {  Name = "Music Theory" });
            
            context.SaveChanges();
            base.Seed(context);
        }

    }
}
