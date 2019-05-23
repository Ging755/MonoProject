using ProjectMono.Common.ParametersCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.Parameters
{
    //Class containing page parameters
    public class PageParameters : IPageParameters
    {
        //Current Page
        public int? Page { get; set; }
        //Ammount of Models per a page
        public int PageSize { get; set; }
    }
}
