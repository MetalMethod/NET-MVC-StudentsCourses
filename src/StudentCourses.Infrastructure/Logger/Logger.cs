using System;
using System.IO;
using System.Text;

namespace StudentCourses.Infrastructure.Logger
{
    public static class Logger
    {
        static Logger()
        {

        }

        public static void LogException(Exception exception)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("\r\nLog Entry : ");
            stringBuilder.Append("Date: " + DateTime.Now.ToLongDateString());
            stringBuilder.Append(" ### Time: " + DateTime.Now.ToLongTimeString());
            stringBuilder.Append("\n######################################################################\n");
            stringBuilder.Append("Source: \n");
            stringBuilder.Append(exception.Source.ToString());
            stringBuilder.Append("\n--------------------------------------------------------------\n");
            stringBuilder.Append("Message: \n");
            stringBuilder.Append(exception.Message.ToString());
            stringBuilder.Append("\n--------------------------------------------------------------\n");
            stringBuilder.Append("Stack trace: \n");
            stringBuilder.Append(exception.StackTrace.ToString());
            stringBuilder.Append("\n######################################################################\r\n\n\n");

            //string p = @"..\..\..\logs\";
            string path = "C:\\Users\\Altran\\Desktop\\Igor\\personal_interests\\NET-MVC-StudentsCourses\\logs\\";
            try
            {
                File.AppendAllText(path + "exceptions_log.txt", stringBuilder.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            finally
            {
                stringBuilder.Clear();
            }
        }

        public static void Log(string logMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("\r\nLog Entry : ");
            stringBuilder.Append("Date: " + DateTime.Now.ToLongDateString());
            stringBuilder.Append(" ### Time: " + DateTime.Now.ToLongTimeString());
            stringBuilder.Append("\n--------------------------------------------------------------\n");
            stringBuilder.Append(logMessage);
            stringBuilder.Append("\n--------------------------------------------------------------\n");
            stringBuilder.Append("\n######################################################################\r\n\n\n");
            string path = "C:\\Users\\Altran\\Desktop\\Igor\\personal_interests\\NET-MVC-StudentsCourses\\logs\\";
            try
            {
                File.AppendAllText(path + "log.txt", stringBuilder.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            finally
            {
                stringBuilder.Clear();
            }
        }
    }
}
