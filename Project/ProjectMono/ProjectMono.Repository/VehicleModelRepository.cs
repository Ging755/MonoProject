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
    public class VehicleModelRepository : IVehicleModelRepository
    {
        protected IGenericRepository<VehicleModelEntity> Repository;
        public VehicleModelRepository(IGenericRepository<VehicleModelEntity> repository)
        {
            Repository = repository;
        }

        //Create
        public async Task AddVehicleModelAsync(IVehicleModel entity)
        {
           await Repository.AddAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
        }

        //Delete

        public async Task DeleteVehicleModelAsync(IVehicleModel entity)
        {
            await Repository.DeleteAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
        }


        //Read
        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return AutoMapper.Mapper.Map<IVehicleModel>(await Repository.GetVehicleAsync(id)); 
        }

        public async Task<IPagedResult<IVehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters, int? makeId)
        {
            IQueryable<VehicleModelEntity> vehicleModelList;
            PagedResult<IVehicleModel> PagedVehicleModel = new PagedResult<IVehicleModel>();
            switch (sortParameters.Sort)
            {
                case "Name":
                    if (!string.IsNullOrEmpty(filterParameters.Search) && makeId != 0)
                    {
                        vehicleModelList = Repository.GetVehiclesAsync().Where(x => x.Name.ToUpper().Contains(filterParameters.Search) && x.VehicleMakeEntityId == makeId).OrderBy(x => x.Name).AsQueryable();
                    }
                    else if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleModelList = Repository.GetVehiclesAsync().Where(x => x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Name).AsQueryable();
                    }
                    else if (makeId != 0)
                    {
                        vehicleModelList = Repository.GetVehiclesAsync().Where(x => x.VehicleMakeEntityId == makeId).OrderBy(x => x.Name).AsQueryable(); 
                    }
                    else
                    {
                        vehicleModelList = Repository.GetVehiclesAsync().OrderBy(x => x.Name);
                    }
                    break;
                case "Abrv":
                    if (!string.IsNullOrEmpty(filterParameters.Search) && makeId != 0)
                    {
                        vehicleModelList = Repository.GetVehiclesAsync().Where(x => x.Abrv.ToUpper().Contains(filterParameters.Search) && x.VehicleMakeEntityId == makeId).OrderBy(x => x.Abrv).AsQueryable();
                    }
                    else if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleModelList = Repository.GetVehiclesAsync().Where(x => x.Abrv.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Abrv).AsQueryable();
                    }
                    else if (makeId != 0)
                    {
                        vehicleModelList = Repository.GetVehiclesAsync().Where(x => x.VehicleMakeEntityId == makeId).OrderBy(x => x.Abrv).AsQueryable();
                    }
                    else
                    {
                        vehicleModelList = Repository.GetVehiclesAsync().OrderBy(x => x.Abrv).AsQueryable();
                    }
                    break;
                default:
                    if (!string.IsNullOrEmpty(filterParameters.Search) && makeId != 0)
                    {
                        vehicleModelList = Repository.GetVehiclesAsync().Where(x => x.Name.ToUpper().Contains(filterParameters.Search) && x.VehicleMakeEntityId == makeId).OrderBy(x => x.Id).AsQueryable();
                    }
                    else if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleModelList = Repository.GetVehiclesAsync().Where(x => x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Id).AsQueryable();
                    }
                    else if (makeId != 0)
                    {
                        vehicleModelList = Repository.GetVehiclesAsync().Where(x => x.VehicleMakeEntityId == makeId).OrderBy(x => x.Id).AsQueryable();
                    }
                    else
                    {
                        vehicleModelList = Repository.GetVehiclesAsync().OrderBy(x => x.Id).AsQueryable();
                    }
                    break;
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

        //Update
        public async Task UpdateVehicleModelAsync(IVehicleModel entity)
        {
            await Repository.EditAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
        }
    }
}
