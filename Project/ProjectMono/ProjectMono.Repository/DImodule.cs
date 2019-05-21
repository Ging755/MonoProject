using Ninject.Extensions.Factory;
using Ninject.Modules;
using ProjectMono.DAL.Entities;
using ProjectMono.Repository.Common;
using ProjectMono.Repository.UOFW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Repository
{
    public class DImodule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGenericRepository<VehicleModelEntity>>().To<GenericRepository<VehicleModelEntity>>();
            Bind<IGenericRepository<VehicleMakeEntity>>().To<GenericRepository<VehicleMakeEntity>>();
            Bind<IVehicleMakeRepository>().To<VehicleMakeRepository>();
            Bind<IVehicleModelRepository>().To<VehicleModelRepository>();
            Bind<IUnitOfWorkFactory>().ToFactory();
        }
    }
}
