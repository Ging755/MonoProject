using ProjectMono.DAL.Entities;
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
        //VehicleModel name
        public string Name { get; set; }
        //VehicleModel Abbreviation
        public string Abrv { get; set; }
        //VehicleModel's Make Id
        public int MakeId { get; set; }
    }
}
