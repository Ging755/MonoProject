using ProjectMono.Common.PagedResult;
using ProjectMono.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Service.Common
{
    public interface IVehicleModelService
    {
        //Create
        Task AddVehicleModelAsync(IVehicleModel entity);
        //Read
        Task<IVehicleModel> GetVehicleModel(int id);
        Task<PagedResult<IVehicleModel>> GetVehicleModels();
        //Update
        Task UpdateVehicleModelAsync(IVehicleModel entity);
        //Delete
        Task DeleteVehicleModelAsync(IVehicleModel entity);
    }
}
