using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Helpers
{
    public class ResultModel
    {
        /// <summary>
        /// 状态码 (200 成功 404 没找到 500 失败)
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public List<ErrorMessage> ErrorMessages { get; set; }
    }

    public class ErrorMessage
    {
        /// <summary>
        /// 错误属性
        /// </summary>
        public string ErrorName { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorInfo { get; set; }
    }
}
