<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReferenceLine.aspx.cs" Inherits="WebApplication1.ReferenceLine" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>参考线</title>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <style>
        body {
            font-family: courier new, courier;
            font-size: 12px;
        }
        hr{
            margin:0;
            padding:0;
        }
        .draggable {
            width: 100%;
            /*height: 200px;*/
            border: 1px solid #ccc;
            display: inline-block;
            cursor: n-resize;
            position: absolute;
        }

        .guide {
            display: none;
            position: absolute;
            left: 0;
            top: 0;
        }

        #guide-h {
            border-top: 1px dashed #55f;
            width: 100%;
        }

        #guide-v {
            border-left: 1px dashed #55f;
            height: 100%;
        }
    </style>
    <%--<script>
        $(function () {

         /**
         * 指标拖动辅助标线
         * @author sdj
         */
        var MIN_DISTANCE = 8; //捕获的最小距离
        var guides = []; // 没有可用的引导 
        var innerOffsetX, innerOffsetY; $(".draggable").draggable({
            start: function (event, ui) {
                guides = $.map($(".draggable").not(this), computeGuidesForElement);
                //offsetX、offsetY：源元素（srcElement）的X,Y坐标
                innerOffsetX = event.offsetX;
                innerOffsetY = event.offsetY;
            },

            /*** 参数说明
            * @param event
            * @param ui* 
            *  event事件的 
            * offsetX：
            * outerwidth： 属性是一个只读的整数，声明了整个窗口的宽度。
            *  outerheight： 属性是一个只读的整数，声明了整个窗口的高度。*/
            drag: function (event, ui) {
                //迭代所有的guids，记住最近的h和v guids
                var guideV, guideH, distV = MIN_DISTANCE + 1, distH = MIN_DISTANCE + 1, offsetV, offsetH;
                var chosenGuides = { top: { dist: MIN_DISTANCE + 1 }, left: { dist: MIN_DISTANCE + 1 } };
                var $t = $(this);
                //pageX、pageY：文档坐标x、y ;
                var pos = { top: event.pageY - innerOffsetY, left: event.pageX - innerOffsetX };
                //outerHeight、outerWidth：整个浏览器的高度、宽度
                var w = $t.outerWidth() - 1;
                var h = $t.outerHeight() - 1;
                var elemGuides = computeGuidesForElement(null, pos, w, h);
                $.each(guides, function (i, guide) {
                    $.each(elemGuides, function (i, elemGuide) {
                        if (guide.type == elemGuide.type) {
                            var prop = guide.type == "h" ? "top" : "left";
                            var d = Math.abs(elemGuide[prop] - guide[prop]);
                            if (d < chosenGuides[prop].dist) {
                                chosenGuides[prop].dist = d; chosenGuides[prop].offset = elemGuide[prop] - pos[prop]; chosenGuides[prop].guide = guide;
                            }
                        }
                    });
                });
                if (chosenGuides.top.dist <= MIN_DISTANCE) {
                    $("#guide-h").css("top", chosenGuides.top.guide.top).show();
                    ui.position.top = chosenGuides.top.guide.top - chosenGuides.top.offset;
                } else {
                    $("#guide-h").hide();
                    ui.position.top = pos.top;
                }
                if (chosenGuides.left.dist <= MIN_DISTANCE) {
                    $("#guide-v").css("left", chosenGuides.left.guide.left).show();
                    ui.position.left = chosenGuides.left.guide.left - chosenGuides.left.offset;
                } else {
                    $("#guide-v").hide();
                    ui.position.left = pos.left;
                }
            },
            stop: function (event, ui) {
                $("#guide-v, #guide-h").hide();
            }
        });

        


        });

        function computeGuidesForElement(elem, pos, w, h) {
            if (elem != null) {
                var $t = $(elem); //offset:返回当前元素 的偏移量       
                pos = $t.offset();
                w = $t.outerWidth() - 1;
                h = $t.outerHeight() - 1;
            }
            return [
                 { type: "h", left: pos.left, top: pos.top }, //垂直方向左下对齐线
                 { type: "h", left: pos.left, top: pos.top + h },
                 { type: "v", left: pos.left, top: pos.top },
                 { type: "v", left: pos.left + w, top: pos.top },
                   //您可以添加_any_其他指南在这里就好了（如指南10像素单元的左）
                   { type: "h", left: pos.left, top: pos.top + h / 2 },
                    { type: "v", left: pos.left + w / 2, top: pos.top }
            ];
        }
    </script>--%>

    <script>
        $(function () {
            $(".draggable").draggable({ axis: "y" });
            //$("#draggable2").draggable({ axis: "x" });

            $(".draggable").draggable({ containment: "#contanier", scroll: false });
            //$("#draggable5").draggable({ containment: "parent" });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contanier" style="width:300px;height:300px;background-color:red;overflow:hidden;">
        <!--需要拖动的div-->
        <hr class="draggable" id="d1"/>
        <hr class="draggable"/>
        <%--<div class="draggable"></div>
        <div class="draggable"></div>
        <div class="draggable"></div>
        <div class="draggable"></div>
        <div class="draggable"></div>--%>
        <!--拖动辅助线-->
        <div id="guide-h" class="guide"></div>
        <div id="guide-v" class="guide"></div>
</div>
        <%--作者：赵兴华
链接：https://www.zhihu.com/question/33503958/answer/243362363
来源：知乎
著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。--%>
    </form>
</body>
</html>
