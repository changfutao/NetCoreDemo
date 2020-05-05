using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Entities
{
    public class Parameters
    {
        public const int MaxPageSize = 50;
        private int _pageSize = 10;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }

        public virtual string SortBy { get; set; } = "Name";
    }
}
