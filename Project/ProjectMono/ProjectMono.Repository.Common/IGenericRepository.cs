using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Repository.Common
{
    /// <summary>
    /// Interface for Generic Repository.
    /// </summary>
    /// <typeparam name="T">Type of generic.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Read method,
        /// gets data from context.
        /// </summary>
        /// <param name="id">Id, type of int.</param>
        /// <returns>Returns data of the same type as the generic parameter.</returns>
        Task<T> GetVehicleAsync(int id);

        /// <summary>
        /// Read method
        /// gets data from context.
        /// </summary>
        /// <returns>Returns data of the same type as the generic parameter.</returns>
        IDbSet<T> GetVehiclesAsync();

        /// <summary>
        /// Create method,
        /// creates using UnitOfWork.
        /// </summary>
        /// <param name="entity">Model, type of generic.</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Delete method
        /// deletes using UnitOfWork.
        /// </summary>
        /// <param name="entity">Model, type of generic.</param>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Update method
        /// updates using UnitOfWork.
        /// </summary>
        /// <param name="entity">Model, type of generic.</param>
        Task EditAsync(T entity);
    }
}
