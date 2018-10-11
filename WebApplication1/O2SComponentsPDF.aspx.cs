using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using O2S.Components.PDFRender4NET;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using XpShop.Client.Entity;
using XpShop.Client;
using XpShop.Common;

namespace WebApplication1
{
    public partial class O2SComponentsPDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public enum Definition
        {
            One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10
        }

        /// <summary>
        /// 将PDF文档转换为图片的方法
        /// </summary>
        /// <param name="pdfInputPath">PDF文件路径</param>
        /// <param name="imageOutputPath">图片输出路径</param>
        /// <param name="imageName">生成图片的名字</param>
        /// <param name="startPageNum">从PDF文档的第几页开始转换</param>
        /// <param name="endPageNum">从PDF文档的第几页开始停止转换</param>
        /// <param name="imageFormat">设置所需图片格式</param>
        /// <param name="definition">设置图片的清晰度，数字越大越清晰</param>
        public string ConvertPDF2Image(Stream stream, string imageOutputPath,
            string imageName, int startPageNum, int endPageNum, ImageFormat imageFormat, Definition definition)
        {
            string uploadResult;
            string FileNames = "";

            PDFFile pdfFile = PDFFile.Open(stream);

            //if (!Directory.Exists(imageOutputPath))
            //{
            //    Directory.CreateDirectory(imageOutputPath);
            //}

            // validate pageNum
            if (startPageNum <= 0)
            {
                startPageNum = 1;
            }

            if (endPageNum > pdfFile.PageCount)
            {
                endPageNum = pdfFile.PageCount;
            }

            if (startPageNum > endPageNum)
            {
                int tempPageNum = startPageNum;
                startPageNum = endPageNum;
                endPageNum = startPageNum;
            }

            // start to convert each page
            for (int i = startPageNum; i <= endPageNum; i++)
            {
                Bitmap pageImage = pdfFile.GetPageImage(i - 1, 56 * (int)definition);

                ImgUploadFromBase64Req entity = new ImgUploadFromBase64Req();
                entity.Id = 10;
                entity.Type = (int)ImgType.CartPic;
                entity.FileName = imageName + i.ToString()+".png";
                entity.Base64Img = GetBase64FromImage(pageImage);;
                //NetLog.WriteTextLog("生成base64编码", "Base64-" + i + "=" + entity.Base64Img, DateTime.Now);
                uploadResult = ImgClient.UploadImg(entity);
                //获取上传后的返回信息
                ImgUploadRes uploadRes = XpShop.Common.XpShopJSONHelper.Deserialize<XpShop.Client.Entity.ImgUploadRes>(uploadResult);
                if (uploadRes.ErrorFlag == 0)
                {
                    FileNames = FileNames + uploadRes.Img1+"|";
                }
                else
                {
                    Response.Write("上传失败，原因：" + uploadRes.ErrorMsg);
                }

                //pageImage.Save(imageOutputPath + imageName + i.ToString() + "." + imageFormat.ToString(), imageFormat);
                pageImage.Dispose();
            }
            Response.Write("上传成功，文件名：" + FileNames);
            pdfFile.Dispose();
            return FileNames;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fileCName = "";//成功保存在图片服务器后的文件名
                HttpPostedFile files = Request.Files[0];//获取文件
                string FileExtension = Path.GetExtension(Request.Files[0].FileName); //获取扩展名

                if (FileExtension.ToLower() != "pdf")//如果不是pdf文件
                {
                    string uploadResult;//上传结果

                    ImgUploadReq entity = new ImgUploadReq();
                    entity.Id = 10;
                    entity.Type = (int)ImgType.CartPic;
                    entity.File = Context.Request.Files[0];
                    uploadResult = ImgClient.UploadImg(entity);
                    //获取上传后的返回信息
                    ImgUploadRes uploadRes = XpShopJSONHelper.Deserialize<XpShop.Client.Entity.ImgUploadRes>(uploadResult);

                    if (uploadRes.ErrorFlag == 0)
                    {
                        fileCName += uploadRes.Img1;
                    }
                }
                else
                {
                    Stream FileStream = files.InputStream;
                    ConvertPDF2Image(FileStream, "/Upload/PDF/", "testPDF", 1, 2, ImageFormat.Png, Definition.Ten);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('错误！"+ex.Message+"');</script>");
            }
        }

        //BitMap转Base64
        public string GetBase64FromImage(Bitmap bmp)
        {
            string strbaser64 = "";
            try
            {
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                strbaser64 = Convert.ToBase64String(arr);
            }
            catch (Exception)
            {
                throw new Exception("Something wrong during convert!");
            }
            return strbaser64;
        }

    }
}