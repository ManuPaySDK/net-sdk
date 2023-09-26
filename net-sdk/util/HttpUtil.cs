using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace net_sdk.util
{
    public class HttpUtil
    {
        private static HttpClient httpClient;
        private static HttpUtil httpUtil;

        public static HttpUtil getInstance()
        {
            if (httpUtil == null)
            {
                httpUtil = new HttpUtil();
            }
            return httpUtil;
        }

        public HttpUtil()
        {
            //ClientConnectionManager connManager = new PoolingClientConnectionManager();
            //httpClient = HttpClients.createDefault();
        }

        public static string post(string url, string data)        {
            
            String result = string.Empty;
            try
            {
                HttpWebRequest webReqeust = (HttpWebRequest)WebRequest.Create(url);
                //webReqeust.UserAgent = this.UserAgent;
                webReqeust.ContentType = "application/json;charset=UTF-8";
                webReqeust.Method = "POST";

                var bs = Encoding.GetEncoding("utf-8").GetBytes(data);
                webReqeust.ContentLength = bs.Length;
                using (Stream reqStream = webReqeust.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                }
                using (HttpWebResponse response = (HttpWebResponse)(webReqeust.GetResponse()))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var responseStream = response.GetResponseStream();
                        using (StreamReader sr = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")))
                        {
                            result = sr.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
          
            return result;
        }
    }
}
