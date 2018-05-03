using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCoursesMVC.Models.EntityModels;

namespace StudentCoursesMVC.Services
{
    interface ICourseService
    {
        //Returns all objects from Model 
        List<Courses> GetAll();

        //Return the details for one specific object
        Courses GetSingle(int? id);

        //Adds a new object to  model
        Courses Create(Courses student);

        //POST: updates object in model
        Courses Edit(Courses student);

        //POST: delete object with id
        void DeleteConfirmed(int id);
    }
}
