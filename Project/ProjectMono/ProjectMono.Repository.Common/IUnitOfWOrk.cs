using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Repository.Common
{
    /// <summary>
    /// Interface for UnitOfWork.
    /// </summary>
    public interface IUnitOfWOrk
    {
        /// <summary>
        /// Create method,
        /// creates/adds to context.
        /// </summary>
        /// <typeparam name="T">Model, type of generic.</typeparam>
        Task<int> AddAsync<T>(T entity) where T : class;

        /// <summary>
        /// Commit method,
        /// saves changes to context.
        /// </summary>
        Task<int> CommitAsync();

        /// <summary>
        /// Delete method,
        /// delets from context.
        /// </summary>
        /// <typeparam name="T">Mdoel, type of generic.</typeparam>
        Task<int> DeleteAsync<T>(T entity) where T : class;

        /// <summary>
        /// Delete method
        /// deletes from context.
        /// </summary>
        /// <typeparam name="T">Id, type of generic.</typeparam>
        Task<int> DeleteAsync<T>(string ID) where T : class;

        /// <summary>
        /// Update method
        /// updates/edits from context.
        /// </summary>
        /// <typeparam name="T">Model, type of generic.</typeparam>
        Task<int> UpdateAsync<T>(T entity) where T : class;
    }
}
