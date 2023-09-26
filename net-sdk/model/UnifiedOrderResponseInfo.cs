using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_sdk.model
{
    /// <summary>
    /// 返回参数
    /// </summary>
    public class UnifiedOrderResponseInfo
    {
        /// <summary>
        /// 0-处理成功，其他-处理有误，详见错误码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 具体错误原因，例如：签名失败、参数格式校验错误
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 对data内数据签名,如data为空则不返回
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// 返回下单数据,json格式数据
        /// </summary>
        public string sign { get; set; }
    }
}
