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
        /// <summary>
        /// AutoMapperProfile
        /// Maps VehicleModelEntity's VehicleMakeEntityId to IVehicleModel's MakeId,
        /// maps VehicleModelEntity's VehicleMakeEntityId to VehicleModel's MakeId,
        /// everything else is mapped automatically since they are named the same.
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<VehicleMakeEntity, VehicleMake>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
            CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
            CreateMap<VehicleModelEntity, IVehicleModel>().ForMember(dest => dest.MakeId,
                opts => opts.MapFrom(src => src.VehicleMakeEntityId)).ReverseMap().ForMember(
                dest => dest.VehicleMakeEntityId, opts => opts.MapFrom(src => src.MakeId));
            CreateMap<VehicleModelEntity, VehicleModel>().ForMember(dest => dest.MakeId,
                opts => opts.MapFrom(src => src.VehicleMakeEntityId)).ReverseMap().ForMember(
                dest => dest.VehicleMakeEntityId, opts => opts.MapFrom(src => src.MakeId));
        }
    }
}
