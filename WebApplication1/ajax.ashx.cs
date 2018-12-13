using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    public class ajax : IHttpHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger(); //初始化日志类
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
                    case "ASyncInvoke":
                        ASyncInvoke();
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
                //context.Response.End();
            }
            #endregion
        }

        private void ASyncInvoke()
        {

            //TaskFactory task = Task.Factory;
            //List<Task> TaskList = new List<Task>();
            //for (int i = 0; i < 3; i++)
            //{
            //    TaskList.Add(task.StartNew(() => this.Execut(i, "sfndlasgnfdklsgjmds", "1.jpg")));
            //}
            //task.ContinueWhenAny(TaskList.ToArray(), (t) => { logger.Trace("付款通知短信有完成的了"); });

            for (int i = 0; i < 3; i++)
            {
                if (i == 2)
                {
                    Action<int, string, string> action = Execut;
                    IAsyncResult iResult = action.BeginInvoke(i, "sfndlasgnfdklsgjmds", "1.jpg", (callback) => { logger.Trace("上传完成了"); action.EndInvoke(callback); }, null);
                }
            }
            

            HttpContext.Current.Response.Write("{\"Msg\":\"" + DateTime.Now.ToString() + " 按钮已经执行完毕\"}");
            HttpContext.Current.Response.End();
        }

        private void Execut(int MemberID, string OpenID, string ImgName)
        {
            logger.Trace("获取到参数：MemberID=" + MemberID + ",OpenID=" + OpenID + ",ImgName=" + ImgName + "");
            logger.Trace("【" + MemberID + "】开始执行异步啊");
            for (int i = 0; i < 10; i++)
            {
                logger.Trace("【" + MemberID + "】异步已经完成：" + (i + 1) * 10 + "%");
                Thread.Sleep(1000);
            }
            logger.Trace("【" + MemberID + "】异步完成了");
        }

    }
}