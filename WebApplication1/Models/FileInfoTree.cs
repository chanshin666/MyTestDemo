using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FileInfoTree
    {
        public string name { set; get; }
        public string fileUrl { set; get; }
        public bool open { set; get; }
        public bool isParent { set; get; }
    }
}