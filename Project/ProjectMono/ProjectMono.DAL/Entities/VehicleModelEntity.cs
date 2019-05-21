using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.DAL.Entities
{
    public class VehicleModelEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string ImagePath { get; set; }

        public int VehicleMakeId { get; set; }
        public virtual VehicleMakeEntity VehicleMake { get; set; }
    }
}
