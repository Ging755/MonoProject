using ProjectMono.Common.ParametersCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.Parameters
{
    //Class cotaining sort parameters
    public class SortParameters : ISortParameters
    {
        //Sort parameter
        public string Sort { get; set; }
        //Sort Direction it can be ascending and descending
        public string SortDirection { get; set; }
    }
}
