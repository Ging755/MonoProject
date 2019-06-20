using ProjectMono.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Model.Common
{
    /// <summary>
    /// VehicleModel interface.
    /// </summary>
    public interface IVehicleModel
    {
        int Id { get; set; }

        /// <summary>
        /// VehicleModel name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// VehicleModel abbreviation.
        /// </summary>
        string Abrv { get; set; }

        /// <summary>
        /// VehicleModel's make Id.
        /// </summary>
        int MakeId { get; set; }
    }
}
