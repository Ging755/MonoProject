using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.ParametersCommon
{
    /// <summary>
    /// Interface containing filter parameters.
    /// </summary>
    public interface IFilterParameters
    {
        /// <summary>
        /// The search parameter used to search or filter by name.
        /// </summary>
        string Search { get; set; }

        /// <summary>
        /// The vehiclemakeid parameter used to filter by make.
        /// </summary>
        int? VehicleMakeId { get; set; }
    }
}
