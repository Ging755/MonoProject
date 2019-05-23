using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.ParametersCommon
{
    //Interface for filter parameters
    public interface IFilterParameters
    {
        //Search parameter
        string Search { get; set; }
    }
}
