using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.SingalIRTest
{
    [HubName("OrderHub")]
    public class OrderHub:Hub
    {
        public static OrderHub Instance = new OrderHub();
        public IHubContext hub = GlobalHost.ConnectionManager.GetHubContext<OrderHub>();

        public void Init()
        {

        }

        public void Send(string message)
        {
            hub.Clients.All.recieveOrder(message);// 客户端通过调用recieveOrder来获取数据
        }
    }
}