$(function () {
    InitFileFolders();

    $("body").on("click", "'.FileUrl", function () {
        var url = $(this).attr('fileurl');
        var type = $(this).attr('fileType');
        if (type == 2) {
            OpenFile(url);
        }
        else {
            BindList("GetAllFileFolders", url);
        }
    });

})

function InitFileFolders() {
    BindList("Init","");
}

function BindList(Action, fileUrl) {
    $('#FileList').html('');
    $.ajax({
        url: 'CheckLogs.aspx?Action=' + Action + '&Url=' + fileUrl,
        type: 'get',
        dataType: 'json',
        success: function (msg) {
            if (msg.totalCount > 0) {
                var str = '<table>';
                $.each(msg.Files, function (i, n) {
                    str += '<tr><td><a href="javascript:void(0);" class="FileUrl" fileurl="' + n.FileName + '" fileType="'+n.FileType+'"> ' + n.FileName + ' </a></td></tr>';
                })
                str += '</table>';
                $('#FileList').html(str);
            }
        },
        error: function (err) {
            alert('请求失败');
        }
    });
}

function OpenFile(fileUrl) {
    $('#FileList').html('');
    $.ajax({
        url: 'CheckLogs.aspx?Action=OpenFile&Url=' + fileUrl,
        type: 'get',
        dataType: 'text',
        success: function (msg) {
            $('#FileList').html(msg);
        },
        error: function (err) {
            alert('请求失败');
        }
    });
}