using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.DAL.Entities
{
    public class VehicleMakeEntity
    {
        [Key]
        public int Id { get; set; }
        //Name of VehicleMakeEntity
        public string Name { get; set; }
        //Abbreviation of VehicleMakeEntity
        public string Abrv { get; set; }
        //List of VehicleModelsEntity
        public virtual ICollection<VehicleModelEntity> VehicleModels { get; set; }

        public VehicleMakeEntity()
        {
            VehicleModels = new HashSet<VehicleModelEntity>();
        }
    }
}
