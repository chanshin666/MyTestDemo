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

            //var srcUrl = 'ajax.ashx?action=GetValidateImg'
            //$.get(srcUrl, function (data) {
            //    // console.log(data);
            //    $("#CPic").attr('src',data);
            //    //var imgWindow = $("#CodeImg").html("<img src='" + data + "'>");//接收Base64字符串，并转换为图片显示
            //    //$('#CodeImg').append(imgWindow);
            //})

            var xmlhttp;
            xmlhttp=new XMLHttpRequest();
            xmlhttp.open("GET", "ajax.ashx?action=GetValidateImg", true);
            xmlhttp.responseType = "blob";
            xmlhttp.onload = function(){
                console.log(this);
                if (this.status == 200) {
                    var blob = this.response;
                    var img = document.createElement("img");
                    img.onload = function(e) {
                        window.URL.revokeObjectURL(img.src); 
                    };
                    img.src = window.URL.createObjectURL(blob);
                    document.getElementById("CodeImg").appendChild(img);
                }
            }
            xmlhttp.send();

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
        #btnLogin{
            margin-top:15%;
            width:100%;
            line-height:30px;
            font-size:16px;
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

    <button type="submit" class="am-btn am-btn-primary" id="btnLogin">登录</button>
  </fieldset>
</div>
</form>
</body>
</html>
