using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Model.Common
{
    //Interface for VehicleMake
    public interface IVehicleMake
    {
        int Id { get; set; }
        //VehicleMake name
        string Name { get; set; }
        //VehicleMake Abbreviation
        string Abrv { get; set; }
    }
}
