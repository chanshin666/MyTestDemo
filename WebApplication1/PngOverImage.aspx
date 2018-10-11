<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PngOverImage.aspx.cs" Inherits="WebApplication1.PngOverImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>虚线框Png图片覆盖在Image图片上</title>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <style>
        #container{
            display: table-cell;
            vertical-align: middle;
            text-align:center;  
            width:600px;
            height:450px;
            border:1px black solid;
            position:relative;
            z-index:1;
            overflow:hidden;
        }
        #DotPng{
            position:absolute;
            top:0;
            left:0;
            z-index:5;
        }
        #NormalImage{
            z-index:2;
        }
        .MirrorCss{
            transform:scaleX(-1);
        }
        .Rotate{
            transform:scaleX(-1);
        }
    </style>
    <script>
        $(function () {
            var IsFilling = 0;
            var IsMirror = 0;
            var Rotate = 0;

            $('#Filling').click(function () {
                if (IsFilling==1) {
                    $('#NormalImage').css({ 'width': '', 'height': '' });
                    IsFilling = 0;
                }
                else {
                    $('#NormalImage').css({ 'width': '100%', 'height': '100%' });
                    IsFilling = 1;
                }
            });
            $('#Mirror').click(function () {
                if (IsMirror==1) {
                    // $('#NormalImage').css({ 'transform': '' });
                    $('#NormalImage').removeClass('MirrorCss');
                    IsMirror = 0;
                } else {
                    // $('#NormalImage').css({ 'transform': 'scaleX(-1)' });
                    $('#NormalImage').addClass('MirrorCss');
                    IsMirror = 1;
                }
            });
            $('#Rotate').click(function () {
                Rotate = Rotate + 90
                if (Rotate == 360) {
                    Rotate = 0;
                    $('#NormalImage').css({ 'transform': '' });
                } else {
                    $('#NormalImage').css({ 'transform': 'rotate(' + Rotate + 'deg)' });
                }
                
            });

           

            $('#Save').click(function () {
                var img = new Image();
                img.onload = function () { alert(img.height); };
                img.src = "Images/24.jpg";
                img.style = $('#NormalImage').attr('style');
                var base64 = convertImageToCanvas(img).toDataURL('images/png');//注意是canvas元素才有 toDataURL 方法  
                console.log(base64);

            });

        });

        function isContains(str, substr) {
            return str.indexOf(substr) >= 0;
        }

        // 把image 转换为 canvas对象  
        function convertImageToCanvas(image) {
            // 创建canvas DOM元素，并设置其宽高和图片一样   
            var canvas = document.createElement("canvas");
            canvas.width = image.width;
            canvas.height = image.height;
            // 坐标(0,0) 表示从此处开始绘制，相当于偏移。  
            canvas.getContext("2d").drawImage(image, 0, 0);
            return canvas;
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <img id="NormalImage" src="Images/24.jpg" width="20%" height="20%" />
        <img id="DotPng" src="Upload/DrawingPngImage/test.png" width="100%" height="100%" />
       <%-- <canvas width="400" height="300"></canvas>  --%>
    </div>
     <br />
    <input type="button" id="Filling" value="平铺" />
    <input type="button" id="Mirror" value="镜像" />
    <input type="button" id="Rotate" value="旋转" />
    <input type="button" id="Save" value="保存"/>
    </form>
</body>
</html>
