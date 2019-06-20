using ProjectMono.Common.ParametersCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.Parameters
{
    /// <summary>
    /// Class containing filter parameters.
    /// </summary>
    public class FilterParameters : IFilterParameters
    {
        /// <summary>
        /// The search parameter used to search or filter by name.
        /// </summary>
        public string Search { get; set; }
        
        /// <summary>
        /// The vehiclemakeid parameter used to filter by make.
        /// </summary>
        public int? VehicleMakeId { get; set; }
    }
}
