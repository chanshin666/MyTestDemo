using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ComposeImage : System.Web.UI.Page
    {
        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCompose_Click(object sender, EventArgs e)
        {
            MakeAgentImg(1000);
            Response.Write("合成完成！");
        }

        #region 生成店主名片
        private void MakeAgentImg(int mid)
        {
            string AgentQrUrl = "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=gQHw7zoAAAAAAAAAASxodHRwOi8vd2VpeGluLnFxLmNvbS9xL3pVT01uZExtQXJaN2RvcFpPV19GAAIEKDTLVAMEAAAAAA==";
            string BgImgUrl = "http://305img.wsdict.com:8000/Upload/ZtdImg/0/4e46dc4913a5f156.jpg";
            string MemberHeadUrl = "http://305img.wsdict.com:8000/Upload/MemberImg/1000104/4ed1ba1c99844ce9.jpg";
            MergeImage(BgImgUrl, AgentQrUrl, MemberHeadUrl, mid);
        }
        #endregion

        #region 拼图函数
        /// <summary>
        /// 拼图函数
        /// </summary>
        /// <param name="BgImgUrl">背景图地址</param>
        /// <param name="AgentQRUrl">推广员二维码</param>
        /// <param name="MemberHeadUrl">用户头像</param>
        private void MergeImage(string BgImgUrl, string AgentQRUrl, string MemberHeadUrl, int MemberID)
        {
            string FileFolder = "Upload/StorekeeperImg/" + MemberID.ToString();


            if (!System.IO.Directory.Exists(Server.MapPath(FileFolder)))//如果不存在就创建file文件夹
            {
                System.IO.Directory.CreateDirectory(Server.MapPath(FileFolder));
            }
            
            // 数组元素个数(即要拼图的图片个数)
            int lenth = 3;
            // 图片集合
            Bitmap[] maps = new Bitmap[lenth];
            //图片对应纵坐标集合
            int[] pointY = new int[lenth];
            int[] pointX = new int[lenth];
            //读取本地图片初始化Bitmap
            Bitmap map = null;

            //第一个图片对象，背景图片
            map = UrlToBitmap(BgImgUrl);//new Bitmap(strBg);
            maps[0] = map;
            pointX[0] = 0;
            pointY[0] = 0;

            int[] BgImgSizeArray = new int[] { maps[0].Width, maps[0].Height };
            int QrImgSize = (int)(BgImgSizeArray.Min()*0.7); // 重新调整二维码的大小，尺寸为背景图最短边的70%
            pointX[1] = (int)((maps[0].Width - QrImgSize)>0? (maps[0].Width - QrImgSize)/2 : 0);// 二维码图片绘制的起始X轴
            pointY[1] = (int)((maps[0].Height - QrImgSize) > 0 ? (maps[0].Height - QrImgSize) * 0.8 : 0);// 二维码图片绘制的起始Y轴
            //第二个图片对象，二维码
            map = UrlToBitmap(AgentQRUrl);
            map = resizeImage(map, new Size(QrImgSize, QrImgSize));
            maps[1] = map;

            //第三个图片对象，用户头像
            int MemberHeadImgSize = (int)(BgImgSizeArray.Min() * 0.2); // 重新调整用户头像的大小，尺寸为背景图最短边的20%
            pointX[2] = (int)((maps[0].Width - MemberHeadImgSize) > 0 ? (maps[0].Width - MemberHeadImgSize) *0.1 : 0);// 用户头像绘制的起始X轴
            pointY[2] = (int)((maps[0].Height - MemberHeadImgSize) > 0 ? (maps[0].Height - MemberHeadImgSize) * 0.1 : 0);// 用户头像绘制的起始Y轴
            map = UrlToBitmap(MemberHeadUrl);
            map = resizeImage(map, new Size(MemberHeadImgSize, MemberHeadImgSize));
            map = CutEllipse(map, new Rectangle(0, 0, MemberHeadImgSize, MemberHeadImgSize), new Size(MemberHeadImgSize, MemberHeadImgSize));
            //map = CirclePhoto(map, MemberHeadImgSize);
            maps[2] = map;


            // 初始化背景图片的宽高
            Bitmap bitMap = new Bitmap(maps[0].Width, maps[0].Height);
            // 初始化画板
            Graphics g1 = Graphics.FromImage(bitMap);
            
            //绘制第一个图片，背景图
       
            for (int i = 0; i < maps[0].Width; i++)
            {
                for (int j = 0; j < maps[0].Height; j++)
                {
                    // 以像素点形式绘制(将要拼图的图片上的每个坐标点绘制到拼图对象的指定位置，直至所有点都绘制完成)
                    var temp = maps[0].GetPixel(i, j);
                    // 将图片画布的点绘制到整体画布的指定位置
                    bitMap.SetPixel(pointX[0] + i, pointY[0] + j, temp);
                }
            }
            
            maps[0].Dispose();
            
            //绘制第二个图片，二维码
            for (int i = 0; i < maps[1].Width; i++)
            {
                for (int j = 0; j < maps[1].Height; j++)
                {
                    var temp = maps[1].GetPixel(i, j);
                    //bitMap.SetPixel(i,j, temp);
                    bitMap.SetPixel(pointX[1] + i, pointY[1] + j, temp);
                }
            }
            maps[1].Dispose();

            //绘制第三个图片，用户头像
            for (int i = 0; i < maps[2].Width; i++)
            {
                for (int j = 0; j < maps[2].Height; j++)
                {
                    var temp = maps[2].GetPixel(i, j);
                    //bitMap.SetPixel(i,j, temp);
                    bitMap.SetPixel(pointX[2] + i, pointY[2] + j, temp);
                }
            }
            maps[2].Dispose();

            // 保存输出到本地
            bitMap.Save(Server.MapPath(FileFolder) + "AgentImg.jpg");
            g1.Dispose();
            bitMap.Dispose();
        }
        #endregion

        #region 调整图像大小
        //调整图像大小
        private static System.Drawing.Bitmap resizeImage(System.Drawing.Bitmap imgToResize, Size size)
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
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            imgToResize.Dispose();
            return b;
        }
        #endregion

        #region 网络图片转为Bitmap
        public static Bitmap UrlToBitmap(string PhotoUrl)
        {
            Stream stream = null;
            Bitmap bitmap = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(PhotoUrl);
                WebResponse response = request.GetResponse();
                stream = response.GetResponseStream();
                bitmap = StreamToBitmap(stream);
            }
            catch (Exception ex)
            {

            }
            return bitmap;
        }
        #endregion

        #region Stream转图片
        //Stream 转图片  
        public static Bitmap StreamToBitmap(Stream stream)
        {
            try
            {
                return new Bitmap((System.Drawing.Image)new Bitmap(stream));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            finally
            {
                stream.Close();
            }
        }

        #endregion

        #region 将图片绘制成圆形
        private System.Drawing.Bitmap CutEllipse(System.Drawing.Bitmap img, Rectangle rec, Size size)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (TextureBrush br = new TextureBrush(img, System.Drawing.Drawing2D.WrapMode.Clamp, rec))
                {
                    br.ScaleTransform(bitmap.Width / (float)rec.Width, bitmap.Height / (float)rec.Height);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillEllipse(br, new Rectangle(Point.Empty, size));
                }
            }
            return bitmap;
        }
        #endregion

        #region MyRegion
        /// <summary>
        /// 圆形图处理
        /// </summary>
        /// <param name="file">需要进行操作的图片</param>
        /// <param name="size">裁剪成格式（正方形size）</param>
        /// <returns></returns>
        public Bitmap CirclePhoto(System.Drawing.Image file, int size)
        {
            using (System.Drawing.Image i = file)
            {
                Bitmap b = new Bitmap(size, size);
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.DrawImage(i, 0, 0, b.Width, b.Height);
                    int r = Math.Min(b.Width, b.Height) / 2;
                    PointF c = new PointF(b.Width / 2.0F, b.Height / 2.0F);
                    for (int h = 0; h < b.Height; h++)
                        for (int w = 0; w < b.Width; w++)
                            if ((int)Math.Pow(r, 2) < ((int)Math.Pow(w * 1.0 - c.X, 2) + (int)Math.Pow(h * 1.0 - c.Y, 2)))
                            {
                                b.SetPixel(w, h, Color.Transparent);
                            }
                    //画背景色圆
                    using (Pen p = new Pen(System.Drawing.SystemColors.Control))
                        g.DrawEllipse(p, 0, 0, b.Width, b.Height);
                }
                return b;
            }
        }
        #endregion
        


    }
}