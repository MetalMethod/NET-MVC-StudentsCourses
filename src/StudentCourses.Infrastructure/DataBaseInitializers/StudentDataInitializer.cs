using System.Data.Entity;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.DataContexts;

namespace StudentCourses.Infrastructure.DatabaseInitializers
{
    public class StudentDataInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            foreach(Student std in context.Students)
            {
                context.Students.Remove(std);
            }
            context.SaveChanges();

            context.Students.Add(new Student { FirstName = "Jeff", LastName = "Loomis" });
            context.Students.Add(new Student { FirstName = "Paul", LastName = "Gilbert" });
            context.Students.Add(new Student { FirstName = "Ola", LastName = "Strandberg" });
            context.Students.Add(new Student { FirstName = "Yvette", LastName = "Young" });
            context.Students.Add(new Student { FirstName = "James", LastName = "Hetfield" });
            context.Students.Add(new Student { FirstName = "Jason", LastName = "Richardson" });
            context.Students.Add(new Student { FirstName = "Marty", LastName = "Friedman" });
            context.Students.Add(new Student { FirstName = "Manny", LastName = "Clark" });

            context.SaveChanges();
            base.Seed(context);
        }

    }
}
