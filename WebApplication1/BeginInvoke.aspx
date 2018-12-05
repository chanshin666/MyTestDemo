<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BeginInvoke.aspx.cs" Inherits="WebApplication1.BeginInvoke" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>异步多线程测试</title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/BeginInvoke.js"></script>
</head>
<body>
    <form runat="server">
    <asp:Button ID="btnSyncBeginInvoke" runat="server" Text="同步按钮的异步多线程" OnClick="btnSyncBeginInvoke_Click" />
    </form>
    <br />
    <input type="button" id="btnAsyncBeginInvoke" name="btnAsyncBeginInvoke" value="异步按钮的异步多线程" />
    <br />
    <br />
    <div id="content">

    </div>
</body>
</html>
