<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Make500Error.aspx.cs" Inherits="WebApplication1.Make500Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>模拟500内部错误</title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script>
        $(function () {
            $('#btnAsyncMake').click(function () {
                $.ajax({
                    url: "Make500Error.aspx?Action=Test",
                    type: "post",
                    dataType: "text",
                    success: function (data) {
                        console.log(data);
                    },
                    error: function () {
                        alert('读取出错');
                    }
                });
            });
            
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnMake" runat="server" Text="点击模拟500错误" OnClick="btnMake_Click" />
        <br />
        <br />
        <input type="button" id="btnAsyncMake" name="btnAsyncMake" value="点击模拟500错误(异步)" />
    </div>
    </form>
</body>
</html>
