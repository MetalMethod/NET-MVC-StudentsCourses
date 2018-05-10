using System.Collections.Generic;

namespace StudentCourses.Domain.Interfaces
{
    /// <summary>
    /// This generic interface receives T as a type IModel
    /// Concrete implementations uses T as different Model types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryService<T> where T : IEntityModel
    {
        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Detailses the specified model by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        T Details(int Id);

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        T Add(T model);

        /// <summary>
        /// Return the model to edit.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        T ToEdit(int Id);

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        T Edit(T model);

        /// <summary>
        /// Returns the model to delete.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        T ToDelete(int Id);

        /// <summary>
        /// Deletes the confirmed model.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        void DeleteConfirmed(int Id);
    }
}
