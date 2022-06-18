function getOption(id,title,color,bgcolor)
{
    var option;
    if (id == '1')
    {
        option = {
            title: {
                text: title

            },
            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            xAxis: {
                type: 'category',
                splitLine: { show: false },
                data: []
            },
            yAxis: {
                type: 'value'
            },
            series: [

                {
                    name: title,
                    type: 'bar',
                    stack: '年限',
                    label: {
                        normal: {
                            show: true,
                            position: 'inside'
                        }
                    },
                    data: []
                }
            ]
        };


    }else if (id == '2')
    {
        option = {
            title: {
                text: title,
                x: 'center'
            },
          
          
            xAxis: {
                data: []
            },
            calculable: true,
            series: [
                {
                    name: '漏斗图',
                    type: 'funnel',
                    left: '10%',
                    top: 60,
                    //x2: 80,
                    bottom: 60,
                    width: '80%',
                    // height: {totalHeight} - y - y2,
                    min: 0,
                    max: 100,
                    minSize: '0%',
                    maxSize: '100%',
                    sort: 'descending',
                    gap: 2,
                    label: {
                        normal: {
                            show: true,
                            position: 'inside'
                        },
                        emphasis: {
                            textStyle: {
                                fontSize: 20
                            }
                        }
                    },
                    labelLine: {
                        normal: {
                            length: 10,
                            lineStyle: {
                                width: 1,
                                type: 'solid'
                            }
                        }
                    },
                    itemStyle: {
                        normal: {
                            borderColor: '#fff',
                            borderWidth: 1
                        }
                    },
                    data: []
                }
            ]
        };


    } else if (id == '3')
    {
        option = {
            title: {
                text: title,
          
                x: 'center'
            },
            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b} : {c} ({d}%)"
            },
            legend: {
                orient: 'vertical',
                left: 'left',
                data: []
            },
            series: [
                {
                    name: name,
                    type: 'pie',
                    radius: '55%',
                    center: ['50%', '60%'],
                    data: [],
                    itemStyle: {
                        emphasis: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                        }
                    }
                }
            ]
        };
    }




    return option;
}