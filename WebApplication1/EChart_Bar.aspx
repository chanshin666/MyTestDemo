<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EChart_Bar.aspx.cs" Inherits="WebApplication1.EChart_Bar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>EChart_Bar</title>
    <!-- 引入 ECharts 文件 -->
    <script src="Scripts/echarts.min.js"></script>
    <script src="Scripts/echarts-gl.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- 为 ECharts 准备一个具备大小（宽高）的 DOM -->
    <div id="main" style="width: 100%;height:600px;"></div>
    </div>
    </form>

    <script type="text/javascript">
        // 基于准备好的dom，初始化echarts实例
        var app = echarts.init(document.getElementById('main'));

        // 指定图表的配置项和数据
        //var option = {
        //    title: {
        //        text: 'ECharts 入门示例'
        //    },
        //    tooltip: {},
        //    legend: {
        //        data:['销量']
        //    },
        //    xAxis: {
        //        data: ["衬衫","羊毛衫","雪纺衫","裤子","高跟鞋","袜子"]
        //    },
        //    yAxis: {},
        //    series: [{
        //        name: '销量',
        //        type: 'bar',
        //        data: [5, 20, 36, 10, 10, 20]
        //    }]
        //};

        var posList = [
    'left', 'right', 'top', 'bottom',
    'inside',
    'insideTop', 'insideLeft', 'insideRight', 'insideBottom',
    'insideTopLeft', 'insideTopRight', 'insideBottomLeft', 'insideBottomRight'
        ];

        app.configParameters = {
            rotate: {
                min: -90,
                max: 90
            },
            align: {
                options: {
                    left: 'left',
                    center: 'center',
                    right: 'right'
                }
            },
            verticalAlign: {
                options: {
                    top: 'top',
                    middle: 'middle',
                    bottom: 'bottom'
                }
            },
            position: {
                options: echarts.util.reduce(posList, function (map, pos) {
                    map[pos] = pos;
                    return map;
                }, {})
            },
            distance: {
                min: 0,
                max: 100
            }
        };

        app.config = {
            rotate: 90,
            align: 'left',
            verticalAlign: 'middle',
            position: 'insideBottom',
            distance: 15,
            onChange: function () {
                var labelOption = {
                    normal: {
                        rotate: app.config.rotate,
                        align: app.config.align,
                        verticalAlign: app.config.verticalAlign,
                        position: app.config.position,
                        distance: app.config.distance
                    }
                };
                myChart.setOption({
                    series: [{
                        label: labelOption
                    }, {
                        label: labelOption
                    }, {
                        label: labelOption
                    }, {
                        label: labelOption
                    }]
                });
            }
        };


        var labelOption = {
            normal: {
                show: true,
                position: app.config.position,
                distance: app.config.distance,
                align: app.config.align,
                verticalAlign: app.config.verticalAlign,
                rotate: app.config.rotate,
                formatter: '{c}  {name|{a}}',
                fontSize: 16,
                rich: {
                    name: {
                        textBorderColor: '#fff'
                    }
                }
            }
        };

        option = {
            color: ['#003366', '#006699', '#4cabce', '#e5323e'],
            tooltip: {
                trigger: 'axis',
                axisPointer: {
                    type: 'shadow'
                }
            },
            legend: {
                data: ['Forest', 'Steppe', 'Desert', 'Wetland']
            },
            toolbox: {
                show: true,
                orient: 'vertical',
                left: 'right',
                top: 'center',
                feature: {
                    mark: { show: true },
                    dataView: { show: true, readOnly: false },
                    magicType: { show: true, type: ['line', 'bar', 'stack', 'tiled'] },
                    restore: { show: true },
                    saveAsImage: { show: true }
                }
            },
            calculable: true,
            xAxis: [
                {
                    type: 'category',
                    axisTick: { show: false },
                    data: ['2012', '2013', '2014', '2015', '2016']
                }
            ],
            yAxis: [
                {
                    type: 'value'
                }
            ],
            series: [
                {
                    name: 'Forest',
                    type: 'bar',
                    barGap: 0,
                    label: labelOption,
                    data: [320, 332, 301, 334, 390]
                },
                {
                    name: 'Steppe',
                    type: 'bar',
                    label: labelOption,
                    data: [220, 182, 191, 234, 290]
                },
                {
                    name: 'Desert',
                    type: 'bar',
                    label: labelOption,
                    data: [150, 232, 201, 154, 190]
                },
                {
                    name: 'Wetland',
                    type: 'bar',
                    label: labelOption,
                    data: [98, 77, 101, 99, 40]
                }
            ]
        };


        // 使用刚指定的配置项和数据显示图表。
        app.setOption(option);
    </script>

</body>
</html>
