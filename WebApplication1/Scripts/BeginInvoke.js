$(function () {
    $('#btnAsyncBeginInvoke').click(function () {
        $.ajax({
            //url: 'BeginInvoke.aspx?Action=ASyncInvoke',
            url: 'ajax.ashx?Action=ASyncInvoke',
            type: 'POST',
            dataType: 'json',
            success: function (msg) {
                $('#content').html(msg.Msg);
            }
        });
    });
})