using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Model.Common
{
    /// <summary>
    /// VehicleMake interface.
    /// </summary>
    public interface IVehicleMake
    {
        int Id { get; set; }

        /// <summary>
        /// VehicleMake name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// VehicleMake abbreviation.
        /// </summary>
        string Abrv { get; set; }
    }
}
