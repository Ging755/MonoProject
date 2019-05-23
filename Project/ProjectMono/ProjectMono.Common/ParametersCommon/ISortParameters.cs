using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.ParametersCommon
{
    //Interface for sort parameters
    public interface ISortParameters
    {
        //Sort parameter
        string Sort { get; set; }
        //Sort Direction it can be ascending and descending
        string SortDirection { get; set; }
    }
}
