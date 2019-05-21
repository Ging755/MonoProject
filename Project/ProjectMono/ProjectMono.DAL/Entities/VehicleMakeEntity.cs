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
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual ICollection<VehicleModelEntity> VehicleModels { get; set; }

        public VehicleMakeEntity()
        {
            VehicleModels = new HashSet<VehicleModelEntity>();
        }
    }
}
