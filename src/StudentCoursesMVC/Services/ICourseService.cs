using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCoursesMVC.Models;

namespace StudentCoursesMVC.Services
{
    interface ICourseService
    {
        //Returns all objects from Model 
        List<Course> GetAll();

        //Return the details for one specific object
        Course GetSingle(int? id);

        //Adds a new object to  model
        Course Create(Course student);

        //POST: updates object in model
        Course Edit(Course student);

        //POST: delete object with id
        void DeleteConfirmed(int id);
    }
}
