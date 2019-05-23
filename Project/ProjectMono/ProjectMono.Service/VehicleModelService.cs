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

        //Create
        public async Task AddVehicleModelAsync(IVehicleModel entity)
        {
            await repository.AddVehicleModelAsync(entity);
        }

        //Delete
        public async Task<Boolean> DeleteVehicleModelAsync(int id)
        {
            var entity = await repository.GetVehicleModelAsync(id);
            if(entity != null)
            {
                await repository.DeleteVehicleModelAsync(entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Read
        //Gets a single VehicleModel by Id from repository
        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return await repository.GetVehicleModelAsync(id);
        }
        //Gets sorted, flitered and paged VehicleModel list from repositroy
        public async Task<IPagedResult<IVehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters, int? makeId)
        {
            return await repository.GetVehicleModelsAsync(sortParameters, filterParameters, pageParameters, makeId);
        }

        //Update
        public async Task<Boolean> UpdateVehicleModelAsync(IVehicleModel entity)
        {
            if (await repository.GetVehicleModelAsync(entity.Id) != null)
            {
                await repository.UpdateVehicleModelAsync(entity);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
