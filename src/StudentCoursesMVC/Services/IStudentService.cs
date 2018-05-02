using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCoursesMVC.Models;
using StudentCoursesMVC.Models.EntityModels;

namespace StudentCoursesMVC.Services
{
    public interface IStudentService
    {
        //Returns all objects from Model 
        List<Students> GetAll();

        //Return the details for one specific object
        Students GetSingle(int? id);

        //Adds a new object to  model
        Students Create(Students student);

        //POST: updates object in model
        Students Edit(Students student);

        //POST: delete object with id
        void DeleteConfirmed(int id);
    }
}
