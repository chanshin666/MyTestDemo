using Kingdee.BOS.WebApi.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTest
{
    class Program
    {
        static void Main(string[] args)
        {
            K3CloudApiClient client = new K3CloudApiClient("http://218.90.239.228:9000/k3cloud/");
            string ret = client.ValidateLogin("5a52e5b35fcac8", "Administrator", "888888", 2052);
            Console.WriteLine(ret+"\n");
            var result = JObject.Parse(ret)["LoginResultType"].Value<int>();
            Console.WriteLine("结果为："+result);
            Console.ReadKey();
        }
    }
}
