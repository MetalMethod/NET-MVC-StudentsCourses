using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourses.Infrastructure.Exceptions
{
    public abstract class RepositoryException: Exception
    {
        public RepositoryException() : base()
        {
        }

        protected RepositoryException(string message)
        {
        }

        public RepositoryException(string message, Exception exception)
        {
        }

    }
}
