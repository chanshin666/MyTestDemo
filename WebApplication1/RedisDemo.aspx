<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RedisDemo.aspx.cs" Inherits="WebApplication1.RedisDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="点击按钮进行数据获取"></asp:Label>
        <asp:Button ID="btnGetRedisData" runat="server" Text="获取测试数据" OnClick="btnGetRedisData_Click" />
    </div>
    </form>
</body>
</html>
