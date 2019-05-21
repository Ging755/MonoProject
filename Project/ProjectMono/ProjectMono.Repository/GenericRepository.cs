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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly VehicleContext context;
        protected IUnitOfWorkFactory uowFactory;
        public GenericRepository(VehicleContext context, IUnitOfWorkFactory uowFactory)
        {
            this.context = context;
            this.uowFactory = uowFactory;
        }
        public virtual async Task AddAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.AddAsync(entity);
            await unitOfWork.CommitAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.DeleteAsync(entity);
            await unitOfWork.CommitAsync();
        }

        public virtual async Task EditAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
        }

        public virtual async Task<T> GetVehicleAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual IDbSet<T> GetVehiclesAsync()
        {
            return context.Set<T>();
        }
    }
}
