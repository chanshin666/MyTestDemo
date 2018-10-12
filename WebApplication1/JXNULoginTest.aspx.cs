using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Utility;

namespace WebApplication1
{
    public partial class JXNULoginTest : System.Web.UI.Page
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoginTest_Click(object sender, EventArgs e)
        {
            //Post1();
            Post2();
        }

        protected void btnGetElement_Click(object sender, EventArgs e)
        {
            string cookie = "JwOAUserSettingNew=UserNum=BWYTz51j93foAz5jZ+eXiA==&UserName=2+CmV3GbDgg=&UserType=WmTb330+jk8=&UserLoginTime=2018/10/12 13:05:00; expires=Mon, 15-Oct-2018 05:05:00 GMT; path=/";
            Regex regexValue = new Regex("=.*?;");
            Match valueVallue = regexValue.Match(cookie);
            string cookieValue = valueVallue.Groups[0].Value;
            Response.Write("Value:"+cookieValue.Substring(1, cookieValue.Length - 2)+"<br />") ;

        
            Regex regexName = new Regex("sulcmiswebpac.*?");
            Match valueName = regexName.Match(cookie);
            Response.Write("Name:" + valueName.Groups[0].Value + "<br />");
        }

        #region Post1
        public void Post1()
        {
            string strViewState = System.Web.HttpUtility.UrlEncode("/wEPDwULLTEzNjU2NTUyNDYPZBYCZg9kFgICAw9kFgZmDxYCHgRUZXh0BSEyMDE45bm0MTDmnIgxMuaXpSDmmJ/mnJ/kupQmbmJzcDtkAgIPZBYCAgEPFgIfAAUS6LSm5Y+35a+G56CB55m75b2VZAIDD2QWBAIBDw8WAh4HVmlzaWJsZWdkFgYCAQ8QZGQWAWZkAgMPZBYCAgEPFgIfAAUG5a2m5Y+3ZAIFDw8WAh8BaGQWAgIBDxAPFgYeDURhdGFUZXh0RmllbGQFDOWNleS9jeWQjeensB4ORGF0YVZhbHVlRmllbGQFCeWNleS9jeWPtx4LXyFEYXRhQm91bmRnZBAVGxLotKLmlL/ph5Hono3lrabpmaIS5Z+O5biC5bu66K6+5a2m6ZmiEuWIneetieaVmeiCsuWtpumZohXlnLDnkIbkuI7njq/looPlrabpmaIS5Zu96ZmF5pWZ6IKy5a2m6ZmiEuWMluWtpuWMluW3peWtpumZohvorqHnrpfmnLrkv6Hmga/lt6XnqIvlrabpmaIS57un57ut5pWZ6IKy5a2m6ZmiDOaVmeiCsuWtpumZoh7lhpvkuovmlZnnoJTpg6jvvIjmraboo4Xpg6jvvIkS56eR5a2m5oqA5pyv5a2m6ZmiG+WOhuWPsuaWh+WMluS4juaXhea4uOWtpumZohXpqazlhYvmgJ3kuLvkuYnlrabpmaIM576O5pyv5a2m6ZmiEuWFjei0ueW4iOiMg+eUn+mZogzova/ku7blrabpmaIJ5ZWG5a2m6ZmiEueUn+WRveenkeWtpuWtpumZohvmlbDlrabkuI7kv6Hmga/np5HlrablrabpmaIM5L2T6IKy5a2m6ZmiD+WkluWbveivreWtpumZognmloflrabpmaIb54mp55CG5LiO6YCa5L+h55S15a2Q5a2m6ZmiDOW/g+eQhuWtpumZohXmlrDpl7vkuI7kvKDmkq3lrabpmaIM6Z+z5LmQ5a2m6ZmiDOaUv+azleWtpumZohUbCDY4MDAwICAgCDYzMDAwICAgCDgyMDAwICAgCDQ4MDAwICAgCDY5MDAwICAgCDYxMDAwICAgCDYyMDAwICAgCDQ1MCAgICAgCDUwMDAwICAgCDM3MDAwICAgCDgxMDAwICAgCDU4MDAwICAgCDQ2MDAwICAgCDY1MDAwICAgCDU3MDAwICAgCDY3MDAwICAgCDU0MDAwICAgCDY2MDAwICAgCDU1MDAwICAgCDU2MDAwICAgCDUyMDAwICAgCDUxMDAwICAgCDYwMDAwICAgCDQ5MDAwICAgCDY0MDAwICAgCDUzMDAwICAgCDU5MDAwICAgFCsDG2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZxYBZmQCAw8PFgIfAWhkZGQNGXsTwHRh+AT0FOIiSk9lRbUAOFzMNjDj6nkQZ1RrXA==");
            string strEventValidation = System.Web.HttpUtility.UrlEncode("/wEWCQL+taCgBgKFsp/HCgL+44ewDwKiwZ6GAgKWuv6KDwLj3Z22BgL6up5fAv/WopgDAuvMx/YGn+ZN1cwkYApKzIvd/S5xDxwzJEjvktYpTj9zR/tOf/o=");

            string ddlUserType = System.Web.HttpUtility.UrlEncode("_ctl0:cphContent:ddlUserType");
            string txtUserNum = System.Web.HttpUtility.UrlEncode("_ctl0:cphContent:txtUserNum");
            string txtPassword = System.Web.HttpUtility.UrlEncode("_ctl0:cphContent:txtPassword");
            string btnLogin = System.Web.HttpUtility.UrlEncode("_ctl0:cphContent:btnLogin");

            StringBuilder url = new StringBuilder();
            url.Append("__VIEWSTATE=" + strViewState);
            url.Append("&__EVENTVALIDATION=" + strEventValidation);
            url.Append("&" + ddlUserType + "=Student");
            url.Append("&" + txtUserNum + "=1467004007");
            url.Append("&" + txtPassword + "=cx763225207");
            url.Append("&" + btnLogin + "=%E7%99%BB%E5%BD%95");

            Response.Write("url:" + url.ToString() + "<br />");

            byte[] data = System.Text.Encoding.UTF8.GetBytes(url.ToString());

            Uri uri = new Uri("http://jwc.jxnu.edu.cn/Portal/LoginAccount.aspx?t=account");
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
            request.Method = "post";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            request.Accept = " text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko/20100101 Firefox/22.0";
            request.AllowAutoRedirect = true;
            request.KeepAlive = true;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, System.Text.Encoding.UTF8);
            string retext = readStream.ReadToEnd().ToString();
            readStream.Close();

            Response.Write("Result: " + retext);
        }
        #endregion

        #region Post2
        public void Post2()
        {
            string url = "http://jwc.jxnu.edu.cn/Portal/LoginAccount.aspx?t=account";

            //得到表单中所有要提交的元素的name和value。
            List<string> values = WebHelper.GetElementContent(url, "input", "value");
            List<string> names = WebHelper.GetElementContent(url, "input", "name");

            //自动填充表单
            Dictionary<string, string> postPair = new Dictionary<string, string>();
            for (int i = 0, len = names.Count(); i < len; i++)
            {
                postPair.Add(names.ElementAtOrDefault(i), values.ElementAtOrDefault(i));
            }

            //利用一个字典，将对应的name和value放进去。当然，要想登录，我们还是得需要用户名和密码：
            WebHelper.SetParams("_ctl0:cphContent:ddlUserType", "Student", postPair);
            WebHelper.SetParams("_ctl0:cphContent:txtUserNum", "1467004007", postPair);
            WebHelper.SetParams("_ctl0:cphContent:txtPassword", "cx763225207", postPair);
            WebHelper.SetParams("_ctl0:cphContent:btnLogin", "登录", postPair);

            WebHelper.UrlEncodeParams(postPair);

            CookieContainer cookies = new CookieContainer();
            string postStr = "";
            foreach (string key in postPair.Keys)
            {
                postStr += key + "=" + postPair[key] + "&";
            }
            byte[] postData = Encoding.ASCII.GetBytes(postStr.Substring(0, postStr.Length - 1));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.AllowAutoRedirect = false;
            request.ContentType = "application/x-www-form-urlencoded;charset=gbk";
            request.CookieContainer = new CookieContainer();
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.95 Safari/537.11";
            request.ContentLength = postData.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postData, 0, postData.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            string cookie = response.Headers.Get("Set-Cookie");
            string resultPage = reader.ReadToEnd();

            //cookie = System.Web.HttpUtility.UrlEncode(cookie);

            //Response.Write("登录测试HTML结果：<br />" + resultPage+"<br /> Cookie="+cookie);

            string LoginResult = "失败";
            if (resultPage.Contains("Object moved to"))
            {
                LoginResult = "成功";
            }

            logger.Debug("【江西师范大学教务在线模拟登录】登录测试HTML结果： 登录" + LoginResult+"\r\n Html内容为：" + resultPage + "\r\n Cookie=" + cookie);

            Response.Write("【江西师范大学教务在线模拟登录】登录测试HTML结果：登录" + LoginResult + "<br /> Html内容为：" + resultPage + "<br /> Cookie=" + cookie);

            //带着返回的Cookie跳转新页面
            //string html = WebHelper.GetHtml("http://jwc.jxnu.edu.cn/Portal/index.aspx",WebHelper.GetCookieName(cookie), WebHelper.GetCookieValue(cookie));

            string html = WebHelper.GetHtml("http://jwc.jxnu.edu.cn/Portal/index.aspx", "JwOAUserSettingNew", WebHelper.GetCookieValue(cookie));
            reader.Close();
            responseStream.Close();
            Response.Write(html);

        }
        #endregion
    }
}