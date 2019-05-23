using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        //Read
        Task<T> GetVehicleAsync(int id);

        IDbSet<T> GetVehiclesAsync();

        //Create
        Task AddAsync(T entity);

        //Delete
        Task DeleteAsync(T entity);

        //Update
        Task EditAsync(T entity);
    }
}
