using ProjectMono.Common.PagedResult;
using ProjectMono.Common.PagedResultCommon;
using ProjectMono.Common.ParametersCommon;
using ProjectMono.DAL.Entities;
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
        public async Task<int> AddVehicleModelAsync(IVehicleModel entity)
        {
            await Repository.AddAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
            var temp = Repository.GetVehiclesAsync().OrderByDescending(x => x.Id).First();
            return temp.Id;
        }

        public async Task DeleteVehicleModelAsync(IVehicleModel entity)
        {
            await Repository.DeleteAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return AutoMapper.Mapper.Map<IVehicleModel>(await Repository.GetVehicleAsync((int)id));
        }

        public async Task<IPagedResult<IVehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            IEnumerable<VehicleModelEntity> vehicleModelList;
            switch (sortParameters.Sort)
            {
                case "Name":
                    if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().Where(x => x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Name).ToListAsync();
                    }
                    else
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().OrderBy(x => x.Name).ToListAsync();
                    }
                    break;
                case "Abrv":
                    if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().Where(x => x.Abrv.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Abrv).ToListAsync();
                    }
                    else
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().OrderBy(x => x.Abrv).ToListAsync();
                    }
                    break;
                default:
                    if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().Where(x => x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Name).ToListAsync();
                    }
                    else
                    {
                        vehicleModelList = await Repository.GetVehiclesAsync().OrderBy(x => x.Id).ToListAsync();
                    }
                    break;
            }
            if (sortParameters.SortDirection.ToUpper() == "DESCENDING")
            {
                vehicleModelList = vehicleModelList.Reverse();
            }
            int? skipAmount;
            if (pageParameters.Page == 0 || pageParameters.Page == null)
            {
                skipAmount = 0;
            }
            else
            {
                skipAmount = (pageParameters.PageSize * (pageParameters.Page - 1));
            }
            vehicleModelList = vehicleModelList.Skip((int)skipAmount).Take(pageParameters.PageSize);
            vehicleModelList = vehicleModelList.ToList();
            var totalNumberOfRecords = vehicleModelList.Count();
            var mod = totalNumberOfRecords % pageParameters.PageSize;
            var totalPageCount = (totalNumberOfRecords / pageParameters.PageSize) + (mod == 0 ? 0 : 1);
            PagedResult<IVehicleModel> IPagedVehicleModel = new PagedResult<IVehicleModel>()
            {
                PageNumber = (int)pageParameters.Page,
                PageSize = pageParameters.PageSize,
                TotalNumberOfPages = totalPageCount,
                Results = AutoMapper.Mapper.Map<IEnumerable<IVehicleModel>>(vehicleModelList)
            };
            return IPagedVehicleModel;
        }

        public async Task UpdateVehicleModelAsync(IVehicleModel entity)
        {
            await Repository.EditAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
        }
    }
}
