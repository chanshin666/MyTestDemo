using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ReadCert : System.Web.UI.Page
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        //5.0.0验签证书，key是certId
        private static Dictionary<string, Cert> cerCerts = new Dictionary<string, Cert>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            log.Info("读取验签证书文件夹" + (Server.MapPath("~/") + "Cert/") + "下所有cer文件……");
            DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/")+"Cert/");
            FileInfo[] files = directory.GetFiles("*.cer");
            if (null == files || 0 == files.Length)
            {
                log.Info("请确定[" + (Server.MapPath("~/") + "Cert/") + "]路径下是否存在cer文件");
                return;
            }
            foreach (FileInfo file in files)
            {
                FileStream fileStream = null;
                try
                {
                    string FilePath = file.DirectoryName + "\\" + file.Name;
                    log.Info("找到验签证书文件" + file.DirectoryName + "\\" + file.Name);
                    fileStream = new FileStream(FilePath, FileMode.Open);
                    log.Info("验签证书文件fileStream");
                    X509Certificate certificate = new X509CertificateParser().ReadCertificate(fileStream);
                    log.Info("验签证书文件X509Certificate读取完成");
                    Cert cert = new Cert();
                    cert.cert = certificate;
                    cert.certId = certificate.SerialNumber.ToString();
                    log.Info("验签证书文件X509Certificate>>>cert.certId=" + certificate.SerialNumber.ToString());
                    cert.key = certificate.GetPublicKey();
                    log.Info("验签证书文件X509Certificate>>>cert.Key读取完成");
                    cerCerts[cert.certId] = cert;
                    log.Info(file.Name + "读取成功，序列号：" + cert.certId);
                }
                finally
                {
                    if (fileStream != null)
                        fileStream.Close();
                }
            }
        }
    }

    public class Cert
    {
        public AsymmetricKeyParameter key;
        public X509Certificate cert;
        public string certId;
    }
}