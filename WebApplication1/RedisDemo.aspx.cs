using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Utility;

namespace WebApplication1
{
    public partial class RedisDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void Init()
        {
            string UserName;

            UserName = RedisUtils.Item_Get<string>("UserInfo_123");

            //读取数据，如果缓存存在直接从缓存中读取，否则从数据库读取然后写入redis
            if (string.IsNullOrEmpty(UserName)) //初始化缓存
            {
                //TODO 从数据库中获取数据，并写入缓存
                UserName = "张三";
                RedisUtils.Item_Set<string>("UserInfo_123", UserName);
                Label1.Text = "数据库数据：" + "张三";
                return;
            }
            Label1.Text = "Redis缓存数据：" + UserName;
            
        }

        protected void btnGetRedisData_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}