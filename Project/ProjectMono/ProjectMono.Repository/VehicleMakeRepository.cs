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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        protected IGenericRepository<VehicleMakeEntity> Repository;
        public VehicleMakeRepository(IGenericRepository<VehicleMakeEntity> repository)
        {
            Repository = repository;
        }
        public async Task AddVehicleMakeAsync(IVehicleMake entity)
        {
            await Repository.AddAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));
        }

        public async Task DeleteVehicleMakeAsync(IVehicleMake entity)
        {
            await Repository.DeleteAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));
        }

        public async Task<IPagedResult<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            IEnumerable<VehicleMakeEntity> vehicleMakeList;
            switch (sortParameters.Sort)
            {
                case "Name":
                    if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleMakeList = await Repository.GetVehiclesAsync().Where(x => x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Name).ToListAsync();
                    }
                    else
                    {
                        vehicleMakeList = await Repository.GetVehiclesAsync().OrderBy(x => x.Name).ToListAsync();
                    }
                    break;
                case "Abrv":
                    if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleMakeList = await Repository.GetVehiclesAsync().Where(x => x.Abrv.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Abrv).ToListAsync();
                    }
                    else
                    {
                        vehicleMakeList = await Repository.GetVehiclesAsync().OrderBy(x => x.Abrv).ToListAsync();
                    }
                    break;
                default:
                    if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleMakeList = await Repository.GetVehiclesAsync().Where(x => x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Name).ToListAsync();
                    }
                    else
                    {
                        vehicleMakeList = await Repository.GetVehiclesAsync().OrderBy(x => x.Id).ToListAsync();
                    }
                    break;
            }
            if(sortParameters.SortDirection != null)
            {
                if (sortParameters.SortDirection.ToUpper() == "DESCENDING")
                {
                    vehicleMakeList = vehicleMakeList.Reverse();
                }
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
            vehicleMakeList = vehicleMakeList.Skip((int)skipAmount).Take(pageParameters.PageSize);
            vehicleMakeList = vehicleMakeList.ToList();
            var totalNumberOfRecords = vehicleMakeList.Count();
            var mod = totalNumberOfRecords % pageParameters.PageSize;
            var totalPageCount = (totalNumberOfRecords / pageParameters.PageSize) + (mod == 0 ? 0 : 1);
            PagedResult<IVehicleMake> IPagedVehicleMake = new PagedResult<IVehicleMake>()
            {
                PageNumber = (int)pageParameters.Page,
                PageSize = pageParameters.PageSize,
                TotalNumberOfPages = totalPageCount,
                Results = AutoMapper.Mapper.Map<IEnumerable<IVehicleMake>>(vehicleMakeList)
            };
            return IPagedVehicleMake;
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return AutoMapper.Mapper.Map<IVehicleMake>(await Repository.GetVehicleAsync(id));
        }

        public async Task UpdateVehicleMakeAsync(IVehicleMake entity)
        {
            await Repository.EditAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));
        }
    }
}
