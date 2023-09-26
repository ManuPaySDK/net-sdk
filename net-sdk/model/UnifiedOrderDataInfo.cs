using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_sdk.model
{
    /// <summary>
    /// 返回下单数据,json格式数据
    /// </summary>
    public class UnifiedOrderDataInfo
    {
        /// <summary>
        /// 返回支付系统订单号
        /// </summary>
        public string? payOrderId { get; set; }
        /// <summary>
        /// 返回商户传入的订单号
        /// </summary>
        public string? mchOrderNo { get; set; }
        /// <summary>
        /// 支付订单状态:0-订单生成1-支付中2-支付成功3-支付失败4-已撤销5-已退款6-订单关闭
        /// </summary>
        public int orderState { get; set; }
        /// <summary>
        /// 支付参数类型json-JSON格式字符串payUrl-跳转链接的方式form-表单方式codeUrl-二维码地址codeImgUrl-二维码图片地址none-空支付参数
        /// </summary>
        public string? payDataType { get; set; }
        /// <summary>
        /// 发起支付用到的支付参数
        /// </summary>
        public string? payData { get; set; }
        /// <summary>
        /// 上游渠道返回的错误码
        /// </summary>
        public string? errCode { get; set; }
        /// <summary>
        /// 上游渠道返回的错误描述
        /// </summary>
        public string? errMsg { get; set; }
    }
}
