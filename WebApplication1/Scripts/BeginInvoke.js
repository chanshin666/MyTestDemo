$(function () {
    $('#btnAsyncBeginInvoke').click(function () {
        $.ajax({
            //url: 'BeginInvoke.aspx?Action=ASyncInvoke',
            url: 'BeginInvoke.aspx?Action=ASyncInvoke',
            type: 'POST',
            dataType: 'json',
            success: function (msg) {
                $('#content').html(msg.Msg);
            }
        });
    });
})