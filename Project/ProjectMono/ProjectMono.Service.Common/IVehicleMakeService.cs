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
    /// Interface for VehicleMakeService.
    /// </summary>
    public interface IVehicleMakeService
    {
        /// <summary>
        /// Create method,
        /// creates VehicleMake using VehicleMake Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleMake.</param>
        Task AddVehicleMakeAsync(IVehicleMake entity);

        /// <summary>
        /// Read method
        /// gets a single VehicleMake from VehicleMake Repository
        /// </summary>
        /// <param name="id">VehicleMake Id, type of int.</param>
        /// <returns>Returns a single IVehicleMake.</returns>
        Task<IVehicleMake> GetVehicleMakeAsync(int id);

        /// <summary>
        /// Read method,
        /// gets list of VehicleMakes from VehicleMake Repository,
        /// does sorting, filtering and pagging.
        /// </summary>
        /// <param name="sortParameters">>Has 2 properties: Sort and Sort Direction.</param>
        /// <param name="filterParameters">Has 2 properties: Search and MakeId.</param>
        /// <param name="pageParameters">Has 2 properties: Page and PageSize.</param>
        /// <returns>Returns a list of paged, sorted and filtered IVehicleMake.</returns>
        Task<IPagedResult<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);

        /// <summary>
        /// Update method,
        /// updates/edits VehicleMake using VehicleMake Repository.
        /// </summary>
        /// <param name="entity">Type of IVehicleMake.</param>
        Task<Boolean> UpdateVehicleMakeAsync(IVehicleMake entity);

        /// <summary>
        /// Delete method,
        /// deletes VehicleMake using VehicleMake Repository.
        /// </summary>
        /// <param name="id">VehicleMake Id, type of int.</param>
        Task<Boolean> DeleteVehicleMakeAsync(int id);
    }
}
