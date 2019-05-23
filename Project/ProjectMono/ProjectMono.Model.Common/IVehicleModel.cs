using ProjectMono.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Model.Common
{
    //Interface for VehicleModel
    public interface IVehicleModel
    {
        int Id { get; set; }
        //VehicleModel name
        string Name { get; set; }
        //VehicleModel abbreviation
        string Abrv { get; set; }
        //VehicleModel's make Id
        int MakeId { get; set; }
    }
}
