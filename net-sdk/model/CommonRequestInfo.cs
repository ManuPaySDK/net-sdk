using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_sdk.model
{
    public class CommonRequestInfo
    {
        public string mchNo { get; set; }
        /// <summary>
        /// 请求接口时间,13位时间戳
        /// </summary>
        public long reqTime { get; set; }
        /// <summary>
        /// 签名值，详见签名算法
        /// </summary>
        public string sign { get; set; }
    }
}
