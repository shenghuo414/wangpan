function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
$(function () {
    if ($("#DFMoney").length > 0)
    {
        $("#DFMoney").keyup(function () {
            if (this.value.length == 1) { this.value = this.value.replace(/[^1-9]/g, '') } else { this.value = this.value.replace(/\D/g, '') }
        });

        $("#DFMoney").afterpaste(function () {
            if (this.value.length == 1) { this.value = this.value.replace(/[^1-9]/g, '') } else { this.value = this.value.replace(/\D/g, '') }
        });
    }
  


    $("#button1").click(function () {
        
        var cid = GetQueryString("channelid");
        if (cid == "1000015")
        {
            $("#Answer").val("");
            var number = $("#OptionNum").val();
            var astr = "";
            var asflag = "";
            if ($("#QuestionType").val() == "单选题")
            {
                for (i = 1; i <= number; i++)
                {
                    if (i == 1) { astr = $("#appans1" + i).val(); }
                    else { astr += "$$$$" + $("#appans1" + i).val(); }
                    if ($("#dxradio" + i).prop("checked")) {
                        asflag = $("#dxradio" + i).val();
                    }
                }
            }
            else if ($("#QuestionType").val() == "多选题")
            {
                for (i = 1; i <= number; i++) {
                    if (i == 1) { astr = $("#appans2" + i).val(); }
                    else { astr += "$$$$" + $("#appans2" + i).val(); }
                    if ($("#dxcheck" + i).prop("checked")) {
                        if (asflag == "") {
                            asflag = $("#dxcheck" + i).val();
                        }
                        else
                        {
                            asflag += ","+$("#dxcheck" + i).val();
                        }
                    }
                }
            }
            else if ($("#QuestionType").val() == "判断题")
            {
                astr = "正确$$$$错误";
                if ($("#pdradio1").prop("checked"))
                {
                    asflag = $("#pdradio1").val();
                }
                else if ($("#pdradio2").prop("checked"))
                {
                    asflag = $("#pdradio2").val();
                }
            }
            if (astr == "")
            {
                layer.alert('参考答案不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                return false;
            }
            if (asflag == "") {
                layer.alert('正确答案不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                return false;
            }
            $("#Answer").val(asflag);
            $("#AppAnswer").val(astr);
            //alert(asflag);
        }
        //return;
        var data = "";
        data += "channelid=" + escape(cid);
        //console.log(base64decode($("#c").val()));
        var c = base64decode($("#c").val()).split('|');
        for (i = 0; i < c.length; i++)
        {
            var item = c[i].split('$$$');
            if (item[2] == "1")
            {
                if (item[1] == "17" || item[1] == "16" || item[1] == "1" || item[1] == "3" || item[1] == "7" || item[1] == "8" || item[1] == "10" || item[1] == "14" || item[1] == "15")
                {
                    if ($("#" + item[0]).val() == "")
                    {
                        layer.alert($("#span_" + item[0]).html().replace("：", "") + '不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                        return false;
                    }
                }
                else if (item[1] == "2" || item[1] == "13") {
                    if ($("#" + item[0]).val() == "请选择...") {
                        layer.alert($("#span_" + item[0]).html().replace("：", "") + '不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                        return false;
                    }
                }
                else if (item[1] == "4")
                {
                    if (UE.getEditor(item[0]).getContent() == "") {
                        layer.alert($("#span_" + item[0]).html().replace("：", "") + '不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                        return false;
                    }
                }
                else if (item[1] == "5")
                {
                    if ($('input[type=checkbox][name=' + item[0] + ']:checked').length == 0)
                    {
                        layer.alert($("#span_" + item[0]).html().replace("：", "") + '不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                        return false;
                    }
                }
                else if (item[1] == "6") {
                    if ($('input[type=radio][name=' + item[0] + ']:checked').length == 0) {
                        layer.alert($("#span_" + item[0]).html().replace("：", "") + '不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                        return false;
                    }
                }
                else if (item[1] == "9") {
                    if ($("#" + item[0]).html()=="")
                    {
                        layer.alert($("#span_" + item[0]).html().replace("：", "") + '不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                        return false;
                    }
                }
                else if (item[1] == "11") {
                    
                    if ($("#" + item[0]).val() == "") {
                        layer.alert($("#span_" + item[0]).html().replace("：", "") + '不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                        return false;
                    }
                }
                else if (item[1] == "12") {

                    if ($("#" + item[0]).val() == "") {
                        layer.alert($("#span_" + item[0]).html().replace("：", "") + '不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                        return false;
                    }
                }
            }
            //赋值
            if (item[1] == "16" || item[1] == "17" || item[1] == "1" || item[1] == "3" || item[1] == "7" || item[1] == "8" || item[1] == "11" || item[1] == "10" || item[1] == "12" || item[1] == "13" || item[1] == "15")
            {
                if (item[0] == "Title" && cid == "1000018") {
                    data += "&" + item[0] + "=" + escape($("#Year").val() + "年" + $("#" + item[0]).val());
                    data += "&Year=" + escape($("#Year").val());
                    data += "&QiNum=" + escape($("#Title").val());
                }
                else {
                    data += "&" + item[0] + "=" + escape($("#" + item[0]).val());
                }
            }
            else if (item[1] == "14") {
                data += "&" + item[0] + "=" + escape(base64encode($("#" + item[0]).val()));
            }
            else if (item[1] == "9")
            {
                data += "&" + item[0] + "=" + escape($("#" + item[0]).html());
            }
            else if (item[1] == "4")
            {
                data += "&" + item[0] + "=" + escape(UE.getEditor(item[0]).getContent());
            }
            else if (item[1] == "2") {
                data += "&" + item[0] + "=" + escape($("#" + item[0]).val().replace("请选择...",""));
            }
            else if (item[1] == "5") {
                var cv = "";
                $("input[name="+item[0]+"]:checked").each(function (i) {//把所有被选中的复选框的值存入数组
                    if (cv == "") {
                        cv = $(this).val();
                    }
                    else {
                        cv += "," + $(this).val();
                    }
                });
                data += "&" + item[0] + "=" + escape(cv);
            }
            else if (item[1] == "6") {
                var cv = "";
                $("input[name=" + item[0] + "]:checked").each(function (i) {//把所有被选中的复选框的值存入数组
                    cv = $(this).val();
                });
                data += "&" + item[0] + "=" + escape(cv);
            }
        }
        //console.log(data);
        $.ajax({
            type: "POST",
            url: "../Ajax/submit_add.ashx",
            data: data,
            success: function (msg) {
                if (msg == "Parameters Error") {
                    layer.alert('参数错误！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                }
                else if (msg.indexOf("Success")>=0)
                {
                    //var str = "";
                    //if (GetQueryString("channelid") == "1000011")
                    //{
                    //    str = "&infoid=" + $("#TopicInfoID").val();
                    //}
                    layer.alert('操作成功！', { icon: 1, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } }, function () {
                        //alert(GetQueryString("channelid"));
                        if (GetQueryString("channelid") == "1000041") {
                            
                            parent.ZsqCloseAll();
                        }
                        else {
                            location.href = 'ContentManage.aspx?clid=' + $("#ClassID").val() + '&newid=' + msg.split('|')[1] + '&channelid=' + GetQueryString("channelid");
                        }
                    });
                }
                else
                {
                    layer.alert('操作失败！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                }
            },
            error: function (msg) {
                layer.alert('操作失败！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
            }

        });
    });
});

function removeitem(infoid, title, name)
{
    var html = "<a title=\"" + infoid + "\" class=\"entypo-cancel btn btn-red mr10\" onclick=\"removeitem('" + infoid + "','" + title + "','" + name + "')\">" + title + "</a>";
    $("#" + name).val($("#" + name).val().replace(","+infoid,""));
    $("#S_" + name).html($("#S_" + name).html().replace(html,""));
}
function showuser(controlid)
{
    parent.sp('Content/_ChooseUser.aspx?ReturnID='+controlid+'&ReturnValue='+$("#"+controlid).val(), 400, 500, '选择出席人员');
}

function delItem(obj, departid) {
    var hdId = $(obj).parent().parent().find("input[type=hidden]").attr("id");
    var html = "";
    var hidvalue = $("#" + hdId).val().split(',');
    for (i = 0; i < hidvalue.length; i++) {
        if (i == 0) {
            if (hidvalue[i] != departid) {
                html = hidvalue[i];
            }
        }
        else {
            if (hidvalue[i] != departid) {
                if (html != "") {
                    html += "," + hidvalue[i];
                } else {
                    html = hidvalue[i];
                }
            }
        }
    }
    $("#" + hdId).val(html);
    $(obj).remove();
}