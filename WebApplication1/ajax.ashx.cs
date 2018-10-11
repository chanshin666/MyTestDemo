using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplication1
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    public class ajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            string Action = context.Request.QueryString["action"] == "" ? "" : context.Request.QueryString["action"];
            if (Action != "")
            {
                switch (Action)
                {
                    case "GetValidateImg":
                        GetValidateImg(context);
                        break;
                }
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void GetValidateImg(HttpContext context)
        {
            #region 获取登录验证码
            string url = "https://kyfw.12306.cn/passport/captcha/captcha-image?login_site=E&module=login&rand=sjrand";
            //string url = "https://kyfw.12306.cn/otn/passcodeNew/getPassCodeNew?module=login&rand=sjrand&rand=sjrand";

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

                context.Response.Clear();
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(bytes.ToArray());
            }
            #endregion
        }

    }
}