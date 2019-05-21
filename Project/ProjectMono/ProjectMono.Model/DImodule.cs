using Ninject.Modules;
using ProjectMono.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Model
{
    public class DImodule : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleMake>().To<VehicleMake>();
            Bind<IVehicleModel>().To<VehicleModel>();
        }
    }
}
