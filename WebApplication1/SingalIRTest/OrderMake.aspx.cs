using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Utility;

namespace WebApplication1.SingalIRTest
{
    public partial class OrderMake : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private string GetRamdon()
        {
            RandomHelper raHelper = new RandomHelper();
            int Result = raHelper.GetRandomNumber(10000,99999);
            return Result.ToString();
        }

        protected void btnOrderMake_Click(object sender, EventArgs e)
        {
            string OrderNo = "D888" + DateTime.Now.ToString("yyyyMMdd") + GetRamdon();
            string OrderInfo = "订单号：" + OrderNo + "已生成。<a href='http://etp304.wsdict.com:8000?OrderDetail.aspx?orderid=" + OrderNo + "'>点击查看</a>";

            OrderHub.Instance.Send(OrderInfo);
            Response.Write(OrderInfo);
        }
    }
}