using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class DrawingTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        public void Render(string title, string subTitle, int width, int height, DataSet chartData, Stream target)
        {
            const int SIDE_LENGTH = 400;
            const int PIE_DIAMETER = 200;
            DataTable dt = chartData.Tables[0];

            //通过输入参数，取得饼图中的总基数 
            float sumData = 0;
            foreach (DataRow dr in dt.Rows)
            {
                sumData += Convert.ToSingle(dr[1]);
            }
            //产生一个image对象，并由此产生一个Graphics对象 
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            //设置对象g的属性 
            g.ScaleTransform((Convert.ToSingle(width)) / SIDE_LENGTH, (Convert.ToSingle(height)) / SIDE_LENGTH);
            g.SmoothingMode = SmoothingMode.Default;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            //画布和边的设定 
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Black, 0, 0, SIDE_LENGTH - 1, SIDE_LENGTH - 1);
            //画饼图标题 
            g.DrawString(title, new Font("Tahoma", 24), Brushes.Black, new PointF(5, 5));
            //画饼图的图例 
            g.DrawString(subTitle, new Font("Tahoma", 14), Brushes.Black, new PointF(7, 35));
            //画饼图 
            float curAngle = 0;
            float totalAngle = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                curAngle = Convert.ToSingle(dt.Rows[i][1]) / sumData * 360;

                g.FillPie(new SolidBrush(ChartUtil.GetChartItemColor(i)), 100, 65, PIE_DIAMETER, PIE_DIAMETER, totalAngle, curAngle);
                g.DrawPie(Pens.Black, 100, 65, PIE_DIAMETER, PIE_DIAMETER, totalAngle, curAngle);
                totalAngle += curAngle;
            }
            //画图例框及其文字 
            g.DrawRectangle(Pens.Black, 200, 300, 199, 99);
            g.DrawString("Legend", new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new PointF(200, 300));

            //画图例各项 
            PointF boxOrigin = new PointF(210, 330);
            PointF textOrigin = new PointF(235, 326);
            float percent = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                g.FillRectangle(new SolidBrush(ChartUtil.GetChartItemColor(i)), boxOrigin.X, boxOrigin.Y, 20, 10);
                g.DrawRectangle(Pens.Black, boxOrigin.X, boxOrigin.Y, 20, 10);
                percent = Convert.ToSingle(dt.Rows[i][1]) / sumData * 100;
                g.DrawString(dt.Rows[i][0].ToString() + " - " + dt.Rows[i][1].ToString() + " (" + percent.ToString("0") + "%)", new Font("Tahoma", 10), Brushes.Black, textOrigin);
                boxOrigin.Y += 15;
                textOrigin.Y += 15;
            }
            //通过Response.OutputStream，将图形的内容发送到浏览器 
            bm.Save(target, ImageFormat.Gif);
            //回收资源 
            bm.Dispose();
            g.Dispose();
        }
    }

    //画条形图 
    public class BarChart
    {
        public BarChart()
        {
        }
        public void Render(string title, string subTitle, int width, int height, DataSet chartData, Stream target)
        {
            const int SIDE_LENGTH = 400;
            const int CHART_TOP = 75;
            const int CHART_HEIGHT = 200;
            const int CHART_LEFT = 50;
            const int CHART_WIDTH = 300;
            DataTable dt = chartData.Tables[0];

            //计算最高的点 
            float highPoint = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (highPoint < Convert.ToSingle(dr[1]))
                {
                    highPoint = Convert.ToSingle(dr[1]);
                }
            }
            //建立一个Graphics对象实例 
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            //设置条图图形和文字属性 
            g.ScaleTransform((Convert.ToSingle(width)) / SIDE_LENGTH, (Convert.ToSingle(height)) / SIDE_LENGTH);
            g.SmoothingMode = SmoothingMode.Default;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            //设定画布和边 
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Black, 0, 0, SIDE_LENGTH - 1, SIDE_LENGTH - 1);
            //画大标题 
            g.DrawString(title, new Font("Tahoma", 24), Brushes.Black, new PointF(5, 5));
            //画小标题 
            g.DrawString(subTitle, new Font("Tahoma", 14), Brushes.Black, new PointF(7, 35));
            //画条形图 
            float barWidth = CHART_WIDTH / (dt.Rows.Count * 2);
            PointF barOrigin = new PointF(CHART_LEFT + (barWidth / 2), 0);
            float barHeight = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                barHeight = Convert.ToSingle(dt.Rows[i][1]) * 200 / highPoint;
                barOrigin.Y = CHART_TOP + CHART_HEIGHT - barHeight;
                g.FillRectangle(new SolidBrush(ChartUtil.GetChartItemColor(i)), barOrigin.X, barOrigin.Y, barWidth, barHeight);
                barOrigin.X = barOrigin.X + (barWidth * 2);
            }
            //设置边 
            g.DrawLine(new Pen(Color.Black, 2), new Point(CHART_LEFT, CHART_TOP), new Point(CHART_LEFT, CHART_TOP + CHART_HEIGHT));
            g.DrawLine(new Pen(Color.Black, 2), new Point(CHART_LEFT, CHART_TOP + CHART_HEIGHT), new Point(CHART_LEFT + CHART_WIDTH, CHART_TOP + CHART_HEIGHT));
            //画图例框和文字 
            g.DrawRectangle(new Pen(Color.Black, 1), 200, 300, 199, 99);
            g.DrawString("Legend", new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new PointF(200, 300));

            //画图例 
            PointF boxOrigin = new PointF(210, 330);
            PointF textOrigin = new PointF(235, 326);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                g.FillRectangle(new SolidBrush(ChartUtil.GetChartItemColor(i)), boxOrigin.X, boxOrigin.Y, 20, 10);
                g.DrawRectangle(Pens.Black, boxOrigin.X, boxOrigin.Y, 20, 10);
                g.DrawString(dt.Rows[i][0].ToString() + " - " + dt.Rows[i][1].ToString(), new Font("Tahoma", 10), Brushes.Black, textOrigin);
                boxOrigin.Y += 15;
                textOrigin.Y += 15;
            }
            //输出图形 
            bm.Save(target, ImageFormat.Gif);

            //资源回收 
            bm.Dispose();
            g.Dispose();
        }
    }
    public class ChartUtil
    {
        public ChartUtil()
        {
        }
        public static Color GetChartItemColor(int itemIndex)
        {
            Color selectedColor;
            switch (itemIndex)
            {
                case 0:
                    selectedColor = Color.Blue;
                    break;
                case 1:
                    selectedColor = Color.Red;
                    break;
                case 2:
                    selectedColor = Color.Yellow;
                    break;
                case 3:
                    selectedColor = Color.Purple;
                    break;
                default:
                    selectedColor = Color.Green;
                    break;
            }
            return selectedColor;
        }

    }
}

 //代码分析： 
 // 1.引入一些namespace 
 // using System; 
 // using System.IO;//用于文件存取 
 // using System.Data;//用于数据访问 
 // using System.Drawing;//提供画GDI+图形的基本功能 
 // using System.Drawing.Text;//提供画GDI+图形的高级功能 
 // using System.Drawing.Drawing2D;//提供画高级二维，矢量图形功能 
 // using System.Drawing.Imaging;//提供画GDI+图形的高级功能 
 // 这些namespace将在后面被应用。 
 // 2.自定义一个namespace为Insight_cs.WebCharts，其中包括了两个类PieChart和BarChart，很清楚，class PieChart是为画饼图而建，class BarChart是为画条形图而建。由于class PieChart和class BarChar差不多，所以下面我们以饼图为例，进行代码分析。 
 // 3.类PieChart建立一个方法Render，此方法可以含一些参数。简单说明如下： 
 // 参数title，表示饼图上方的大标题文字。 
 // 参数subtitle，表示饼图上方的小标题文字。 
 // 参数width，height，表示了整个图形的大小。 
 // 参数charData是一个DataSet对象实例，用于画图使用。 
 // 参数target是Stream对象的实例，用于图形输出时使用。 
 // 4.为了增加可读性，定义一些常量： 
 // const int SIDE_LENGTH = 400;//画布边长 
 // const int PIE_DIAMETER = 200;//饼图直径 
 // 5.定义一个DataTable，它是DataSet中的一个数据表。其中存放了饼图的各个数据。 
 // 6.通过计算，得出饼图中的总基数sumData。 
 // 7.建立了一个BitMap对象，它为要创建的图形提供了内存空间。并由此产生一个Graphics对象，它封装了GDI+画图接口。 
 // 8.调用Graphics对象的方法ScaleTransform()，它是用来设定图形比例的。 
 // 9.调用方法SmoothingMode()，TextRenderingHint()等来设置文字和图形的相关属性。 
 // 9.设置画布和边。 
 // 10.设置文字标题，图例，画饼图自身。 
 // 11.通过Stream，将图形的内容发送到浏览器。 
 // 12.最后回收资源。 