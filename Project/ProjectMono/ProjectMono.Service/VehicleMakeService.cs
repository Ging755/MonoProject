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

        //Create
        public async Task AddVehicleMakeAsync(IVehicleMake entity)
        {
            await repository.AddVehicleMakeAsync(entity);
        }

        //Delete
        public async Task<Boolean> DeleteVehicleMakeAsync(int Id)
        {
            var entity = await repository.GetVehicleMakeAsync((int)Id);
            if (entity != null)
            {
                await repository.DeleteVehicleMakeAsync(entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Read
        //Gets a single VehicleMake by id from repository
        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return await repository.GetVehicleMakeAsync(id);
        }

        //Gets sorted, filtered and paged list of VehicleMakes from repository
        public async Task<IPagedResult<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            return await repository.GetVehicleMakesAsync(sortParameters, filterParameters, pageParameters);
        }

        //Update
        public async Task<Boolean> UpdateVehicleMakeAsync(IVehicleMake entity)
        {
            if (repository.GetVehicleMakeAsync(entity.Id) != null)
            {
                await repository.UpdateVehicleMakeAsync(entity);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
