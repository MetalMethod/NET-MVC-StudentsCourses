using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCoursesMVC.Services
{
    interface IService
    {
        //Returns all objects from Model 
        List<Object> GetAll();

        //Return the details for one specific object
        Object GetSingle(int? id);

        //Adds a new object to  model
        Object Create(Object obj);

        //POST: updates object in model
        Object Edit(Object obj);

        //POST: delete object with id
        void DeleteConfirmed(int id);
    }
}
