using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpShop.PingAn;

namespace XpShop.PingAnTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IHttpProvider httpProvider = new HttpProvider();

            // 1. 模拟一个Get请求方式
            //HttpResponseParameter responseParameter1 = httpProvider.Excute(new HttpRequestParameter
            //{
            //    Url = "http://www.baidu.com",
            //    IsPost = false,
            //    Encoding = Encoding.UTF8
            //    //Cookie = new HttpCookieType() 如果需要Cookie
            //});
            //System.Console.WriteLine(responseParameter1.Body);

            // 2. 模拟一个Post请求方式（例：登录)
            //IDictionary<string, string> postData = new Dictionary<string, string>();
            //postData.Add("userName", "登录用户名");
            //postData.Add("userPwd", "用户名密码");
            //HttpResponseParameter responseParameter2 = httpProvider.Excute(new HttpRequestParameter
            //{
            //    Url = "你的登录url",
            //    IsPost = true,
            //    Encoding = Encoding.UTF8,
            //    Parameters = postData
            //});
            //System.Console.WriteLine(responseParameter2.Body);

            // 1. 模拟一个Get请求方式
            //http://lbfjapi.wsdict.com:8000/xpapi.ashx?method=xpshop.trades.sold.get&page_no=1&page_size=100

            //3.模拟一个Get请求方式  带参数
            IDictionary<string, string> postData = new Dictionary<string, string>();
            postData.Add("userName", "登录用户名");
            postData.Add("userPwd", "用户名密码");

            HttpRequestParameter HttpReq =new HttpRequestParameter 
            {
                //Url = "http://www.baidu.com",
                Url = "http://lbfjapi.wsdict.com:8000/xpapi.ashx?method=xpshop.shipping.type.get",
                IsPost = false,
                Encoding = Encoding.UTF8,
                Parameters = postData
                //Cookie = new HttpCookieType() 如果需要Cookie
            };
            System.Console.WriteLine("请求数据为："+HttpReq.ToString());
            HttpResponseParameter responseParameter3 = httpProvider.Excute(HttpReq);
            System.Console.WriteLine(responseParameter3.Body);

            System.Console.ReadLine();
        }
    }
}
