using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common
{
    public class PagingInfo
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class PagingData<T> where T : class
    {
        public int PageNumber { get; set; }
        public int TotalPage { get; set; }
        public int TotalRecord { get; set; }
        public T Data { get; set; }

        public static PagingData<T> Create(T data, int pageNumber, int totalPage, int totalRecord)
        {
            return new PagingData<T>
            {
                Data = data,
                PageNumber = pageNumber,
                TotalPage = totalPage,
                TotalRecord = totalRecord
            };
        }
    }
}