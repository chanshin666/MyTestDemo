﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class example2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(GetMD5("bomen" + GetMD5("gqd1xp9h")));
            Response.Write(Parsejson());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string a = "200.0";
            decimal b = Convert.ToDecimal(a);
            Response.Write(b.ToString());
        }

        public string Parsejson()
        {
            string str = "name=132&code=100";
            string newstr = str.Replace("=", "\":\"");
            string stringObj = "{\"" + newstr.Replace("&", "\",\"") + "\"}";
            return stringObj;
        }

        public string Parsejson2()
        {
            string str = "name=132&code=100";
            string newstr = str.Replace("=", ":\"");
            string stringObj = "{" + newstr.Replace("&", "\",") + "\"}";
            return stringObj;
        }
        /*
      * 方法名称：GetMD5
      * 功    能：字符串MD5加密
      * 参    数：待转换字符串
      * 返 回 值：加密之后字符串
      */
        static string GetMD5(string sourceStr)
        {
            string resultStr = "";

            byte[] b = System.Text.Encoding.Default.GetBytes(sourceStr);
            b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
            for (int i = 0; i < b.Length; i++)
                resultStr += b[i].ToString("x").PadLeft(2, '0');

            return resultStr;
        }
    }
}