using net_sdk.model;
using net_sdk.util;
using Newtonsoft.Json;
using System.Text;

namespace net_sdk
{
    public class PayClient
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string machNo { get; set; }
        /// <summary>
        /// 私钥
        /// </summary>
        public string privateSecret { get; set; }
        /// <summary>
        /// 请求URL
        /// </summary>
        public string url { get; set; }

        public PayClient(string machNo, string privateSecret, string url)
        {
            this.machNo = machNo;
            this.privateSecret = privateSecret;
            this.url = url;
        }

        public UnifiedOrderResponseInfo PlaceUnifiedOrder(UnifiedOrderRequestInfo requestBean)
        {
            requestBean.mchNo = machNo;
            DateTime now = DateTime.Now;
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long timestamp = (long)(now.ToUniversalTime() - epoch).TotalMilliseconds;
            requestBean.reqTime = timestamp;
            string requeststr = JsonConvert.SerializeObject(requestBean);

            // Dictionary<string, object> CommonPara = new Dictionary<string, object>();
            Dictionary<string, object> CommonPara = JsonConvert.DeserializeObject<Dictionary<string, object>>(requeststr);
            var vDic = CommonPara.OrderBy(x => x.Key, new ComparerString()).ToDictionary(x => x.Key, y => y.Value);

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, object> kv in vDic)
            {
                string pkey = kv.Key;
                object pvalue = kv.Value;
                if (pvalue == null || pvalue.ToString() == null || pvalue.ToString().Length == 0)//参数值为空不参与签名
                    continue;
                sb.Append(pkey + "=" + pvalue + "&");
            }
            sb.Append("key=").Append(privateSecret + "&");
            //TreeMap<String, Object> commoninfomap = JSON.parseObject(commoninfostr, new TypeReference<TreeMap<String, Object>>() { });
            //String requeststr = JSON.toJSONString(requestBean);
            //TreeMap<String, Object> requeststrmap = JSON.parseObject(requeststr, new TypeReference<TreeMap<String, Object>>() { });
            //requeststrmap.putAll(commoninfomap);

            //StringBuilder rawStringBuilder = new StringBuilder();
            //for (Entry<String, Object> entry:requeststrmap.entrySet())
            //{
            //    if (!rawStringBuilder.Length > 0)
            //    {
            //        rawStringBuilder.Append("&");
            //    }
            //    rawStringBuilder.Append(entry.getKey() + "=" + entry.getValue());
            //}
            //rawStringBuilder.Append("&key=").Append(getPrivateSecret());

            try
            {
                string rawstr = sb.ToString().TrimEnd('&');
                string signval = Md5Util.md5(rawstr);
                // System.out.println("rawsignsrc=" + rawstr);
                //  System.out.println("sign=" + signval);
                CommonPara.Remove("sign");
                CommonPara.Add("sign", signval);
            }
            catch (Exception e)
            {
                //  System.out.println("md5sum ex=" + e);
            }
            //  requeststrmap.remove("key");

            string postparam = JsonConvert.SerializeObject(CommonPara);

            string result1 = HttpUtil.post(url, postparam);
            UnifiedOrderResponseInfo unifiedOrderResponseBean = new UnifiedOrderResponseInfo();
            if (result1 == null || result1.Length == 0)
            {
                unifiedOrderResponseBean.msg = "未知错误，返回空";
                return unifiedOrderResponseBean;
            }
            else if (!result1.Contains("code")) {
                unifiedOrderResponseBean.msg = result1;
                return unifiedOrderResponseBean;
            }
            unifiedOrderResponseBean = JsonConvert.DeserializeObject<UnifiedOrderResponseInfo>(result1);

            return unifiedOrderResponseBean;
        }
    }
    public class ComparerString : IComparer<String>
    {
        public int Compare(String x, String y)
        {
            return string.CompareOrdinal(x, y);
        }
    }
}