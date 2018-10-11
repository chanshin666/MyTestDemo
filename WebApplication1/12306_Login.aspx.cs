using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _12306_Login : System.Web.UI.Page
    {
        CookieContainer cookie;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Action = Request.QueryString["action"] == "" ? "" : Request.QueryString["action"];
                if (Action != "")
                {
                    switch (Action)
                    {
                        case "GetValidateImg":
                            GetValidateImg();
                            break;
                    }
                }
            }
        }

        public void GetValidateImg()
        {
            #region 获取登录验证码
            string url = "https://kyfw.12306.cn/passport/captcha/captcha-image?login_site=E&module=login&rand=sjrand";

            WebRequest webreq = WebRequest.Create(url);
            WebResponse webres = webreq.GetResponse();

            Stream stream = webres.GetResponseStream();
            if (stream != null)
            {
                List<byte> bytes = new List<byte>();
                int i = stream.ReadByte();
                while (i != -1)
                {
                    bytes.Add((byte)i);
                    i = stream.ReadByte();
                }

                Response.Clear();
                Response.ContentType = "image/jpeg";
                Response.BinaryWrite(bytes.ToArray());
                Response.End();

            }
            #endregion
        }

        /// <summary>
        /// 登陆需要post参数（username，password，appid）
        /// </summary>
        /// <param name="context"></param>
        void Login(HttpContext context)
        {
            #region 登录
            string username = "";
            if (!string.IsNullOrEmpty(context.Request["username"]))
                username = context.Request["username"];

            string password = "";
            if (!string.IsNullOrEmpty(context.Request["password"]))
                password = context.Request["password"];

            string url = "https://kyfw.12306.cn/passport/web/login";
            string result = GetValidhtmlByPost(url, "username=" + username + "&password=" + password + "&appid=otn");

            context.Response.Write(result);
            context.Response.End();
            #endregion
        }

        //回调验证证书问题
        private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            // 总是接受    
            return true;
        }
        /// <summary>
        /// get请求（有证书验证）
        /// </summary>
        /// <param name="Url">URL</param>
        /// <returns></returns>
        private string GetValidhtmlByGet(string Url)
        {
            HttpWebRequest webRequest;
            HttpWebResponse webResponse;
            try
            {
                //这一句一定要写在创建连接的前面。使用回调的方法进行证书验证。
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                ServicePointManager.CheckCertificateRevocationList = true;

                webRequest = (HttpWebRequest)WebRequest.Create(Url);
                webRequest.Method = "GET";
                webRequest.Accept = "*/*";

                // 获取对应HTTP请求的响应
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                // 获取响应流
                Stream responseStream = webResponse.GetResponseStream();
                // 对接响应流(以"utf-8"字符集)
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string result = reader.ReadToEnd();
                reader.Close();
                return result;

            }
            catch (Exception ex)
            {
                return "";
            }


        }

        /// <summary>
        /// 获取文件流
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        private Stream GetStreamByGet(string Url)
        {
            HttpWebRequest webRequest;
            HttpWebResponse webResponse;
            cookie = new CookieContainer();
            try
            {
                //这一句一定要写在创建连接的前面。使用回调的方法进行证书验证。
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                ServicePointManager.CheckCertificateRevocationList = true;

                webRequest = (HttpWebRequest)WebRequest.Create(Url);
                webRequest.Method = "GET";
                webRequest.Accept = "*/*";
                webRequest.CookieContainer = cookie;
                // 获取对应HTTP请求的响应
                webResponse = (HttpWebResponse)webRequest.GetResponse();

                // 获取响应流
                Stream responseStream = webResponse.GetResponseStream();
                return responseStream;


            }
            catch (Exception ex)
            {
                return null;
            }


        }

        ///<summary>
        ///post请求（有证书验证）
        ///</summary>
        ///<param name="URL">url地址</param>
        ///<param name="strPostdata">发送的数据</param>
        ///<returns></returns>
        public string GetValidhtmlByPost(string url, string strPostData)
        {
            HttpWebRequest webRequest;
            HttpWebResponse webResponse;
            try
            {
                // 这一句一定要写在创建连接的前面。使用回调的方法进行证书验证。
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                ServicePointManager.CheckCertificateRevocationList = true;

                webRequest = (HttpWebRequest)HttpWebRequest.Create(url);

                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.KeepAlive = true;
                webRequest.CookieContainer = cookie;


                byte[] buffer = Encoding.UTF8.GetBytes(strPostData);
                webRequest.ContentLength = buffer.Length;
                webRequest.GetRequestStream().Write(buffer, 0, buffer.Length);

                webResponse = (HttpWebResponse)webRequest.GetResponse();
                StreamReader reader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
                string result = reader.ReadToEnd();
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}