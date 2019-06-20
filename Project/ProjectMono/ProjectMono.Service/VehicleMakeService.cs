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
    /// <summary>
    /// VehicleMakeService class.
    /// </summary>
    public class VehicleMakeService : IVehicleMakeService
    {
        protected IVehicleMakeRepository repository;
        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Create method,
        /// creates VehicleMake using VehicleMake Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleMake.</param>
        public async Task AddVehicleMakeAsync(IVehicleMake entity)
        {
            await repository.AddVehicleMakeAsync(entity);
        }

        /// <summary>
        /// Delete method,
        /// deletes VehicleMake using VehicleMake Repository.
        /// </summary>
        /// <param name="Id">VehicleMake Id, type of int.</param>
        /// <returns>Returns boolean to controller, so controller knows if VehicleMake was deleted or not.</returns>
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

        /// <summary>
        /// Read method,
        /// gets a single VehicleMake from repository.
        /// </summary>
        /// <param name="id">VehicleMake Id, type of int.</param>
        /// <returns>Returns a single IVehicleMake.</returns>
        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return await repository.GetVehicleMakeAsync(id);
        }

        /// <summary>
        /// Read method,
        /// gets list of VehicleMakes from VehicleMake Repository,
        /// does sorting, filtering and pagging.
        /// </summary>
        /// <param name="sortParameters">>Has 2 properties: Sort and Sort Direction.</param>
        /// <param name="filterParameters">Has 2 properties: Search and MakeId.</param>
        /// <param name="pageParameters">Has 2 properties: Page and PageSize.</param>
        /// <returns>Returns a list of paged, sorted and filtered IVehicleMake.</returns>
        public async Task<IPagedResult<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            return await repository.GetVehicleMakesAsync(sortParameters, filterParameters, pageParameters);
        }

        /// <summary>
        /// Update method,
        /// updates/edits VehicleMake.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleMake.</param>
        /// <returns>Returns boolean to controller, so controller knows if VeickeMake was update or not.</returns>
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
