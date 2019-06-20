using ProjectMono.Common.ParametersCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.Parameters
{
    /// <summary>
    /// Class containing sort parameters.
    /// </summary>
    public class SortParameters : ISortParameters
    {
        /// <summary>
        /// Sort parameter can be Name and/or Abrv.
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// Sort direction parameter can be Ascending and Descending.
        /// </summary>
        public string SortDirection { get; set; }
    }
}
