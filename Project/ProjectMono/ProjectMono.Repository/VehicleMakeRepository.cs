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

        //Create
        public async Task AddVehicleMakeAsync(IVehicleMake entity)
        {
            await Repository.AddAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));
        }

        //Delete
        public async Task DeleteVehicleMakeAsync(IVehicleMake entity)
        {
            await Repository.DeleteAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));
        }

        //Read
        //Sorts, filters and pages a list of VehicleMakes
        public async Task<IPagedResult<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            IQueryable<VehicleMakeEntity> vehicleMakeList;
            PagedResult<IVehicleMake> PagedVehicleMake = new PagedResult<IVehicleMake>();
            switch (sortParameters.Sort)
            {
                case "Name":
                    if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleMakeList = Repository.GetVehiclesAsync().Where(x => x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Name).AsQueryable();
                    }
                    else
                    {
                        vehicleMakeList = Repository.GetVehiclesAsync().OrderBy(x => x.Name).AsQueryable();
                    }
                    break;
                case "Abrv":
                    if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleMakeList = Repository.GetVehiclesAsync().Where(x => x.Abrv.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Abrv).AsQueryable();
                    }
                    else
                    {
                        vehicleMakeList = Repository.GetVehiclesAsync().OrderBy(x => x.Abrv).AsQueryable();
                    }
                    break;
                default:
                    if (!string.IsNullOrEmpty(filterParameters.Search))
                    {
                        vehicleMakeList = Repository.GetVehiclesAsync().Where(x => x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Name).AsQueryable();
                    }
                    else
                    {
                        vehicleMakeList = Repository.GetVehiclesAsync().OrderBy(x => x.Id).AsQueryable();
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

        //Gets a single VehicleMake by Id
        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return AutoMapper.Mapper.Map<IVehicleMake>(await Repository.GetVehicleAsync(id));
        }

        //Update
        public async Task UpdateVehicleMakeAsync(IVehicleMake entity)
        {
            await Repository.EditAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));
        }
    }
}
