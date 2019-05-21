using ProjectMono.Common.PagedResult;
using ProjectMono.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Service.Common
{
    public interface IVehicleMakeService
    {
        //Create
        Task AddVehicleMakeAsync(IVehicleMake entity);
        //Read
        Task<IVehicleMake> GetVehicleMake(int id);
        Task<PagedResult<IVehicleMake>> GetVehicleMakes();
        //Update
        Task UpdateVehicleMakeAsync(IVehicleMake entity);
        //Delete
        Task DeleteVehicleMakeAsync(IVehicleMake entity);
    }
}
