<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NLogTest.aspx.cs" Inherits="WebApplication1.NLogTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnWriteLog" runat="server" Text="写日志" OnClick="btnWriteLog_Click" />
    </div>
    </form>
</body>
</html>
