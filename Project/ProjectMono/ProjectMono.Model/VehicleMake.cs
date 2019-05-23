using ProjectMono.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Model
{
    //VehicleMake class
    public class VehicleMake : IVehicleMake
    {
        public int Id { get; set; }
        //VehicleMake name
        public string Name { get; set; }
        //VehicleMake abbreviation
        public string Abrv { get; set; }
    }
}
