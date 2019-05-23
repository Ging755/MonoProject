using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Repository.Common
{
    public interface IUnitOfWOrk
    {
        //Create
        Task<int> AddAsync<T>(T entity) where T : class;

        //Commit
        Task<int> CommitAsync();

        //Delete
        Task<int> DeleteAsync<T>(T entity) where T : class;

        Task<int> DeleteAsync<T>(string ID) where T : class;

        //Update
        Task<int> UpdateAsync<T>(T entity) where T : class;
    }
}
