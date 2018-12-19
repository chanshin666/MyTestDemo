<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckLogsTree.aspx.cs" Inherits="WebApplication1.CheckLogsTree" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>查看日志—树形</title>
    <script src="Scripts/jquery-1.4.4.min.js"></script>
    <link href="Content/ZTreeDemo.css" rel="stylesheet" />
    <link href="Content/zTreeStyle/zTreeStyle.css" rel="stylesheet" />
    <script src="Scripts/jquery.ztree.core.js"></script>
    <script src="Scripts/jquery.ztree.exedit.js"></script>
    <script src="Scripts/CheckLogsTree.js"></script>

    <style>
        #LogsTree{
            float:left;
        }
        #Logs{
            float:left;
            width:80%;
            height:auto;
            margin-top: 1%;
            margin-left: 1%;
            padding:10px;
            border:2px dashed #808080;
            word-wrap: break-word
        }
    </style>
</head>
<body>
    <ul id="LogsTree" class="ztree"></ul>
    <div id="Logs">
        请选择在左侧菜单选择具体日志文件
    </div>

</body>
</html>
