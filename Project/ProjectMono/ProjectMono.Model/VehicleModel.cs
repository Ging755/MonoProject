using ProjectMono.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Model
{
    public class VehicleModel : IVehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string ImagePath { get; set; }
        public int VehicleMakeId { get; set; }
    }
}
