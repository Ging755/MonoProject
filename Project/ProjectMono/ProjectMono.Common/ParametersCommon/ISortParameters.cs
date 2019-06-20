using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.ParametersCommon
{
    /// <summary>
    /// Interface containing sort parameters.
    /// </summary>
    public interface ISortParameters
    {
        /// <summary>
        /// Sort parameter can be Name and/or Abrv.
        /// </summary>
        string Sort { get; set; }

        /// <summary>
        /// Sort direction parameter can be Ascending and Descending.
        /// </summary>
        string SortDirection { get; set; }
    }
}
