using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class CheckLogsTree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Action = string.IsNullOrEmpty(Request.QueryString["Action"]) ? "" : Request.QueryString["Action"];
                switch (Action)
                {
                    case "Init":
                        InitFileFolders();
                        break;
                    case "GetAllFileFolders":
                        string Url = string.IsNullOrEmpty(Request.QueryString["Url"]) ? "" : Request.QueryString["Url"];
                        GetAllFileFolders(Url);
                        break;
                    case "OpenFile":
                        string FileUrl = string.IsNullOrEmpty(Request.QueryString["Url"]) ? "" : Request.QueryString["Url"];
                        OpenFiles(FileUrl);
                        break;

                }
                //FileFolders = GetAllFileFolders();
            }
        }

        private void InitFileFolders()
        {
            GetAllFileFolders("");
        }

        #region 读取文件夹以及log文件
        /// <summary>
        /// 读取文件夹以及log文件
        /// </summary>
        /// <param name="Url">需要读取的地址信息</param>
        /// <returns></returns>
        private void GetAllFileFolders(string Url)
        {
            List<FileInfoTree> FileInfos = new List<FileInfoTree>();

            string FileUrl = string.IsNullOrEmpty(Url) ? Server.MapPath("~/") : Server.MapPath("~/") + Url;
            //获取文件地址，此时返回的文件夹包含文件夹的整体路径
            string[] FileStrings = Directory.GetFiles(FileUrl, "*.log"); //Directory.GetDirectories(FileUrl);
            //如果需要获取文件夹的名称集合
            List<string> FileList = FileStrings.Select(d => d.Substring(d.LastIndexOf('\\') + 1)).ToList();

            foreach (var item in FileList)
            {
                FileInfos.Add(new FileInfoTree()
                {
                    name = item,
                    fileUrl = Url + "\\" + item
                });
            }

            //获取文件地址，此时返回的文件夹包含文件夹的整体路径
            string[] directorieStrings = Directory.GetDirectories(FileUrl);
            //如果需要获取文件夹的名称集合
            List<string> FileFolderList = directorieStrings.Select(d => d.Substring(d.LastIndexOf('\\') + 1)).ToList();

            foreach (var item in FileFolderList)
            {
                FileInfos.Add(new FileInfoTree()
                {
                    name = item,
                    fileUrl = Url + "\\" + item,
                    isParent = true
                }); 
            }

            string Result = JsonConvert.SerializeObject(FileInfos);

            Response.Write(Result);
            Response.End();


            //StringBuilder sb = new StringBuilder();
            //sb.Append("{");
            //sb.Append("\"totalCount\":\"" + FileList.Count + "\",");
            //sb.Append("\"Files\":[");
            //if (FileList != null && FileList.Count > 0)
            //{
            //    foreach (var item in FileList)
            //    {
            //        sb.Append("{\"FileName\":\"" + item + "\"},");
            //    }
            //    sb.Remove(sb.ToString().LastIndexOf(','), 1);
            //}
            //sb.Append("]");
            //sb.Append("}");

            //Response.Write(sb.ToString());
            //Response.End();
        }

        #endregion

        #region 打开.log文件
        private void OpenFiles(string FileUrl)
        {
            //string content;
            //using (StreamReader sr = new StreamReader((Server.MapPath("~/")+FileUrl), Encoding.Default))
            //{
            //    content = sr.ReadToEnd();
            //}

            string content = "";
            using (StreamReader sReader = new StreamReader((Server.MapPath("~/") + FileUrl), Encoding.Default))
            {
                string strReadline;
                while ((strReadline = sReader.ReadLine()) != null)
                {
                    content = content + strReadline + "<br />";
                }

            }

            Response.Write(content);
            Response.End();
        }
        #endregion

    }
}