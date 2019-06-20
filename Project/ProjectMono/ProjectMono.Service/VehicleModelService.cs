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
    /// <summary>
    /// VehicleModelService class.
    /// </summary>
    public class VehicleModelService : IVehicleModelService
    {
        protected IVehicleModelRepository repository;
        public VehicleModelService(IVehicleModelRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Create method,
        /// creates a new VehicleModel using VehicleModel Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleModel.</param>
        public async Task AddVehicleModelAsync(IVehicleModel entity)
        {
            await repository.AddVehicleModelAsync(entity);
        }

        /// <summary>        
        /// Delete method,
        /// deletes a VehicleModel using VehicleModel Repository.
        /// </summary>
        /// <param name="id">VehicleModel Id, type of int.</param>
        /// <returns>Returns boolean to controller, so controller knows if VehicleModel was deleted or not.</returns>
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

        /// <summary>
        /// Read method,
        /// gets a single VehicleModel using VehicleModel Repository.
        /// </summary>
        /// <param name="id">VehicleModel Id, type of int.</param>
        /// <returns>Returns a single IVehicleModel.</returns>
        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return await repository.GetVehicleModelAsync(id);
        }

        /// <summary>
        /// Read method,
        /// gets a list of VehicleModels from VehicleModel Repository,
        /// does sorting, filtering and pagging.
        /// </summary>
        /// <param name="sortParameters">Has 2 properties: Sort and Sort Direction.</param>
        /// <param name="filterParameters">Has 2 properties: Search and MakeId.</param>
        /// <param name="pageParameters">Has 2 properties: Page and PageSize.</param>
        /// <returns>Retuns a list of paged, sorted and filtered IVehicleModel.</returns>
        public async Task<IPagedResult<IVehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            return await repository.GetVehicleModelsAsync(sortParameters, filterParameters, pageParameters);
        }

        /// <summary>
        /// Update method,
        /// updates/edits a VehicleModel using VehicleModel Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleModel.</param>
        /// <returns>Returns boolean to controller, so controller knows if VehicleModel was updated or not.</returns>
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
