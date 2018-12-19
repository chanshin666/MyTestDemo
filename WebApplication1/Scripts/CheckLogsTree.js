var setting = {
    //显示
    view: {
        selectedMulti: false, //在复制的时候，是否允许选中多个节点。true为支持，按下ctrl键生效，false不支持。
        dblClickExpand: true, //双击的时候是否切换展开状态。true为切换，false不切换
        fontCss: { color: "red" }  //设置节点的颜色
    },
    //增删改，移动复制
    edit: {
        enable: false, //如果enable为flase，那么树就不能移动了
        showRemoveBtn: false, //是否显示树的删除按钮
        showRenameBtn: false, //是否显示数的重命名按钮
        isSimpleData: false, //数据是否采用简单 Array 格式，默认false
        treeNodeKey: "id",  //在isSimpleData格式下，当前节点id属性
        treeNodeParentKey: "parentId",//在isSimpleData格式下，当前节点的父节点id属性
        showLine: true, //是否显示节点间的连线
        removeTitle: "删除节点",//删除Logo的提示
        renameTitle: "编辑节点",//修改Logo的提示
        //拖拽
        drag: {
            isCopy: false,//能够复制
            isMove: false,//能够移动
            prev: false,//不能拖拽到节点前
            next: false,//不能拖拽到节点后
            inner: true//只能拖拽到节点中
        }
    },
    //异步
    async: {
        enable: true, //开启异步加载
        type: "get",
        url: "CheckLogsTree.aspx?Action=GetAllFileFolders",
        contentType: "application/x-www-form-urlencoded",
        autoParam: ["fileUrl=Url"], //异步加载数据，自动添加id参数，会自动获取当前节点的id值
        dataFilter: null, //过滤，跟easy-ui中的loadFilter方法一样。
        otherParam:null //{ "id": "1", "code_name": "固网测试" }提交的时候就会提交参数id=1&code_name=固网测试
    },
    data: {
        key: {
            name: "name" //节点显示的值
        },
        //
        simpleData: {
            enable: false,//如果为true，可以直接把从数据库中得到的List集合自动转换为Array格式。而不必转换为json传递
            idKey: "id",//节点的id
            pIdKey: "parentId",//节点的父节点id
            rootPId: null
        }
    },
    //回调函数
    callback: {
        beforeClick: function (treeId, treeNode) {//点击前
            if (treeNode.isParent) {
                return true;
            } else {
                $('#Logs').html('');
                $.ajax({
                    url: "CheckLogsTree.aspx?Action=OpenFile&Url=" + treeNode.fileUrl,
                    type: "post",
                    dataType: "text",
                    success: function (data) {
                        //console.log(data);
                        $('#Logs').html(data);
                    },
                    error: function () {
                        alert('读取出错');
                    }
                });
            }
        },
        //beforeDrag: beforeDrag,//拖拽之前
        //beforeDrop: beforeDrop,//拖拽结束
        //onDrop: zTreeOnDrop,//拖拽结束后
        //onDrag: zTreeOnDrag,//拖拽的时候
        //beforeRemove: zTreeBeforeRemove,//删除节点前
        //onRemove: zTreeOnRemove,//节点删除之后
        //beforeEditName: zTreeBeforeEditName,//进行编辑之前
        //beforeRename: zTreeBeforeRename,//重命名节点之前
        //onRename: zTreeOnRename,//重命名之后
        //onClick: onClick, //点击
        onRightClick: function () {//右键
            return false;
        },
        //onAsyncSuccess: zTreeOnAsyncSuccess//异步加载
        //beforeExpand: beforeExpand,//展开节点前
        //onAsyncSuccess: function () {//异步数据加载成功的回调
        //    alert('异步回调成功');
        //},
        onAsyncError: function () {//异步数据加载错误后回调
            alert('异步回调失败');
        }
    }

};

var zNodes = [
        {
            name: "父节点1 - 展开", open: true,
            children: [
                {
                    name: "父节点11 - 折叠",
                    children: [
                        { name: "叶子节点111" },
                        { name: "叶子节点112" },
                        { name: "叶子节点113" },
                        { name: "叶子节点114" }
                    ]
                },
                {
                    name: "父节点12 - 折叠",
                    children: [
                        { name: "叶子节点121" },
                        { name: "叶子节点122" },
                        { name: "叶子节点123" },
                        { name: "叶子节点124" }
                    ]
                },
                { name: "父节点13 - 没有子节点", isParent: true }
            ]
        },
			{
			    name: "父节点2 - 折叠",
			    children: [
					{
					    name: "父节点21 - 展开", open: true,
					    children: [
							{ name: "叶子节点211" },
							{ name: "叶子节点212" },
							{ name: "叶子节点213" },
							{ name: "叶子节点214" }
					    ]
					},
					{
					    name: "父节点22 - 折叠",
					    children: [
							{ name: "叶子节点221" },
							{ name: "叶子节点222" },
							{ name: "叶子节点223" },
							{ name: "叶子节点224" }
					    ]
					},
					{
					    name: "父节点23 - 折叠",
					    children: [
							{ name: "叶子节点231" },
							{ name: "叶子节点232" },
							{ name: "叶子节点233" },
							{ name: "叶子节点234" }
					    ]
					}
			    ]
			},
			{ name: "父节点3 - 没有子节点", isParent: true }
];


$(function () {

    initZTree();
    
    //zTreeObj = $.fn.zTree.init($("#LogsTree"), setting, zNodes);//如果一开始就异步的话，第三个参数为null就行；
})

function initZTree() {
    $.ajax({
        url: "CheckLogsTree.aspx?Action=Init",
        type: "post",
        dataType: "json",
        success: function (data) {
            console.log(data);
            var zTreeObj = $.fn.zTree.init($("#LogsTree"), setting, data);
        },
        error: function () {

        }
    });
}

