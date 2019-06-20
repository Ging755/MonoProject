using ProjectMono.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Model
{
    /// <summary>
    /// VehicleMake model class.
    /// </summary>
    public class VehicleMake : IVehicleMake
    {
        public int Id { get; set; }

        /// <summary>
        /// VehicleMake name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// VehicleMake abbreviation.
        /// </summary>
        public string Abrv { get; set; }
    }
}
