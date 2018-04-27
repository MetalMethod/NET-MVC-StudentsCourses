using StudentCoursesMVC.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace StudentCoursesMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // it is NOT necessary to register your controllers

            // register all your components with the container here
            container.RegisterType<IStudentService, StudentService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}