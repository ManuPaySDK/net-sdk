using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_sdk.model
{
    public class UnifiedOrderRequestInfo : CommonRequestInfo
    {
        /// <summary>
        /// 商户生成的订单号
        /// </summary>
        public string mchOrderNo { get; set; }
        /// <summary>
        /// 支付方式,测试账号默认SAIL_CASHIER , 巴西SAIL_CASHIER_BRL, 印度SAIL_CASHIER_INR, 具体描述见下方详情
        /// </summary>
        public string wayCode { get; set; }
        /// <summary>
        /// 支付金额,单位分
        /// </summary>
        public int amount { get; set; }
        /// <summary>
        /// 三位货币代码,印度卢比:inr
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string subject { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 支付结果异步回调URL,只有传了该值才会发起回调
        /// </summary>
        public string notifyUrl { get; set; }
        /// <summary>
        /// 支付结果同步跳转通知URL
        /// </summary>
        public string returnUrl { get; set; }
        /// <summary>
        /// 商户扩展参数json格式字符串 可以有country等参数字段 ,回调时会原样返回
        /// </summary>
        public string extParam { get; set; }
        /// <summary>
        /// 订单失效时间,单位秒,默认2小时.订单在(创建时间+失效时间)后失效
        /// </summary>
        public int expiredTime { get; set; }
        /// <summary>
        /// 客户端IPV4地址
        /// </summary>
        public string clientIp { get; set; }
    }
}
