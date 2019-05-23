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
    public interface IVehicleMakeService
    {
        //Create
        Task AddVehicleMakeAsync(IVehicleMake entity);
        //Read
        Task<IVehicleMake> GetVehicleMakeAsync(int id);
        Task<IPagedResult<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);
        //Update
        Task<Boolean> UpdateVehicleMakeAsync(IVehicleMake entity);
        //Delete
        Task<Boolean> DeleteVehicleMakeAsync(int id);
    }
}
