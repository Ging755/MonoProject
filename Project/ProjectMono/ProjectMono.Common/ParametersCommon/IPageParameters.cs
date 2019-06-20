using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.ParametersCommon
{
    /// <summary>
    /// Interface containing page parameters.
    /// </summary>
    public interface IPageParameters
    {
        /// <summary>
        /// Current page.
        /// </summary>
        int? Page { get; set; }

        /// <summary>
        /// Ammount of models per page.
        /// </summary>
        int PageSize { get; set; }
    }
}
