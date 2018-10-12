using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplication1.Utility
{
    public class WebHelper
    {
        /// <summary>
        /// 获取HTML页面的元素值
        /// </summary>
        /// <param name="url"></param>
        /// <param name="elementName"></param>
        /// <param name="subElement"></param>
        /// <returns></returns>
        public static List<string> GetElementContent(string url, string elementName, string subElement)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            string content = reader.ReadToEnd();
            reader.Close();
            responseStream.Close();

            StringBuilder regexStr = new StringBuilder("(?is)<");
            regexStr.Append(elementName).Append("[^>]*?").Append(subElement).Append(@"=(['""\s]?)([^'""\s]+)\1[^>]*?>");
            Regex regex = new Regex(regexStr.ToString());
            MatchCollection match = regex.Matches(content);
            List<string> values = new List<string>();
            foreach (Match m in match)
            {
                values.Add(m.Groups[2].Value);
            }
            return values;
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="element"></param>
        /// <param name="content"></param>
        /// <param name="dictionary"></param>
        public static void SetParams(string element, string content, Dictionary<string, string> dictionary)
        {
            for (int i = 0, len = dictionary.Keys.Count(); i < len; i++)
            {
                string key = dictionary.Keys.ElementAtOrDefault(i);
                if (key == element)
                {
                    dictionary[key] = content;
                }
            }
        }

        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="formParams"></param>
        public static void UrlEncodeParams(Dictionary<string, string> formParams)
        {
            for (int i = 0, len = formParams.Keys.Count(); i < len; i++)
            {
                string key = formParams.Keys.ElementAtOrDefault(i);
                formParams[key] = HttpUtility.UrlEncode(formParams[key], Encoding.GetEncoding("GBK"));
            }
        }

        public static string GetCookieValue(string cookie)
        {
            Regex regex = new Regex("=.*?;");
            Match value = regex.Match(cookie);
            string cookieValue = value.Groups[0].Value;
            return cookieValue.Substring(1, cookieValue.Length - 2);
        }

        public static string GetCookieName(string cookie)
        {
            Regex regex = new Regex("sulcmiswebpac.*?");
            Match value = regex.Match(cookie);
            return value.Groups[0].Value;
        }

        public static string GetHtml(string url,string name, string value)
        {
            CookieCollection cookies = new CookieCollection();
            cookies.Add(new Cookie(name, value));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("Cookie", name + "=" + value);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            return reader.ReadToEnd();
        }
    }
}