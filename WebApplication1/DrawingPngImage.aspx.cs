using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class DrawingPngImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Drawing();
        }

        public void Drawing()
        {
            Bitmap gx = new Bitmap(600, 450, System.Drawing.Imaging.PixelFormat.Format32bppArgb);//设置图片长宽

            Graphics gd = Graphics.FromImage(gx);
            StringFormat sf = new StringFormat();
            gd.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            //设置高质量,低速度呈现平滑程度
            gd.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            gd.Clear(Color.Transparent);
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Far;
            gd.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias; //消除毛边

            Pen pen1 = new Pen(Color.Red,2);//初始化画笔，红色，2像素宽
            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;//画笔样式为虚线
            
            gd.DrawRectangle(pen1, 10, 20, 580, 410);//绘制矩形，DrawRectangle(Pen p1, int x,int y,int width,int height);X,Y为左上角坐标

            MemoryStream ms = new MemoryStream();
            gx.Save(ms, ImageFormat.Png);
            Response.ContentType = "image/png";
            Response.BinaryWrite(ms.ToArray());//以二进制字符串写入http输出流
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);//二进制字符串转化成图片
            image.Save(Server.MapPath("./Upload/DrawingPngImage/test.png")); //保存图片
        }

    }
} 



//gd.DrawString("你好",new Font("Arial", 16), new SolidBrush(Color.FromArgb(115, 105, 100)), 0, 0);
//gd.DrawLine(pen1, 10, 20, 590, 20);//顶部线条，在两个坐标点直接画线，X1,Y1,X2,Y2
//gd.DrawLine(pen1, 10, 20, 10, 430);//左侧线条，在两个坐标点直接画线，X1,Y1,X2,Y2
//gd.DrawLine(pen1, 10, 430, 590, 430);//底部线条，在两个坐标点直接画线，X1,Y1,X2,Y2
//gd.DrawLine(pen1, 590, 430, 590, 20);//右侧线条，在两个坐标点直接画线，X1,Y1,X2,Y2

//pen1.DashPattern = new float[] { 1, 1 };//数组中的元素设置短划线图案中每个短划线和空白区域的长度。第一个元素设置短划线的长度，第二个元素设置空白区域的长度，第三个元素设置短划线的长度，依此类推。