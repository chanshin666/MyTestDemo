using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Make500Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Action = string.IsNullOrEmpty(Request.QueryString["Action"]) ? "" : Request.QueryString["Action"];
                switch (Action)
                {
                    case "Test":
                        Test();
                        break;

                }
                //FileFolders = GetAllFileFolders();
            }
        }

        protected void btnMake_Click(object sender, EventArgs e)
        {
            Function();
        }

        private void Test()
        {
            Function();
        }

        private void Function()
        {
            string Str = "This Is A Number";

            int Num = int.Parse(Str);
        }
    }
}