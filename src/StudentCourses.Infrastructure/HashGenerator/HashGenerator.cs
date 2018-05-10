using System;
using StudentCourses.Domain.Models;
using StudentCourses.Domain.Interfaces;

namespace StudentCourses.Infrastructure.HashGenerator
{
    public class HashGenerator : IHashGenerator
    {
        public string Generate(Student student, Course course)
        {
            if (student != null && course != null)
            {
                string fullString = student.FirstName + student.LastName + course.Name;

                return String.Format("{0:x}", fullString.GetHashCode());
            }
            else
            {
                return "0000oooo";
            }
        }

    }
}
