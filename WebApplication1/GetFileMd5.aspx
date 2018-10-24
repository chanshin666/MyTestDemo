<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetFileMd5.aspx.cs" Inherits="WebApplication1.GetFileMd5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnGetMD5" runat="server" Text="获取文件Md5值" OnClick="btnGetMD5_Click" />
    </div>
    </form>
</body>
</html>
