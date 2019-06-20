using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.PagedResultCommon
{
    /// <summary>
    /// Interface containing PagedResult.
    /// </summary>
    /// <typeparam name="T">Type of generic.</typeparam>
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
        /// The records this page represents. 
        /// </summary> 
        IEnumerable<T> Results { get; set; }
    }
}
