using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XpShop.Common;

namespace WebApplication1
{
    public partial class BeginInvoke : System.Web.UI.Page
    {
        private static Logger logger = LogManager.GetCurrentClassLogger(); //初始化日志类
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Action = Utils.ReqStrParams("action","");
                if (Action != "")
                {
                    switch (Action)
                    {
                        case "ASyncInvoke":
                            ASyncInvoke();
                            break;
                    }
                }
            }
        }

        protected void btnSyncBeginInvoke_Click(object sender, EventArgs e)
        {
            Response.Write(DateTime.Now.ToString()+ " 按钮事件触发<br />");

            Action<int, string, string> action = Execut;
            IAsyncResult iResult = action.BeginInvoke(100, "sfndlasgnfdklsgjmds", "1.jpg", (callback) => { logger.Trace("上传完成了"); action.EndInvoke(callback); }, null);

            Response.Write(DateTime.Now.ToString() + " 按钮事件结束<br />");
        }

        private void ASyncInvoke()
        {

            Action<int, string, string> action = Execut;
            IAsyncResult iResult = action.BeginInvoke(100, "sfndlasgnfdklsgjmds", "1.jpg", (callback) => { logger.Trace("上传完成了"); action.EndInvoke(callback); }, null);

            Response.Write("{\"Msg\":\"" + DateTime.Now.ToString() + " 按钮已经执行完毕\"}");
            Response.End();
        }

        private void Execut(int MemberID, string OpenID, string ImgName)
        {
            logger.Trace("获取到参数：MemberID=" + MemberID + ",OpenID=" + OpenID + ",ImgName=" + ImgName + "");
            logger.Trace("开始执行异步啊");
            for (int i = 0; i < 10; i++)
            {
                logger.Trace("异步已经完成：" + (i + 1) * 10 + "%");
                Thread.Sleep(1000);
            }
            logger.Trace("异步完成了");
        }

    }
}