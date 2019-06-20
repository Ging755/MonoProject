using ProjectMono.Common.ParametersCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.Parameters
{
    /// <summary>
    /// Class containing page parameters.
    /// </summary>
    public class PageParameters : IPageParameters
    {
        /// <summary>
        /// Current page.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Ammount of models per page.
        /// </summary>
        public int PageSize { get; set; }
    }
}
