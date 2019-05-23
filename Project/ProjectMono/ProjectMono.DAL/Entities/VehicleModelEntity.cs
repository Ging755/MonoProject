using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.DAL.Entities
{
    public class VehicleModelEntity
    {
        [Key]
        public int Id { get; set; }
        //Name of VehicleModelEntity
        public string Name { get; set; }
        //Abbreviation of VehicleMakeEntity
        public string Abrv { get; set; }
        //VehicleMakeEntityId
        public int VehicleMakeEntityId { get; set; }
        //VehicleMakeEntity of VehicleModelEntity
        public virtual VehicleMakeEntity VehicleMake { get; set; }
    }
}
