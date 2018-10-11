<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DragTable.aspx.cs" Inherits="WebApplication1.DragTable" %>

<!doctype html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <title>jQuery UI 拖动（Draggable） - 约束运动</title>
  <link rel="stylesheet" href="//apps.bdimg.com/libs/jqueryui/1.10.4/css/jquery-ui.min.css">
  <script src="//apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
  <script src="//apps.bdimg.com/libs/jqueryui/1.10.4/jquery-ui.min.js"></script>
  <link rel="stylesheet" href="jqueryui/style.css">
  <style>
  .draggable { width: 90px; /*height: 90px; padding: 0.5em; float: left; margin: 0 10px 10px 0;*/ }
  /*#draggable, #draggable2 { margin-bottom:20px; }*/
  #draggable { cursor: n-resize; }
  #draggable2 { cursor: e-resize; }
  #containment-wrapper { width: 95%; height:150px; border:2px solid #ccc; padding: 10px; }
  h3 { clear: left; }
  </style>
  <script>
  $(function() {
    $( "#draggable" ).draggable({ axis: "y=10" });
      //$( "#draggable2" ).draggable({ axis: "x" });
    //$("#draggable2").draggable({ containment: [10, 10, 100, 100] });
    $("#draggable2").draggable({
        containment: '#Container',
        start: function () {//开始拖动事件
            //DragStart(this);
        },
        drag: function () {//拖动时事件
            //Draging(this);
        },
        stop: function () {//鼠标松开，结束拖动事件
            DragStop(this);
        }
    });
 
    $("#draggable3").draggable({ containment: [0, 50, 0, 100], containment: "#containment-wrapper" });

    //$( "#draggable3" ).draggable({ containment: "#containment-wrapper", scroll: false });
    $("#draggable5").draggable({ containment: "parent" });

  });


  function DragStop(selector) {
      $('#draggable6').draggable({
          //containment: [0,0,300,0],
          containment: '#Container',
          scroll: false,
          axis: "x",
          //拖动事件
          start: function () {//开始拖动事件
              //DragStart($(this));
          },
          drag: function () {//拖动时事件
              //Draging($(this));
          },
          stop: function () {//鼠标松开，结束拖动事件
              //DragStop(this);
          }
      }).draggable("option","containment",[100,0,200,0]);
  }

  //function Drag(selector) {
  //    var StringForbidden=$(selector).attr('forbidden');
  //    var forbidden = (StringForbidden=='true')
  //    console.log('forbidden=' + forbidden);
  //   // console.log($(selector).css('top'));
  //    console.log($(selector).css('left'));
  //    $(selector).draggable();
  //    //var top = $(selector).css('top');
  //    var top = $(selector).css('left');
  //    var distance=top.substring(0,top.length-2);
  //    if (distance > 100 || forbidden) {
  //        $(selector).draggable("destroy");
  //        $(selector).attr('forbidden','true');
  //    } else {
  //        $(selector).draggable();
  //        $(selector).attr('forbidden', 'false');
  //    }
  //}

  //function DragStart(selector) {
  //    //console.log('Start：' + $(selector).css('top'));
  //    console.log('Start：' + $(selector).css('left'));
  //    $(selector).draggable();
  //    //var top = $(selector).css('top');
  //    var top = $(selector).css('left');
  //    var distance = top.substring(0, top.length - 2);
  //    console.log('Start-2：' + (distance - 2));
  //    console.log('(distance-2) > 100：' + ((distance - 2) > 100));
  //    if ((distance-2) >= 100) {
  //        $(selector).draggable("disable");
  //    } else {
  //        $(selector).draggable();
  //    }
  //}

  //function DragClick(selector) {
  //    $(selector).draggable();
  //}

  </script>
</head>
<body>
 
<h3>沿着轴约束运动：</h3>
 
<%--<div id="draggable" class="draggable ui-widget-content">
  <p>只能垂直拖拽</p>
</div>--%>

 <div id="Container" style="width:500px;height:300px;background-color:#ff6a00;margin:0 auto;position:relative;">
    <div id="draggable2" class="draggable ui-widget-content" style="position:absolute;"><%--  ondragstart="DragStart(this)" onclick="DragClick(this)" ondrag="Drag(this)" forbidden = "false"--%>
        <p>测试2</p>
    </div>
     <br /><br /><br />
    <div id="draggable6" class="draggable ui-widget-content" style="position:absolute">
        <p>测试6</p>
    </div>
</div>

 
<h3>或者在另一个 DOM 元素中约束运动：</h3>
<div id="containment-wrapper">
 <%-- <div id="draggable3" class="draggable ui-widget-content">
    <p>我被约束在盒子里</p>
  </div>--%>
 
     
<hr id="draggable3" class="draggable ui-widget-content" /><%-- ondragstart="DragStart(this)" onclick="DragClick(this)" ondrag="Drag(this)" --%>

  <div class="draggable ui-widget-content">
    <p id="draggable5" class="ui-widget-header">我被约束在父元素内</p>
  </div>
</div>
 
 
</body>
</html>