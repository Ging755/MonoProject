using ProjectMono.Common.PagedResultCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.PagedResult
{
    /// <summary>
    /// Class containing PagedResult.
    /// </summary>
    /// <typeparam name="T">Type of generic.</typeparam>
    public class PagedResult<T> : IPagedResult<T> where T : class
    {
        /// <summary>
        /// The page number the page represents. 
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary> 
        /// The size of the page. 
        /// </summary> 
        public int PageSize { get; set; }

        /// <summary> 
        /// The total number of pages available. 
        /// </summary> 
        public int TotalNumberOfPages { get; set; }

        /// <summary> 
        /// The records this page represents. 
        /// </summary> 
        public IEnumerable<T> Results { get; set; }
    }
}
