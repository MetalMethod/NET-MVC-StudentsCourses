using System;
using StudentCourses.Domain.Interfaces;

namespace StudentCourses.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception for repositories when Removing new elements
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="StudentCourses.Infrastructure.Exceptions.RepositoryException" />
    class RepositoryElementNotFoundByIdException<T> : RepositoryException where T : IDomainModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryElementNotFoundByIdException{T}"/> class.
        /// </summary>
        public RepositoryElementNotFoundByIdException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryElementNotFoundByIdException{T}"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="ID">The identifier.</param>
        /// <param name="message">The message.</param>
        public RepositoryElementNotFoundByIdException(T model, int ID, string message) : base("Model:  " + model.ToString() +  ", message: " + message){ }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryElementNotFoundByIdException{T}"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="message">The message.</param>
        /// <param name="ID">The identifier.</param>
        /// <param name="exception">The exception.</param>
        public RepositoryElementNotFoundByIdException(T model, int ID, Exception exception, string message) : base("Model:  " + model.ToString() + ", message: " + message, exception) { }

    }
}
