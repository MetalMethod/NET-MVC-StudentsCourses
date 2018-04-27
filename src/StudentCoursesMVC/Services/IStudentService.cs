using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCoursesMVC.Models;

namespace StudentCoursesMVC.Services
{
    public interface IStudentService
    {
        //Returns all objects from Model 
        List<Student> GetAll();

        //Return the details for one specific object
        Student GetSingle(int? id);

        //Adds a new object to  model
        Student Create(Student student);

        //POST: updates object in model
        Student Edit(Student student);

        //POST: delete object with id
        void DeleteConfirmed(int id);
    }
}
