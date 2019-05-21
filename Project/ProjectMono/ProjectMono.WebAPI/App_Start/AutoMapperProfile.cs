using AutoMapper;
using ProjectMono.Common.PagedResultCommon;
using ProjectMono.Model;
using ProjectMono.Model.Common;
using ProjectMono.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMono.WebAPI.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<IVehicleMake, VehicleMakeVM>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModelVM>().ReverseMap();
            CreateMap<IPagedResult<VehicleMakeVM>,IPagedResult<IVehicleMake>>().ReverseMap();
            CreateMap<IPagedResult<VehicleModelVM>, IPagedResult<IVehicleModel>>().ReverseMap();
        }
    }
}