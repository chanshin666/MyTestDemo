using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace WebApplication1
{
    public partial class ThumbnailImgBuild : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile("C:/Users/Chanshin/Desktop/testDemo/WebApplication1/Images/5.jpg");
            Bitmap b = new Bitmap(img);
            //Bitmap b = GetPart("C:/Users/Chanshin/Desktop/testDemo/WebApplication1/Images/5.jpg",0,0,500,600,200,200);
            System.Drawing.Image i = resizeImage(b, new Size(600, 150));
            i.RotateFlip(RotateFlipType.Rotate90FlipX);
            i.Save("/Upload/PDF/aaa.jpg");
            //b.Save("/Upload/PDF/aaa.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        /// <summary>
        /// 创建一个调整图像大小的方法
        /// </summary>
        /// <param name="imgToResize"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            //获取图片宽度
            int sourceWidth = imgToResize.Width;
            //获取图片高度
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //计算宽度的缩放比例
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //计算高度的缩放比例
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //期望的宽度
            int destWidth = (int)(sourceWidth * nPercent);
            //期望的高度
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //绘制图像
            g.DrawImage(imgToResize, 0, 0, (int)size.Width, (int)size.Height);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        /// <summary>
        /// http://www.cnblogs.com/KissKnife/archive/2007/10/13/923352.html
        /// 获取图片指定部分
        /// </summary>
        /// <param name="pPath">图片路径</param>
        /// <param name="pPartStartPointX">目标图片开始绘制处的坐标X值(通常为0)</param>
        /// <param name="pPartStartPointY">目标图片开始绘制处的坐标Y值(通常为0)</param>
        /// <param name="pPartWidth">目标图片的宽度</param>
        /// <param name="pPartHeight">目标图片的高度</param>
        /// <param name="pOrigStartPointX">原始图片开始截取处的坐标X值</param>
        /// <param name="pOrigStartPointY">原始图片开始截取处的坐标Y值</param>
        static System.Drawing.Bitmap GetPart(string pPath, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY)
        {
            System.Drawing.Image originalImg = System.Drawing.Image.FromFile(pPath);

            System.Drawing.Bitmap partImg = new System.Drawing.Bitmap(pPartWidth, pPartHeight);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(partImg);
            System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(new System.Drawing.Point(pPartStartPointX, pPartStartPointY), new System.Drawing.Size(pPartWidth, pPartHeight));//目标位置
            System.Drawing.Rectangle origRect = new System.Drawing.Rectangle(new System.Drawing.Point(pOrigStartPointX, pOrigStartPointY), new System.Drawing.Size(pPartWidth, pPartHeight));//原图位置（默认从原图中截取的图片大小等于目标图片的大小）

            graphics.DrawImage(originalImg, destRect, origRect, System.Drawing.GraphicsUnit.Pixel);

            return partImg;
        }

        //Bitmap转byte[]    
        public static byte[] BitmapToBytes(Bitmap Bitmap)   
        {   
            MemoryStream ms = null;   
            try   
            {   
                ms = new MemoryStream();   
                Bitmap.Save(ms, Bitmap.RawFormat);   
                byte[] byteImage = new Byte[ms.Length];   
                byteImage = ms.ToArray();   
                return byteImage;   
            }   
            catch (ArgumentNullException ex)   
            {   
                throw ex;   
            }   
            finally   
            {   
                ms.Close();   
            }   
        }

        /// <summary>  
        /// byte[]转换成Image  
        /// </summary>  
        /// <param name="byteArrayIn">二进制图片流</param>  
        /// <returns>Image</returns>  
        public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null)
                return null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn))
            {
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                ms.Flush();
                return returnImage;
            }
        }  
    


    }
}