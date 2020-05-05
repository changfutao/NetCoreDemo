using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Helpers
{
    public class PagedList<T>:List<T>
    {
        public PagedList(List<T> items,int totalCount,int pageNumber,int pageSize)
        {
            TotalCount = totalCount;
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            AddRange(items);
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; private set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; private set; }
        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; private set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount { get; private set; }
    }
}
