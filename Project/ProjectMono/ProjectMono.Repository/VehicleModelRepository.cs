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
        public async Task AddVehicleModelAsync(IVehicleModel entity)
        {
            var temp = AutoMapper.Mapper.Map<VehicleModelEntity>(entity);
           // temp.VehicleMakeEntityId = entity.MakeId;
           await Repository.AddAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
        }

        public async Task DeleteVehicleModelAsync(IVehicleModel entity)
        {
            //var temp = AutoMapper.Mapper.Map<VehicleModelEntity>(entity);
            // temp.VehicleMakeEntityId = entity.MakeId;
            await Repository.DeleteAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            // var temp = await Repository.GetVehicleAsync(id);
            // var tempModel = AutoMapper.Mapper.Map<IVehicleModel>(temp);
            // tempModel.MakeId = temp.VehicleMakeEntityId;
            return AutoMapper.Mapper.Map<IVehicleModel>(await Repository.GetVehicleAsync(id)); 
        }

        public async Task<IPagedResult<IVehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters, int? makeId)
        {
            IEnumerable<VehicleModelEntity> vehicleModelList;
            PagedResult<IVehicleModel> IPagedVehicleModel = new PagedResult<IVehicleModel>();
            switch (sortParameters.Sort)
            {
                case "Name":
                    if (!string.IsNullOrEmpty(filterParameters.Search) && makeId != 0)
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().Where(x => x.Name.ToUpper().Contains(filterParameters.Search) && x.VehicleMakeEntityId == makeId).OrderBy(x => x.Name).ToListAsync();
                    }
                    else if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().Where(x => x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Name).ToListAsync();
                    }
                    else if (makeId != 0)
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().Where(x => x.VehicleMakeEntityId == makeId).OrderBy(x => x.Name).ToListAsync();
                    }
                    else
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().OrderBy(x => x.Name).ToListAsync();
                    }
                    break;
                case "Abrv":
                    if (!string.IsNullOrEmpty(filterParameters.Search) && makeId != 0)
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().Where(x => x.Abrv.ToUpper().Contains(filterParameters.Search) && x.VehicleMakeEntityId == makeId).OrderBy(x => x.Abrv).ToListAsync();
                    }
                    else if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().Where(x => x.Abrv.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Abrv).ToListAsync();
                    }
                    else if (makeId != 0)
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().Where(x => x.VehicleMakeEntityId == makeId).OrderBy(x => x.Abrv).ToListAsync();
                    }
                    else
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().OrderBy(x => x.Abrv).ToListAsync();
                    }
                    break;
                default:
                    if (!string.IsNullOrEmpty(filterParameters.Search) && makeId != 0)
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().Where(x => x.Name.ToUpper().Contains(filterParameters.Search) && x.VehicleMakeEntityId == makeId).OrderBy(x => x.Id).ToListAsync();
                    }
                    else if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().Where(x => x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Id).ToListAsync();
                    }
                    else if (makeId != 0)
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().Where(x => x.VehicleMakeEntityId == makeId).OrderBy(x => x.Id).ToListAsync();
                    }
                    else
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().OrderBy(x => x.Id).ToListAsync();
                    }
                    break;
            }
            if(sortParameters.SortDirection != null)
            {
                if (sortParameters.SortDirection.ToUpper() == "DESCENDING")
                {
                    vehicleModelList = vehicleModelList.Reverse();
                }
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
                vehicleModelList = vehicleModelList.Skip((int)skipAmount).Take(pageParameters.PageSize).ToList();
                var mod = totalNumberOfRecords % pageParameters.PageSize;
                var totalPageCount = (totalNumberOfRecords / pageParameters.PageSize) + (mod == 0 ? 0 : 1);
                IPagedVehicleModel.PageNumber = (int)pageParameters.Page;
                IPagedVehicleModel.PageSize = pageParameters.PageSize;
                IPagedVehicleModel.TotalNumberOfPages = totalPageCount;
                IPagedVehicleModel.Results = AutoMapper.Mapper.Map<IEnumerable<IVehicleModel>>(vehicleModelList);
            }
            else
            {
                IPagedVehicleModel.PageNumber = 0;
                IPagedVehicleModel.PageSize = 0;
                IPagedVehicleModel.TotalNumberOfPages = 0;
                IPagedVehicleModel.Results = AutoMapper.Mapper.Map<IEnumerable<IVehicleModel>>(vehicleModelList);
            }
            return IPagedVehicleModel;
        }

        public async Task UpdateVehicleModelAsync(IVehicleModel entity)
        {
            // var temp = AutoMapper.Mapper.Map<VehicleModelEntity>(entity);
            // temp.VehicleMakeEntityId = entity.MakeId;
            await Repository.EditAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
        }
    }
}
