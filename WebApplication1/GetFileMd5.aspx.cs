using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class GetFileMd5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        static string GetMD5(string FilePath)
        {
            string FileMD5 = "";
            try
            {
                FileStream file = new FileStream(FilePath, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retval = md5.ComputeHash(file);
                file.Close();

                StringBuilder sc = new StringBuilder();
                for (int i = 0; i < retval.Length; i++)
                {
                    sc.Append(retval[i].ToString("x2"));
                }
                FileMD5="文件MD5："+sc;
            }
            catch (Exception ex)
            {
               FileMD5=ex.Message;
            }
            return FileMD5;
        }

        protected void btnGetMD5_Click(object sender, EventArgs e)
        {
            string Result = GetMD5(Server.MapPath("DownLoad/xpshop_test_data_1809081024.zip"));
            Response.Write(Result);
        }
    }
}