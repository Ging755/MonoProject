using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.PagedResultCommon
{
    public interface IPagedResult<T> where T : class
    {
            /// <summary>
            /// The page number this page represents. 
            /// </summary>
            int PageNumber { get; set; }

            /// <summary> 
            /// The size of this page. 
            /// </summary> 
            int PageSize { get; set; }

            /// <summary> 
            /// The total number of pages available. 
            /// </summary> 
            int TotalNumberOfPages { get; set; }

            /// <summary> 
            /// The total number of records available. 
            /// </summary> 
            int TotalNumberOfRecords { get; set; }

            /// <summary> 
            /// The URL to the next page - if null, there are no more pages. 
            /// </summary> 
            string NextPageUrl { get; set; }

            /// <summary> 
            /// The records this page represents. 
            /// </summary> 
            IEnumerable<T> Results { get; set; }
    }
}
