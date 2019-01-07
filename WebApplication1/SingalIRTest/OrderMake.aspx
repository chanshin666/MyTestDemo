<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderMake.aspx.cs" Inherits="WebApplication1.SingalIRTest.OrderMake" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>模拟生成订单号</title>
</head>
<body>
    <form runat="server">
        <asp:Button ID="btnOrderMake" runat="server" Text="生成新订单" OnClick="btnOrderMake_Click" />
    </form>
</body>
</html>
