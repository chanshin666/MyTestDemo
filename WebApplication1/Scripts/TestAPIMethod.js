$(function () {
    $('#btnTest').click(function () {
        layer.load();
        $.ajax({
            url: 'http://192.168.1.173:8088/myapi/User/UserInfoJson',
            type: 'post',
            dataType: 'json',
            success: function (jsondata) {
                //var msg = $.parseJSON(jsondata);
                //alert('用户ID：' + msg.UserID + '，用户名：' + msg.UserName);
                layer.alert('用户ID：' + jsondata.UserID + '，用户名：' + jsondata.UserName, { icon: 6 });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.alert('出错了哇：XMLHttpRequest.status=' + XMLHttpRequest.status + "，XMLHttpRequest.readyState=" + XMLHttpRequest.readyState + "，textStatus=" + textStatus, { icon: 2 });
            },
            complete: function () {
                layer.closeAll('loading');
            }
        });
    });
})