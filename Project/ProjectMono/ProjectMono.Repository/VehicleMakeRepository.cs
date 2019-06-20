using ProjectMono.Common.PagedResult;
using ProjectMono.Common.PagedResultCommon;
using ProjectMono.Common.ParametersCommon;
using ProjectMono.DAL.Entities;
using ProjectMono.Model.Common;
using ProjectMono.Repository.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMono.Repository
{
    /// <summary>
    /// VehicleMakeRepository class.
    /// </summary>
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        protected IGenericRepository<VehicleMakeEntity> Repository;
        public VehicleMakeRepository(IGenericRepository<VehicleMakeEntity> repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Create method,
        /// creates a new VehicleMake using Generic Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleMake.</param>
        public async Task AddVehicleMakeAsync(IVehicleMake entity)
        {
            await Repository.AddAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));
        }

        /// <summary>
        /// Delete method,
        /// deletes a VehicleMake using Generic Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleMake.</param>
        public async Task DeleteVehicleMakeAsync(IVehicleMake entity)
        {
            await Repository.DeleteAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));
        }

        /// <summary>
        /// Read method,
        /// gets a list of VehicleMakes from Generic Repository,
        /// does sorting, filtering and pagging.
        /// </summary>
        /// <param name="sortParameters">Has 2 properties: Sort and Sort Direction.</param>
        /// <param name="filterParameters">Has 2 properties: Search and MakeId.</param>
        /// <param name="pageParameters">Has 2 properties: Page and PageSize.</param>
        /// <returns>Returns a list of paged, sorted and filtered IVehicleMake.</returns>
        public async Task<IPagedResult<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            IQueryable<VehicleMakeEntity> vehicleMakeList;
            PagedResult<IVehicleMake> PagedVehicleMake = new PagedResult<IVehicleMake>();
            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                vehicleMakeList = Repository.GetVehiclesAsync().Where(x => x.Abrv.ToUpper() == filterParameters.Search.ToUpper() || x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Id).AsQueryable();
            }
            else
            {
                vehicleMakeList = Repository.GetVehiclesAsync().OrderBy(x => x.Id);
            }
            if (!string.IsNullOrEmpty(sortParameters.Sort))
            {
                if(sortParameters.Sort.ToUpper() == "NAME")
                {
                    vehicleMakeList = vehicleMakeList.OrderBy(x => x.Name).AsQueryable();
                }
                else if(sortParameters.Sort.ToUpper() == "ABRV")
                {
                    vehicleMakeList = vehicleMakeList.OrderBy(x => x.Abrv).AsQueryable();
                }
            }
            else
            {
                vehicleMakeList = vehicleMakeList.OrderBy(x => x.Id).AsQueryable();
            }
            if (sortParameters.SortDirection.ToUpper() == "DESCENDING")
            {
                vehicleMakeList.Reverse();
            }
            if (pageParameters.PageSize != 0)
            {
                int? skipAmount;
                if (pageParameters.Page == 0 || pageParameters.Page == null)
                {
                    skipAmount = 0;
                }
                else
                {
                    skipAmount = (pageParameters.PageSize * (pageParameters.Page - 1));
                }
                var totalNumberOfRecords = vehicleMakeList.Count();
                vehicleMakeList = vehicleMakeList.Skip((int)skipAmount).Take(pageParameters.PageSize).AsQueryable();
                var mod = totalNumberOfRecords % pageParameters.PageSize;
                var totalPageCount = (totalNumberOfRecords / pageParameters.PageSize) + (mod == 0 ? 0 : 1);
                var Results = AutoMapper.Mapper.Map<IEnumerable<IVehicleMake>>(vehicleMakeList.ToList());
                PagedVehicleMake.PageNumber = (int)pageParameters.Page;
                PagedVehicleMake.PageSize = pageParameters.PageSize;
                PagedVehicleMake.TotalNumberOfPages = totalPageCount;
                if (sortParameters.SortDirection != null)
                {
                    if (sortParameters.SortDirection.ToUpper() == "DESCENDING")
                    {
                        Results = Results.Reverse();
                    }
                }
                PagedVehicleMake.Results = Results;
            }
            else
            {
                PagedVehicleMake.PageNumber = 0;
                PagedVehicleMake.PageSize = 0;
                PagedVehicleMake.TotalNumberOfPages = 0;
                PagedVehicleMake.Results = AutoMapper.Mapper.Map<IEnumerable<IVehicleMake>>(vehicleMakeList.ToList());
            }

            return PagedVehicleMake;
        }

        /// <summary>
        /// Read method,
        /// gets a single VehicleMake from Generic Repository.
        /// </summary>
        /// <param name="id">VehicleMake Id, type of int.</param>
        /// <returns>Returns a single IVehicleMake.</returns>
        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return AutoMapper.Mapper.Map<IVehicleMake>(await Repository.GetVehicleAsync(id));
        }

        /// <summary>
        /// Update method,
        /// updates/edits VehicleMake using Generic Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleMake.</param>
        public async Task UpdateVehicleMakeAsync(IVehicleMake entity)
        {
            await Repository.EditAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));
        }
    }
}
