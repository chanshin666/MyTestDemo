<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DrawingPngImage.aspx.cs" Inherits="WebApplication1.DrawingPngImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <img src='img.ashx?action=newimg' alt='' title='连接后台生成的图片' />
    </div>
    </form>
</body>
</html>
