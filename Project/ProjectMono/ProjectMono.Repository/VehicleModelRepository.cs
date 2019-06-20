using ProjectMono.Common.PagedResult;
using ProjectMono.Common.PagedResultCommon;
using ProjectMono.Common.ParametersCommon;
using ProjectMono.DAL.Entities;
using ProjectMono.Model;
using ProjectMono.Model.Common;
using ProjectMono.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Repository
{
    /// <summary>
    /// VehicleModelRepository class.
    /// </summary>
    public class VehicleModelRepository : IVehicleModelRepository
    {
        protected IGenericRepository<VehicleModelEntity> Repository;
        public VehicleModelRepository(IGenericRepository<VehicleModelEntity> repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Create method,
        /// creates a new VehicleModel using Generic Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleModel.</param>
        public async Task AddVehicleModelAsync(IVehicleModel entity)
        {
           await Repository.AddAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
        }

        /// <summary>
        /// Delete method,
        /// deletes a VehicleModel using Generic Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleModel.</param>
        public async Task DeleteVehicleModelAsync(IVehicleModel entity)
        {
            await Repository.DeleteAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
        }


        /// <summary>
        /// Read method,
        /// gets VehicleModel from Generic Repository.
        /// </summary>
        /// <param name="id">Id, type of int.</param>
        /// <returns>Returns a single IVehicleModel.</returns>
        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return AutoMapper.Mapper.Map<IVehicleModel>(await Repository.GetVehicleAsync(id)); 
        }

        /// <summary>
        /// Read method,
        /// gets a list of VehicleModels from Generic Repository,
        /// does sorting, filtering and pagging.
        /// </summary>
        /// <param name="sortParameters">Has 2 properties: Sort and Sort Direction.</param>
        /// <param name="filterParameters">Has 2 properties: Search and MakeId.</param>
        /// <param name="pageParameters">Has 2 properties: Page and PageSize.</param>
        /// <returns>Retuns a list of paged, sorted and filtered IVehicleModel.</returns>
        public async Task<IPagedResult<IVehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            IQueryable<VehicleModelEntity> vehicleModelList;
            PagedResult<IVehicleModel> PagedVehicleModel = new PagedResult<IVehicleModel>();
            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                vehicleModelList = Repository.GetVehiclesAsync().Where(x => x.Abrv.ToUpper() == filterParameters.Search.ToUpper() || x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Id).AsQueryable();
            }
            else
            {
                vehicleModelList = Repository.GetVehiclesAsync().OrderBy(x => x.Id);
            }
            if(filterParameters.VehicleMakeId != null)
            {
                vehicleModelList = vehicleModelList.Where(x => x.VehicleMakeEntityId == filterParameters.VehicleMakeId);
            }
            if (!string.IsNullOrEmpty(sortParameters.Sort))
            {
                if (sortParameters.Sort.ToUpper() == "NAME")
                {
                    vehicleModelList = vehicleModelList.OrderBy(x => x.Name).AsQueryable();
                }
                else if (sortParameters.Sort.ToUpper() == "ABRV")
                {
                    vehicleModelList = vehicleModelList.OrderBy(x => x.Abrv).AsQueryable();
                }
            }
            else
            {
                vehicleModelList = vehicleModelList.OrderBy(x => x.Id).AsQueryable();
            }
            if (sortParameters.SortDirection.ToUpper() == "DESCENDING")
            {
                vehicleModelList.Reverse();
            }
            if(pageParameters.PageSize != 0)
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
                var totalNumberOfRecords = vehicleModelList.Count();
                vehicleModelList = vehicleModelList.Skip((int)skipAmount).Take(pageParameters.PageSize).AsQueryable();
                var mod = totalNumberOfRecords % pageParameters.PageSize;
                var totalPageCount = (totalNumberOfRecords / pageParameters.PageSize) + (mod == 0 ? 0 : 1);
                var Results = AutoMapper.Mapper.Map<IEnumerable<IVehicleModel>>(vehicleModelList.ToList());
                PagedVehicleModel.PageNumber = (int)pageParameters.Page;
                PagedVehicleModel.PageSize = pageParameters.PageSize;
                PagedVehicleModel.TotalNumberOfPages = totalPageCount;
                if (sortParameters.SortDirection != null)
                {
                    if (sortParameters.SortDirection.ToUpper() == "DESCENDING")
                    {
                        Results = Results.Reverse();
                    }
                }
                PagedVehicleModel.Results = Results;
            }
            else
            {
                PagedVehicleModel.PageNumber = 0;
                PagedVehicleModel.PageSize = 0;
                PagedVehicleModel.TotalNumberOfPages = 0;
                PagedVehicleModel.Results = AutoMapper.Mapper.Map<IEnumerable<IVehicleModel>>(vehicleModelList);
            }
            return PagedVehicleModel;
        }

        /// <summary>
        /// Update method,
        /// updates/edits VehicleModel using Generic Repository.
        /// </summary>
        /// <param name="entity">Model, type of IVehicleModel.</param>
        public async Task UpdateVehicleModelAsync(IVehicleModel entity)
        {
            await Repository.EditAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
        }
    }
}
