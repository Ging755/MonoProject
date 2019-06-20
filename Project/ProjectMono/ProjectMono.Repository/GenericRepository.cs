using ProjectMono.DAL;
using ProjectMono.Repository.Common;
using ProjectMono.Repository.UOFW;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Repository
{
    /// <summary>
    /// GenericRepository class.
    /// </summary>
    /// <typeparam name="T">Type of generic.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly NewContext context;
        protected IUnitOfWorkFactory uowFactory;
        public GenericRepository(NewContext context, IUnitOfWorkFactory uowFactory)
        {
            this.context = context;
            this.uowFactory = uowFactory;
        }

        /// <summary>
        /// Create method,
        /// creates using UnitOfWork.
        /// <param name="entity">Model, type of generic.</param>
        /// </summary>
        public virtual async Task AddAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.AddAsync(entity);
            await unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Delete method,
        /// deletes using UnitOfWork.
        /// <param name="entity">Model, type of generic.</param>
        /// </summary>
        public virtual async Task DeleteAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.DeleteAsync(entity);
            await unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Update method,
        /// updates/edits using UnitOfWork.
        /// <param name="entity">Model, type of generic.</param>
        /// </summary>
        public virtual async Task EditAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Read method,
        /// gets data from context.
        /// </summary>
        /// <param name="id">Id, type of int.</param>
        /// <returns>Returns data of the same type as the generic parameter.</returns>
        public virtual async Task<T> GetVehicleAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Read method,
        /// gets data from context.
        /// </summary>
        /// <returns>Returns data of the same type as the generic parameter.</returns>
        public virtual IDbSet<T> GetVehiclesAsync()
        {
            return context.Set<T>();
        }
    }
}
