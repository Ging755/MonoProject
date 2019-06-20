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
    /// Interface for VehicleMakeRepository.
    /// </summary>
    public interface IVehicleMakeRepository
    {
        /// <summary>
        /// Create method,
        /// creates a new VehicleMake using Generic Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleMake.</param>
        Task AddVehicleMakeAsync(IVehicleMake entity);

        /// <summary>
        /// Read method,
        /// gets a VehicleMake from Generic Repository.
        /// </summary>
        /// <param name="id">Id, type of int.</param>
        /// <returns>Returns a single IVehicleMake.</returns>
        Task<IVehicleMake> GetVehicleMakeAsync(int id);

        /// <summary>
        /// Read method,
        /// gets a list of VehicleMakes from Generic Repository,
        /// does sorting, filtering and pagging.
        /// </summary>
        /// <param name="sortParameters">Has 2 properties: Sort and Sort Direction.</param>
        /// <param name="filterParameters">Has 2 properties: Search and MakeId.</param>
        /// <param name="pageParameters">Has 2 properties: Page and PageSize.</param>
        /// <returns>Returns a list of paged, sorted and filtered IVehicleMake.</returns>
        Task<IPagedResult<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);

        /// <summary>
        /// Update method,
        /// updates/edits a VehicleMake using Generic Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleMake.</param>
        Task UpdateVehicleMakeAsync(IVehicleMake entity);

        /// <summary>
        /// Delete method,
        /// deletes a VehicleMake using Generic Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleMake.</param>
        Task DeleteVehicleMakeAsync(IVehicleMake entity);
    }
}
