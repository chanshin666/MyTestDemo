using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XpVShop.Entity
{
    public class ImgUploadResEntity
    {
        public int ErrorFlag { get; set; }

        public string ErrorMsg { get; set; }

        public string FileFolder { get; set; }

        public string Img1 { get; set; }

        public string Img2 { get; set; }

        public string Img3 { get; set; }

        public string Img4 { get; set; }

        public string Img5 { get; set; }

        public string Img6 { get; set; }

        public string ImgDomain { get; set; }

        public string Sign { get; set; }
    }
}
