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
            //CreateMap<VehicleModelEntity, VehicleModel>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
            CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
            //CreateMap<VehicleModelEntity, IVehicleModel>().ReverseMap();
            CreateMap<VehicleModelEntity, IVehicleModel>().ForMember(dest => dest.MakeId,
                opts => opts.MapFrom(src => src.VehicleMakeEntityId)).ReverseMap().ForMember(
                dest => dest.VehicleMakeEntityId, opts => opts.MapFrom(src => src.MakeId));
            CreateMap<VehicleModelEntity, VehicleModel>().ForMember(dest => dest.MakeId,
                opts => opts.MapFrom(src => src.VehicleMakeEntityId)).ReverseMap().ForMember(
                dest => dest.VehicleMakeEntityId, opts => opts.MapFrom(src => src.MakeId));
        }
    }
}
