using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace net_sdk.util
{
    public class Md5Util
    {
        //    public static String md5(String data) throws Exception
        //    {
        //        MessageDigest md = MessageDigest.getInstance("MD5");
        //    byte[] dataBytes = data.getBytes();
        //    byte[] mdBytes = md.digest(dataBytes);
        //    StringBuilder sb = new StringBuilder();
        //    for (byte b : mdBytes) {
        //        sb.append(String.format("%02x", b & 0xff));
        //    }
        //    return sb.toString();
        //}

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="encypStr"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string md5(string input)
        {
            byte[] buffer = MD5.Create().ComputeHash(Encoding.Default.GetBytes(input));
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                s.Append(buffer[i].ToString("x2"));
            }
            return s.ToString().ToLower();
        }
    }
}
