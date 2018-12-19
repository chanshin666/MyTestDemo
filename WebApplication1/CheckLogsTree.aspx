<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckLogsTree.aspx.cs" Inherits="WebApplication1.CheckLogsTree" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看日志—树形</title>
    <script src="Scripts/jquery-1.4.4.min.js"></script>
    <link href="Content/ZTreeDemo.css" rel="stylesheet" />
    <link href="Content/zTreeStyle/zTreeStyle.css" rel="stylesheet" />
    <script src="Scripts/jquery.ztree.core.js"></script>
    <script src="Scripts/jquery.ztree.exedit.js"></script>
    <script src="Scripts/CheckLogsTree.js"></script>

    <style>
        body {
            position: relative;
        }

        #LogsTree {
            float: left;
        }

        #Logs {
            float: left;
            width: 80%;
            height: auto;
            margin-top: 1%;
            margin-left: 1%;
            padding: 10px;
            border: 2px dashed #808080;
            word-wrap: break-word;
        }
        /*#Refresh {
            position:absolute;
            margin-top:28%;
            margin-left:2%;
            width:50px;
            height:50px;
            background: url('/Images/刷新.png') no-repeat;
            background-size:100% 100%;
        }
        #Refresh:hover{
            cursor:pointer;
        }*/
        /*** guide ***/
        .guide {
            width: 60px;
            margin-left: 30px;
            position: fixed;
            left: 0%;
            bottom: 134px;
            _position: absolute;
            _top: expression (documentElement.scrollTop+documentElement.clientHeight - this.clientHeight - 134+'px');
            display: block;
        }

            .guide a {
                display: block;
                width: 60px;
                height: 50px;
                background: url(images/sprite_v4.png) no-repeat;
                margin-top: 10px;
                text- decoration:none;
                font: 16px/50px "Microsoft YaHei";
                text-align: center;
                color: #fff;
                border-radius: 2px;
            }

                .guide a span {
                    display: none;
                    text-align: center;
                }

                .guide a:hover {
                    text-decoration: none;
                    background-color: #39F;
                    color: #fff;
                }

                    .guide a:hover span {
                        display: block;
                        width: 60px;
                        background: #39F;
                    }

            .guide .find {
                background-position: -84px -236px;
            }

            .guide .Refresh {
                background-position: -146px -236px;
            }

            .guide .edit {
                background-position: -83px -185px;
            }

            .guide .top {
                background-position: -145px -185px;
            }
    </style>
</head>
<body>
    <ul id="LogsTree" class="ztree"></ul>

    <div id="Logs">
        请选择在左侧菜单选择具体日志文件
    </div>

    <div class="guide">
        <div class="guide-wrap">
            <a href="#" class="edit" title="开发中"><span>开发中</span></a>
            <a href="#" class="find" title="开发中"><span>开发中</span></a>
            <a href="javascript:void(0);" class="Refresh" title="刷新" id="Refresh"><span>刷新</span></a>
            <a href="javascript:window.scrollTo(0,0)" class="top" title="回顶部"><span>回顶部</span></a>
        </div>
    </div>

</body>
</html>
