using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourses.Domain.Interfaces
{
    /// <summary>
    /// This generic interface receives T as a type IModel
    /// Concrete implementations uses T as different Model types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : IDomainModel
    {
        /// <summary>
        /// Adds the specified row of model of type T.
        /// </summary>
        /// <param name="model">The model of type T.</param>
        void Add(T model);

        /// <summary>
        /// Edits the specified row of model of type T.
        /// </summary>
        /// <param name="model">The model of type T.</param>
        void Edit(T model);

        /// <summary>
        /// Removes the specified row of model of type T by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        void Remove(int Id);

        /// <summary>
        /// Gets all existing rows of model of type T.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Finds the rows of model of type T by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        T FindById(int Id);
    }
}
