using System;
using StudentCourses.Domain.Interfaces;

namespace StudentCourses.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception for repositories when Removing new elements
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="StudentCourses.Infrastructure.Exceptions.RepositoryException" />
    class RepositoryRemoveElementException<T> : RepositoryException where T : IDomainModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryRemoveElementException{T}"/> class.
        /// </summary>
        public RepositoryRemoveElementException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryRemoveElementException{T}"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="ID">The identifier.</param>
        /// <param name="message">The message.</param>
        public RepositoryRemoveElementException(T model, int ID, string message) : base("Model:  " + model.ToString() +  ", message: " + message){ }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryRemoveElementException{T}"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="message">The message.</param>
        /// <param name="ID">The identifier.</param>
        /// <param name="exception">The exception.</param>
        public RepositoryRemoveElementException(T model, int ID, string message, Exception exception) : base("Model:  " + model.ToString() + ", message: " + message, exception) { }

    }
}
