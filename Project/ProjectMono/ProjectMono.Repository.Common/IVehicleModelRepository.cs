using ProjectMono.Common.PagedResultCommon;
using ProjectMono.Common.ParametersCommon;
using ProjectMono.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Repository.Common
{
    /// <summary>
    /// Interface for VehicleModelRepository.
    /// </summary>
    public interface IVehicleModelRepository
    {
        /// <summary>
        /// Create method,
        /// creates a new VehicleModel using Generic Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleModel.</param>
        Task AddVehicleModelAsync(IVehicleModel entity);

        /// <summary>
        /// Read method,
        /// gets VehicleModel from Generic Repository.
        /// </summary>
        /// <param name="id">Id, type of int.</param>
        /// <returns>Returns a single IVehicleModel.</returns>
        Task<IVehicleModel> GetVehicleModelAsync(int id);

        /// <summary>
        /// Read method,
        /// gets a list of VehicleModels from Generic Repository,
        /// does sorting, filtering and pagging.
        /// </summary>
        /// <param name="sortParameters">Has 2 properties: Sort and Sort Direction.</param>
        /// <param name="filterParameters">Has 2 properties: Search and MakeId.</param>
        /// <param name="pageParameters">Has 2 properties: Page and PageSize.</param>
        /// <returns>Retuns a list of paged, sorted and filtered IVehicleModel.</returns>
        Task<IPagedResult<IVehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);

        /// <summary>
        /// Update method,
        /// updates/edits VehicleModel using Generic Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleModel.</param>
        Task UpdateVehicleModelAsync(IVehicleModel entity);

        /// <summary>
        /// delete method,
        /// deletes a VehicleModel using Generic Repository.
        /// </summary>
        /// <param name="entity">Model, type of a IVehicleModel.</param>
        Task DeleteVehicleModelAsync(IVehicleModel entity);
    }
}
