using System;
using StudentCourses.Domain.Interfaces;

namespace StudentCourses.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception for repositories when Updating new elements
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="StudentCourses.Infrastructure.Exceptions.RepositoryException" />
    class RepositoryUpdateElementException<T> : RepositoryException where T : IDomainModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryUpdateElementException{T}"/> class.
        /// </summary>
        public RepositoryUpdateElementException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryUpdateElementException{T}"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="ID">The identifier.</param>
        /// <param name="message">The message.</param>
        public RepositoryUpdateElementException(T model, int ID, string message) : base("Model:  " + model.ToString() +  ", message: " + message){ }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryUpdateElementException{T}"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="message">The message.</param>
        /// <param name="ID">The identifier.</param>
        /// <param name="exception">The exception.</param>
        public RepositoryUpdateElementException(T model, int ID, string message, Exception exception) : base("Model:  " + model.ToString() + ", message: " + message, exception) { }

    }
}
