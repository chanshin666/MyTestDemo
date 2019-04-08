using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class NLogTest : System.Web.UI.Page
    {
        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnWriteLog_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("=========================================================\r\n");
            sb.Append(string.Format("订单{0}付款成功，开始检查拼团状态\r\n", "20190408170122888"));
            sb.Append("=========================================================\r\n");
            logger.Debug(sb.ToString());
            Response.Write("写入日志成功");
        }
    }
}