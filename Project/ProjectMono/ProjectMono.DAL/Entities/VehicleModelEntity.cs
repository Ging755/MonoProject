using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.DAL.Entities
{
    /// <summary>
    /// VehicleModel entity.
    /// </summary>
    public class VehicleModelEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Name of VehicleModelEntity.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Abbreviation of VehicleModelEntity.
        /// </summary>
        public string Abrv { get; set; }

        /// <summary>
        /// Many to one connection with VehicleMakeEntity.
        /// </summary>
        public int VehicleMakeEntityId { get; set; }

        public virtual VehicleMakeEntity VehicleMake { get; set; }
    }
}
