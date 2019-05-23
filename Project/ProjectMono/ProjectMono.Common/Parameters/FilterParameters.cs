using ProjectMono.Common.ParametersCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.Parameters
{
    //Class containing filter parameters
    public class FilterParameters : IFilterParameters
    {
        //Search parameter
        public string Search { get; set; }
    }
}
