using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            XmlDocument ObjXML = new XmlDocument();//创建XMLDOCUMENT对象

            XmlElement root = ObjXML.CreateElement("root");//创建根节点对象
            ObjXML.AppendChild(root);//插入根节点
            XmlElement user = ObjXML.CreateElement("user");//创建子节点对象
            root.AppendChild(user);//插入子节点

            user.SetAttribute("name", null, "liyan");//设置节点属性
            user.SetAttribute("passwd", null, "123");//设置节点属性
            user.InnerText = "测试一下";

            XmlDeclaration xmldecl;
            xmldecl = ObjXML.CreateXmlDeclaration("1.0", null, null);
            xmldecl.Encoding = "UTF-8";
            ObjXML.InsertBefore(xmldecl, root);
            string myxml = ObjXML.InnerXml.ToString();//插入XML类型头

            ObjXML.Save(Server.MapPath("xml.xml"));

            Response.Write("生成成功");//在页面输出XML文本
        }
    }
}