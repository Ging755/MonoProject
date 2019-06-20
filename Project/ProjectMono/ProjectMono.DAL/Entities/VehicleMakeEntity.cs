using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.DAL.Entities
{
    /// <summary>
    /// VehicleMake entity.
    /// </summary>
    public class VehicleMakeEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Name of VehicleMakeEntity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Abbreviation of VehicleMakeEntity.
        /// </summary>
        public string Abrv { get; set; }

        /// <summary>
        /// One to Many connection with VehicleModelEntity.
        /// </summary>
        public virtual ICollection<VehicleModelEntity> VehicleModels { get; set; }

        public VehicleMakeEntity()
        {
            VehicleModels = new HashSet<VehicleModelEntity>();
        }
    }
}
