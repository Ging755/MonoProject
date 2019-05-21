using AutoMapper;
using ProjectMono.DAL.Entities;
using ProjectMono.Model;
using ProjectMono.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VehicleMakeEntity, VehicleMake>().ReverseMap();
            CreateMap<VehicleModelEntity, VehicleModel>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
            CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
            CreateMap<VehicleModelEntity, IVehicleModel>().ReverseMap();
        }
    }
}
