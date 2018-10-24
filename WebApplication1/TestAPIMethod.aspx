<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestAPIMethod.aspx.cs" Inherits="WebApplication1.TestAPIMethod" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>API方法调用调试</title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/amazeui.min.js"></script>
    <link href="Content/amazeui.min.css" rel="stylesheet" />
    <script src="Scripts/layer/layer.js"></script>
    <script src="Scripts/TestAPIMethod.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="button" id="btnTest" name="btnTest" class="am-btn am-btn-secondary" value="测试" />
    </div>
    </form>
</body>
</html>
