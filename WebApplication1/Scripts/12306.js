$(function () {
    document.domain = 'kyfw.12306.cn';
    $('#btnCheck').click(function () {
        //var DateTime = $('#txtDate').val();
        $.ajax({
            url: 'https://kyfw.12306.cn/otn/leftTicket/queryZ',
            type: 'get',
            data: { 'leftTicketDTO.train_date': '2018-02-14', 'leftTicketDTO.from_station': 'SZQ', 'leftTicketDTO.to_station': 'GZG', 'purpose_codes': 'ADULT' },
            dataType: 'json',
            //jsonp: "callback",
            //jsonpCallback: "success_jsonpCallback",
            success: function (msg) {
                var data1 = msg.data;
                alert(data1.flag);
                //var resultData = data1.result;
                //var str = '';
                //$.each(resultData, function (i, n) {
                //    str = str + '<tr><td>' + n + '</td></tr>';
                //});
                //$('#ReturnData').append(str);
            },
            error: function (msg) {
                alert('系统异常');
            }
        });
    });
});