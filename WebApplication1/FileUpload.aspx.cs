using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XpShop.Client.Entity;
using XpShop.Client;
using XpShop.Common;
using System.Collections;
using System.Xml.Serialization;
using System.Text;
using System.IO;

namespace WebApplication1
{
    public partial class FileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string uploadResult;
            string fileName;

            ImgUploadReq entity = new ImgUploadReq();
            entity.Id = 10;
            entity.Type = (int)ImgType.PdtSepcIcon;
            entity.File = Request.Files[0];
            Response.Write("FileName=" + Request.Files[0].FileName);
            uploadResult = ImgClient.UploadImg(entity);
            //获取上传后的返回信息
            ImgUploadRes uploadRes = XpShopJSONHelper.Deserialize<XpShop.Client.Entity.ImgUploadRes>(uploadResult);

            if (uploadRes.ErrorFlag == 0)
            {
                string FileExtension = Path.GetExtension(Request.Files[0].FileName); //获取扩展名
                fileName = uploadRes.Img1;
                Response.Write("上传成功！文件名：" + fileName + "，小写扩展名是：" + FileExtension.ToLower());
                //CartPicDetail cartpicDetail = new CartPicDetail();
                //cartpicDetail.CartPicID = cartPicID;
                //cartpicDetail.RecordID = recordID;
                //cartpicDetail.ProductID = productID;
                //cartpicDetail.GoodID = goodID;
                //cartpicDetail.PicPath = fileName;
                //cartpicDetail.Num = 1;

                //CartPicDB.AddCartPic(cartpicDetail, ref errorFlag, ref errorMsg);//插入数据库
            }
            else
            {
                Response.Write("上传购物车设计稿图片服务器出错：" + uploadRes.ErrorMsg);
                //XpShop.Logger.XpShopLogger.Logger("上传购物车设计稿图片服务器出错：" + uploadRes.ErrorMsg);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                List<url> urlList = null;
                urlset urlsetList = new urlset();

                ArrayList listinfo = GetWebModelInfo();
                urlList = new List<url>();
                for (int i = 0; i < listinfo.Count; i++)
                {
                    WebSiteInfo webInfo = listinfo[i] as WebSiteInfo;
                    List<display> displayList = new List<display>();
                    display display = new display();
                    display.website = "爱购114";
                    display.siteurl = "http://www.xxxxx.com/";
                    //城市名称
                    display.city = webInfo.cityName;
                    //商品标题
                    display.webSitetitle = webInfo.title;
                    //商品图片
                    display.image = "http://211.155.235.30/tuangou/" + webInfo.folderName + "/" + webInfo.productimg;
                    //商品开始时间
                    display.startTime = webInfo.begin_time.ToShortDateString();
                    //商品结束时间
                    display.endTime = webInfo.end_time.ToShortDateString();
                    //市场价
                    display.value = Convert.ToDouble(webInfo.market_price);
                    //团购价
                    display.price = Convert.ToDouble(webInfo.team_price);
                    //折扣价
                    display.rebate = Convert.ToDouble(webInfo.zhekou_price);
                    //现在购买的人数
                    display.bought = webInfo.nownumber;
                    displayList.Add(display);
                    List<data> dataList = new List<data>();
                    data data = new data();
                    data.displayList = displayList;
                    dataList.Add(data);
                    url url = new url();
                    url.loc = String.Format("http://www.xxxxx.com/todaydetials.aspx?id={0}", webInfo.productID.ToString());
                    url.dataList = dataList;
                    urlList.Add(url);
                    urlsetList.urlList = urlList;
                }
                try
                {
                    XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
                    xmlns.Add(String.Empty, String.Empty);
                    //构造字符串
                    StringBuilder sb = new StringBuilder();
                    //将字符串写入到stringWriter对象中
                    StringWriter sw = new StringWriter(sb);
                    //xml序列化对象 typeof(类名)
                    XmlSerializer ser = new XmlSerializer(typeof(urlset));
                    //把Stream对象和urlset一起传入，序列化出一个字符串sb
                    ser.Serialize(sw, urlsetList, xmlns);
                    sw.Close();
                    string FILE_NAME = HttpContext.Current.Server.MapPath("test.xml");
                    FileInfo fi = new FileInfo(FILE_NAME);
                    //如果文件己经存在则删除该文件 
                    if (fi.Exists)
                    {
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") >= 0)
                        {
                            fi.Attributes = FileAttributes.Normal;
                        }
                        File.Delete(fi.Name);
                    }
                    //创建文件 并写入字符串
                    using (StreamWriter sWrite = File.CreateText(FILE_NAME))
                    {
                        sWrite.Write(sb.ToString().Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"").Replace("<urlList>", "").Replace("</urlList>", "").Replace("<dataList>", "").Replace("</dataList>", "").Replace("<displayList>", "").Replace("<displayList>", "").Replace("</displayList>", ""));
                        sWrite.Close();
                    }
                    //输出序列化后xml文件
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.ContentType = "application/xml";
                    Response.WriteFile(HttpContext.Current.Server.MapPath("test.xml"));
                    Response.Flush();
                    Response.Close();
                    Response.Write("生成成功！");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                }
            }
            catch (Exception ex)
            {
                Response.Write("错误！" + ex.Message);
            }
        }
        #region 获取xml实体类信息
        /// <summary>
        /// 获取xml实体类信息
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetWebModelInfo()
        {
            ArrayList list = new ArrayList();

            WebSiteInfo webModel = new WebSiteInfo();
            //城市名称
            webModel.cityName = "广东";
            //商品标题
            webModel.title = "商品1";
            //商品创建时间
            webModel.createtime = Convert.ToDateTime("2017-11-26 09:10:00");
            //商家名称
            webModel.merchants_id = "商家1";
            //商品图片
            webModel.productimg = "这是商品图";
            //市场价
            webModel.market_price = Convert.ToDecimal("120");
            //团购价
            webModel.team_price = Convert.ToDecimal("100");
            //折扣价
            webModel.zhekou_price = Convert.ToDecimal("20");
            //开始时间
            webModel.begin_time = Convert.ToDateTime("2017-12-26 09:00:00");
            //结束时间
            webModel.end_time = Convert.ToDateTime("2017-12-31 09:00:00");
            //商品说明
            webModel.description = "这是商品描述";
            //最低购买数量
            webModel.lowBuNo = Convert.ToInt32("1");
            //商家电话
            webModel.Telphone = "88888888";
            //商家地址
            webModel.Address = "特发信息科技大厦";
            //城市编号
            webModel.cCode = "440000";
            //图片文件夹名称
            webModel.folderName = "Upload/SpecIcon";
            //现在购买人数
            webModel.nownumber = Convert.ToInt32("10000");
            //商品编号
            webModel.productID = Convert.ToInt32("1000888");

            int status = Convert.ToInt32("1");
            switch (status)
            {
                case 0:
                    webModel.StatusMessage = "结束";
                    break;
                case 1:
                    webModel.StatusMessage = "成功";
                    break;
            }
            list.Add(webModel);
            return list;
        }
        #endregion


    }
}

public class urlset
{
    public List<url> urlList { get; set; }
}

public class url
{
    public string loc { get; set; }
    public List<data> dataList { get; set; }
}

public class data
{
    public List<display> displayList { get; set; }
}

public class display
{
    public string website { get; set; }
    public string siteurl { get; set; }
    public string city { get; set; }
    public string webSitetitle { get; set; }
    public string image { get; set; }
    public string startTime { get; set; }
    public string endTime { get; set; }
    public double value { get; set; }
    public double price { get; set; }
    public double rebate { get; set; }
    public int bought { get; set; }
}

public class WebSiteInfo
{
    /// <summary>
    /// 商品标题
    /// </summary>
    public string title { get; set; }
    /// <summary>
    /// 商品发布时间
    /// </summary>
    public DateTime createtime { get; set; }
    /// <summary>
    /// 商品图片
    /// </summary>
    public string productimg { get; set; }
    /// <summary>
    /// 市场价
    /// </summary>
    public decimal market_price { get; set; }
    /// <summary>
    /// 团购价
    /// </summary>
    public decimal team_price { get; set; }
    /// <summary>
    /// 折扣价
    /// </summary>
    public decimal zhekou_price { get; set; }
    /// <summary>
    /// 城市名称 
    /// </summary>
    public string cityName { get; set; }
    /// <summary>
    /// 商品开始时间
    /// </summary>
    public DateTime begin_time { get; set; }
    /// <summary>
    /// 结束时间
    /// </summary>
    public DateTime end_time { get; set; }
    /// <summary>
    /// 商家名称
    /// </summary>
    public string merchants_id { get; set; }
    /// <summary>
    /// 本单详情
    /// </summary>
    public string description { get; set; }
    /// <summary>
    /// 最低购买人数
    /// </summary>
    public int lowBuNo { get; set; }
    /// <summary>
    /// 商家地址
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// 商家电话
    /// </summary>
    public string Telphone { get; set; }
    /// <summary>
    /// 城市区号
    /// </summary>
    public string cCode { get; set; }
    /// <summary>
    /// 文件夹名称
    /// </summary>
    public string folderName { get; set; }
    /// <summary>
    /// 团购状态 
    /// </summary>
    public string StatusMessage { get; set; }
    /// <summary>
    /// 现在购买人数
    /// </summary>
    public int nownumber { get; set; }
    /// <summary>
    /// 商品编号
    /// </summary>
    public int productID { get; set; }
}