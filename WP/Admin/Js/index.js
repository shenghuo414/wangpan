function ZsqAlert(msg,icon)
{
    layer.alert(msg, { icon: icon, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
}

function ZsqAlertCloseAll(msg, icon) {

    layer.alert(msg, { icon: icon, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } }, function () {
        layer.closeAll();
    });
}

function ZsqAlertUrl(msg, icon, url)
{
    var index = layer.alert(msg, { icon: icon, kin: 'layer-ext-moon', closeBtn: 0 }, function () {
        //layer.close(index);
        layer.closeAll();
        $("#main").attr('src', url);
        
    });
}

function ZsqLoading() {
    var index = layer.load(1, {
        shade: [0.6, '#000'] //0.1透明度的白色背景
    });
    return index;
}

function ZsqClose(index) {
    layer.close(index);
}

function ZsqCloseAll() {
    layer.closeAll();
}

function ZsqOpenLayer(url,width,height,title)
{
    var index = layer.open({
        type: 2,
        title: title,
        scrollbar: false,
        shadeClose: false,
        shade: 0.8,
        area: [width, height],
        content: url
    });
    $(".layui-layer-shade").css("z-index", "999");
    $(".layui-layer-iframe").css("z-index", "1000");
    return index;
}