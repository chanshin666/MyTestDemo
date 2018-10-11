<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="12306_Login.aspx.cs" Inherits="WebApplication1._12306_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>12306登录</title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <link href="Content/amazeui.min.css" rel="stylesheet" />
    <script>
        $(function () {
            //$.ajax({
            //    url: 'https://kyfw.12306.cn/passport/captcha/captcha-image?login_site=E&module=login&rand=sjrand',
            //    type: 'get',
            //    success: function (data) {
            //        $('#CodeImg').append(data);
            //    }
            //});
            var srcUrl = 'ajax.ashx?action=GetValidateImg'
            $.get(srcUrl, function (data) {
                //alert(data);
                var imgWindow = $("#CodeImg").html("<img src=" + data + ">");//接收Base64字符串，并转换为图片显示
                $('#CodeImg').append(imgWindow);
            })
        });
    </script>
    <style>
        #wrap{
            width:500px;
            height:500px;
            margin:10% auto;
            /*background-color:red;*/
        }
        #CodeImg{
            width:100%;
            height:100px;
            margin:5% auto;
            /*background-color:red;*/
        }
    </style>
</head>
<body>
   <form class="am-form" runat="server">
<div id="wrap">
  <fieldset>
    <div class="am-form-group">
      <label for="doc-ds-ipt-1">用户名</label>
      <input type="text" id="doc-ds-ipt-1" class="am-form-field" placeholder="12306账号" />
    </div>

    <div class="am-form-group">
      <label for="doc-ds-ipt-1">密码</label>
      <input type="text" id="doc-ds-ipt-2" class="am-form-field" placeholder="12306密码" />
    </div>

    <div id="CodeImg">
     
    </div>

    <button type="submit" class="am-btn am-btn-primary">登录</button>
  </fieldset>
</div>
</form>
</body>
</html>
