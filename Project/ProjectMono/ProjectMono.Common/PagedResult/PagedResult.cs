using ProjectMono.Common.PagedResultCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common.PagedResult
{
    public class PagedResult<T> : IPagedResult<T> where T : class
    {
        /// <summary>
        /// The page number this page represents. 
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary> 
        /// The size of this page. 
        /// </summary> 
        public int PageSize { get; set; }
        /// <summary> 
        /// The total number of pages available. 
        /// </summary> 
        public int TotalNumberOfPages { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}
