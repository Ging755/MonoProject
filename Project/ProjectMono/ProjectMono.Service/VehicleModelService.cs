using ProjectMono.Common.PagedResultCommon;
using ProjectMono.Common.ParametersCommon;
using ProjectMono.Model.Common;
using ProjectMono.Repository.Common;
using ProjectMono.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        protected IVehicleModelRepository repository;
        public VehicleModelService(IVehicleModelRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> AddVehicleModelAsync(IVehicleModel entity)
        {
            int id = await repository.AddVehicleModelAsync(entity);
            return id;
        }

        public async Task DeleteVehicleModelAsync(IVehicleModel entity)
        {
            await repository.DeleteVehicleModelAsync(entity);
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return await repository.GetVehicleModelAsync(id);
        }

        public async Task<IPagedResult<IVehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            return await repository.GetVehicleModelsAsync(sortParameters, filterParameters, pageParameters);
        }

        public async Task UpdateVehicleModelAsync(IVehicleModel entity)
        {
            await repository.UpdateVehicleModelAsync(entity);
        }
    }
}
