using StudentCourses.Domain.Models;

namespace StudentCourses.Domain.Interfaces
{
    public interface IHashGenerator
    {
        string Generate(Student student, Course course);
    }
}
