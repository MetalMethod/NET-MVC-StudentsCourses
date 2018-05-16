using System;
using StudentCourses.Domain.Interfaces;

namespace StudentCourses.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception for repositories when Adding new elements
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="StudentCourses.Infrastructure.Exceptions.RepositoryException" />
    class RepositoryAddElementException<T> : RepositoryException where T : IDomainModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryAddElementException{T}"/> class.
        /// </summary>
        public RepositoryAddElementException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryAddElementException{T}"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="message">The message.</param>
        public RepositoryAddElementException(T model, string message) : base("Model:  " + model.ToString() +  ", message: " + message){ }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryAddElementException{T}"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public RepositoryAddElementException(T model, string message, Exception exception) : base("Model:  " + model.ToString() + ", message: " + message, exception) { }

    }
}
