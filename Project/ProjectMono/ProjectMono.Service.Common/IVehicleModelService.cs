using ProjectMono.Common.PagedResult;
using ProjectMono.Common.PagedResultCommon;
using ProjectMono.Common.ParametersCommon;
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
        Task<IVehicleModel> GetVehicleModelAsync(int id);
        Task<IPagedResult<IVehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters, int? makeId);
        //Update
        Task<Boolean> UpdateVehicleModelAsync(IVehicleModel entity);
        //Delete
        Task<Boolean> DeleteVehicleModelAsync(int id);
    }
}
