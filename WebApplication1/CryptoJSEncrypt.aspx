<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CryptoJSEncrypt.aspx.cs" Inherits="WebApplication1.CryptoJSEncrypt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CryptoJS加密</title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/crypto-js.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="text" id="txtName" name="txtName" placeholder="待加密数据" />
        <br />
        <br />
        <input type="text" id="txtPwd" name="txtPwd" placeholder="密钥" />
        <br />
        <br />
        <input type="button" id="btnLogin" name="btnLogin" value="加密" />
        <br />
        <br />
        返回结果：<label id="result"></label> <br /> <br />
    </div>
    </form>

    <script>
        $(function () {
            $('#btnLogin').click(function () {
                var keys = $('#txtPwd').val();
                var data = $('#txtName').val();
                var key = CryptoJS.enc.Utf8.parse(keys);
                data = CryptoJS.enc.Utf8.parse($.trim(data));
                var encrypted = CryptoJS.AES.encrypt(data, key, { mode: CryptoJS.mode.ECB, padding: CryptoJS.pad.Pkcs7 });
                $('#result').text(encrypted.toString());
            });
            
        })
    </script>
</body>
</html>
