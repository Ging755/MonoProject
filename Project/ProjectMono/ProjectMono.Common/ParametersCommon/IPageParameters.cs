using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.ParametersCommon
{
    //Interface for page parameters
    public interface IPageParameters
    {
        //Current Page
        int? Page { get; set; }
        //Ammount of Models per a page
        int PageSize { get; set; }
    }
}
