using ProjectMono.Common.ParametersCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.Parameters
{
    public class PageParameters : IPageParameters
    {
        public int? Page { get; set; }
        public int PageSize { get; set; }
    }
}
