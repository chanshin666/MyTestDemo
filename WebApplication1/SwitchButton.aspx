<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SwitchButton.aspx.cs" Inherits="WebApplication1.SwitchButton" %>

<!DOCTYPE html>
<html>
<head>
  <title>Foundation 实例</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://cdn.bootcss.com/foundation/5.5.3/css/foundation.min.css">
  <script src="https://cdn.bootcss.com/jquery/2.1.1/jquery.min.js"></script>
  <script src="https://cdn.bootcss.com/foundation/5.5.3/js/foundation.min.js"></script>
  <script src="https://cdn.bootcss.com/foundation/5.5.3/js/vendor/modernizr.js"></script>
    <script>
        $(function () {
            $('#mySwitch2').click(function () {
                if ($('#mySwitch2').is(':checked')) {
                    alert('当前选中');
                } else {
                    alert('当前没有选中');
                }
            });
        });
    </script>
</head>

<body>

<div style="padding:20px;">
  <h2>圆角开关</h2>
  <p>使用 <code>.radius</code> 和 <code>.round</code> 类来设置圆角开关:</p>
  <span>默认</span>
  <div class="switch">
    <input id="mySwitch1" type="checkbox">
    <label for="mySwitch1"></label>
  </div> 

  <span>圆角</span>
  <div class="switch radius">
    <input id="mySwitch2" type="checkbox" checked="checked">
    <label for="mySwitch2"></label>
  </div> 

  <span>圆形</span>
  <div class="switch round">
    <input id="mySwitch3" type="checkbox">
    <label for="mySwitch3"></label>
  </div> 
</div>

</body>
</html>
