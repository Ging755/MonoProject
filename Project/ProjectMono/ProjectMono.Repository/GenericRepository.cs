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
        protected readonly NewContext context;
        protected IUnitOfWorkFactory uowFactory;
        public GenericRepository(NewContext context, IUnitOfWorkFactory uowFactory)
        {
            this.context = context;
            this.uowFactory = uowFactory;
        }
        //Create
        public virtual async Task AddAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.AddAsync(entity);
            await unitOfWork.CommitAsync();
        }
        //Delete
        public virtual async Task DeleteAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.DeleteAsync(entity);
            await unitOfWork.CommitAsync();
        }
        //Update
        public virtual async Task EditAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
        }
        //Read
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
