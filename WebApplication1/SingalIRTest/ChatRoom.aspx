<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="WebApplication1.SingalIRTest.ChatRoom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>简易聊天室</title>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.0.min.js"></script>
    <script src="../signalr/hubs"></script>
</head>
<body>
    <b id="displayname"></b>：<input type="text" id="Msg" />
    <input type="button" id="btnSend" value="发送" />
    

    <ul id="ChatList">

    </ul>

    <script>
        $(function () {
            var chatHub = $.connection.ChatHub;

            //接收服务器推送的消息
            chatHub.client.broadcastMessage = function (name, message) {
                var encodedName = $('<div />').text(name).html(); // 防止XSS攻击
                var encodedMsg = $('<div />').text(message).html();// 防止XSS攻击

                $('#ChatList').append('<li><strong>' + encodedName
                    + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
            };

            $('#displayname').text(prompt('Enter your name:', ''));
            $('#Msg').focus();

            $.connection.hub.start().done(function () {
                $('#btnSend').click(function () {
                    // 调用服务器端的ChatHub.Send方法，并把消息发送到服务器
                    chatHub.server.send($('#displayname').text(),$('#Msg').val());
                    
                    $('#Msg').val('').focus();
                });
            });

        });
    </script>
</body>
</html>
