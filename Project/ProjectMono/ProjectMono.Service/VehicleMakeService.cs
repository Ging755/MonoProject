using ProjectMono.Common.PagedResult;
using ProjectMono.Common.PagedResultCommon;
using ProjectMono.Common.ParametersCommon;
using ProjectMono.Model.Common;
using ProjectMono.Repository;
using ProjectMono.Repository.Common;
using ProjectMono.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        protected IVehicleMakeRepository repository;
        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            this.repository = repository;
        }
        public async Task AddVehicleMakeAsync(IVehicleMake entity)
        {
            await repository.AddVehicleMakeAsync(entity);
        }

        public async Task DeleteVehicleMakeAsync(IVehicleMake entity)
        {
            await repository.DeleteVehicleMakeAsync(entity);
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return await repository.GetVehicleMakeAsync(id);
        }

        public async Task<IPagedResult<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            return await repository.GetVehicleMakesAsync(sortParameters, filterParameters, pageParameters);
        }

        public async Task UpdateVehicleMakeAsync(IVehicleMake entity)
        {
            await repository.UpdateVehicleMakeAsync(entity);
        }
    }
}
