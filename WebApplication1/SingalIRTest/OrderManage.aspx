<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderManage.aspx.cs" Inherits="WebApplication1.SingalIRTest.OrderManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>模拟后台查看订单</title>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.0.min.js"></script>
    <script src="../signalr/hubs"></script>
    <link href="../Content/themes/default/easyui.css" rel="stylesheet" />
    <link href="../Content/themes/icon.css" rel="stylesheet" />
    <script src="../Scripts/jquery.easyui.min.js"></script>
</head>
<body>
    <h3>订单列表</h3>
    <ul id="OrderList">

    </ul>

    <script>
        $(function () {
            var orderHub = $.connection.OrderHub;

            // recieveOrder对应的是OrderMake.aspx.cs中的hub.Clients.All.recieveOrder语句
            // 用来接收服务器传来的数据
            orderHub.client.recieveOrder = function (data) { 
                $('#OrderList').append('<li><strong>' + data
                    + '</strong></li>');

                $.messager.show({ //easyui的右下键提示框
                    title: '有新的订单',
                    msg: data,
                    timeout: 5000,
                    showType: 'slide'
                });
            };

            $.connection.hub.start().done(function () {
                orderHub.server.Init(); //Init()对应后台中的OrderHub.cs中的Init()方法，不做任何事，为的是连接服务器
            });

        });
    </script>
</body>
</html>
