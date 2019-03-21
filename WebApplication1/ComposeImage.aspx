<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComposeImage.aspx.cs" Inherits="WebApplication1.ComposeImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>合成图片</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnCompose" runat="server" Text="合成图片" OnClick="btnCompose_Click" />
    </div>
    </form>
</body>
</html>
