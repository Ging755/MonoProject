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
    /// <summary>
    /// Interface for VehicleModelService.
    /// </summary>
    public interface IVehicleModelService
    {
        /// <summary>
        /// Create method,
        /// creates VehicleModel using VehicleModel Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleModel.</param>
        Task AddVehicleModelAsync(IVehicleModel entity);

        /// <summary>
        /// Read method,
        /// gets a single VehicleModel from VehicleModel Repository.
        /// </summary>
        /// <param name="id">VehicleModel Id, type of int.</param>
        /// <returns>Returns a single IVehicleModel.</returns>
        Task<IVehicleModel> GetVehicleModelAsync(int id);

        /// <summary>
        /// Read method,
        /// gets a list of VehicleModels from VehicleModel Repository
        /// does sorting, filtering and pagging.
        /// </summary>
        /// <param name="sortParameters">Has 2 properties: Sort and Sort Direction.</param>
        /// <param name="filterParameters">Has 2 properties: Search and MakeId.</param>
        /// <param name="pageParameters">Has 2 properties: Page and PageSize.</param>
        /// <returns>Retuns a list of paged, sorted and filtered IVehicleModel.</returns>
        Task<IPagedResult<IVehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);

        /// <summary>
        /// Update method,
        /// updates/edits a VehicleModel using VehicleModel Repository.
        /// </summary>
        /// <param name="entity">Model, type of VehicleModel.</param>
        /// <returns>Returns boolean to controller, so controller knows if VehicleModel was updated or not.</returns>
        Task<Boolean> UpdateVehicleModelAsync(IVehicleModel entity);

        /// <summary>
        /// Delete method,
        /// deletes a VehicleModel using VehicleModel Repository.
        /// </summary>
        /// <param name="id">VehicleModel Id, type of int.</param>
        /// <returns>Returns boolean to controller, so controller knows if VehicleModel was deleted or not.</returns>
        Task<Boolean> DeleteVehicleModelAsync(int id);
    }
}
