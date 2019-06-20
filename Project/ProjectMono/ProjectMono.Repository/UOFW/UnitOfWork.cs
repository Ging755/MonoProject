using ProjectMono.DAL;
using ProjectMono.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ProjectMono.Repository.UOFW
{
    /// <summary>
    /// UnitOfWork Class.
    /// </summary>
    public class UnitOfWork : IUnitOfWOrk
    {
        protected NewContext DbContext { get; private set; }
        public UnitOfWork(NewContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext");
            }
            DbContext = dbContext;
        }

        /// <summary>
        /// Create method,
        /// creates/adds to context.
        /// </summary>
        /// <typeparam name="T">Model, type of generic.</typeparam>
        public Task<int> AddAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbContext.Set<T>().Add(entity);
            }
            return Task.FromResult(1);
        }

        /// <summary>
        /// Commit method,
        /// saves changes to context.
        /// </summary>
        public async Task<int> CommitAsync()
        {
            int result = 0;
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await DbContext.SaveChangesAsync();
                scope.Complete();
            }
            return result;
        }

        /// <summary>
        /// Delete method,
        /// deletes from context.
        /// </summary>
        /// <typeparam name="T">Model, type of generic.</typeparam>
        /// <param name="entity"></param>
        public Task<int> DeleteAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbContext.Set<T>().Attach(entity);
                DbContext.Set<T>().Remove(entity);
            }
            return Task.FromResult(1);
        }

        /// <summary>
        /// Delete method,
        /// deletes from context.
        /// </summary>
        /// <typeparam name="T">Id, type of string.</typeparam>
        public Task<int> DeleteAsync<T>(string Id) where T : class
        {
            var entity = DbContext.Set<T>().Find(Id);
            if (entity == null)
            {
                return Task.FromResult(0);
            }
            return DeleteAsync<T>(entity);
        }

        /// <summary>
        /// Update method,
        /// updates/edits from context.
        /// </summary>
        /// <typeparam name="T">Model, type of generic</typeparam>
        public Task<int> UpdateAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbContext.Set<T>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;

            return Task.FromResult(1);
        }
    }
}
