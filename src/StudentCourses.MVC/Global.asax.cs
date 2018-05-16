using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StudentCourses.Infrastructure.AutoMapper;
using System.IO;
using System.Text;
using StudentCourses.Infrastructure.Logger;

namespace StudentCourses.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        protected void Application_Error()
        {
            Exception exception = Server.GetLastError();
            // Redirect to error page

            Logger.LogException(exception);

            //Log(exception.StackTrace.ToString(), writer);

            // log to file 
            //exception.StackTrace.ToString();
        }

        //public static void Log(string logMessage)
        //{
        //    StringBuilder stringBuilder = new StringBuilder();

        //    stringBuilder.Append("\r\nLog Entry : ");
        //    stringBuilder.Append(DateTime.Now.ToLongTimeString());
        //    stringBuilder.Append("\r\n-------------------------------\r\n");
        //    stringBuilder.Append(logMessage);
        //    stringBuilder.Append("\r\n-------------------------------\r\n");

        //    string path = "C:\\Users\\Altran\\Desktop\\Igor\\personal_interests\\NET-MVC-StudentsCourses\\src\\StudentCourses.MVC\\Logs\\";
        //    try
        //    {
        //        File.AppendAllText(path + "log.txt", stringBuilder.ToString());
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message.ToString());
        //    }
        //    finally
        //    {
        //        stringBuilder.Clear();
        //    }    
        //}

    }
}
