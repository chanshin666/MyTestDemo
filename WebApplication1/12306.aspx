<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="12306.aspx.cs" Inherits="WebApplication1._12306" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>12306测试</title>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/12306.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="text" id="txtDate" name="txtDate" placeholder="输入日期" />
        <input type="button" id="btnCheck" name="btnCheck" value="查询"/>

        <table id="ReturnData">
            <tr>
                <td>信息如下</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
