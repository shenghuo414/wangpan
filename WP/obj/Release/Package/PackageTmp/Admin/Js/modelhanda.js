function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
$(function () {
    $("#button2").click(function () {
        var index = parent.layer.getFrameIndex(window.name);
        parent.layer.close(index);
    });
    if ($("#QuestionType").length > 0) {
        $("#divAnswer").hide();
        $("#OptionNum>option:eq(0)").remove();
        $("#OptionNum").parent().hide();
        $("#QuestionType").change(function () {
            if ($("#QuestionType").val() == "单选题") {
                $("#verifydiv").hide();
                $("#radiodiv").show();
                $("#checkdiv").hide();
                $("#divAnswer").show();
                $("#OptionNum").parent().show();
            }
            else if ($("#QuestionType").val() == "多选题") {
                $("#verifydiv").hide();
                $("#radiodiv").hide();
                $("#checkdiv").show();
                $("#divAnswer").show();
                $("#OptionNum").parent().show();
            }
            else if ($("#QuestionType").val() == "判断题") {
                $("#verifydiv").show();
                $("#radiodiv").hide();
                $("#checkdiv").hide();
                $("#divAnswer").show();
                $("#OptionNum").parent().hide();
            }
            else {
                $("#divAnswer").hide();
                $("#OptionNum").parent().hide();
            }
        });
        $("#OptionNum").change(function () {
            var number = $("#OptionNum").val();
            for (i = 2; i <= 9; i++) {
                if (i <= parseInt(number)) {
                    $("#l1" + i).show();
                    $("#a11" + i).show();
                    $("#l2" + i).show();
                    $("#a12" + i).show();
                }
                else {
                    $("#l1" + i).hide();
                    $("#a11" + i).hide();
                    $("#l2" + i).hide();
                    $("#a12" + i).hide();
                }
            }
        });
    }

    $("#button1").click(function () {

        var cid = GetQueryString("channelid");
        if (cid == "1000015") {
            $("#Answer").val("");
            var number = $("#OptionNum").val();
            var astr = "";
            var asflag = "";
            if ($("#QuestionType").val() == "单选题") {
                for (i = 1; i <= number; i++) {
                    if (i == 1) { astr = $("#appans1" + i).val(); }
                    else { astr += "$$$$" + $("#appans1" + i).val(); }
                    if ($("#dxradio" + i).prop("checked")) {
                        asflag = $("#dxradio" + i).val();
                    }
                }
            }
            else if ($("#QuestionType").val() == "多选题") {
                for (i = 1; i <= number; i++) {
                    if (i == 1) { astr = $("#appans2" + i).val(); }
                    else { astr += "$$$$" + $("#appans2" + i).val(); }
                    if ($("#dxcheck" + i).prop("checked")) {
                        if (asflag == "") {
                            asflag = $("#dxcheck" + i).val();
                        }
                        else {
                            asflag += "," + $("#dxcheck" + i).val();
                        }
                    }
                }
            }
            else if ($("#QuestionType").val() == "判断题") {
                astr = "正确$$$$错误";
                if ($("#pdradio1").prop("checked")) {
                    asflag = $("#pdradio1").val();
                }
                else if ($("#pdradio2").prop("checked")) {
                    asflag = $("#pdradio2").val();
                }
            }
            if (astr == "") {
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
        for (i = 0; i < c.length; i++) {
            var item = c[i].split('$$$');
            if (item[2] == "1") {
                if (item[1] == "1" || item[1] == "3" || item[1] == "7" || item[1] == "8" || item[1] == "10") {
                    if ($("#" + item[0]).val() == "") {
                        layer.alert($("#span_" + item[0]).html().replace("：", "") + '不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                        return false;
                    }
                }
                else if (item[1] == "2") {
                    if ($("#" + item[0]).val() == "请选择...") {
                        layer.alert($("#span_" + item[0]).html().replace("：", "") + '不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                        return false;
                    }
                }
                else if (item[1] == "4") {
                    if (UE.getEditor(item[0]).getContent() == "") {
                        layer.alert($("#span_" + item[0]).html().replace("：", "") + '不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                        return false;
                    }
                }
                else if (item[1] == "5") {
                    if ($('input[type=checkbox][name=' + item[0] + ']:checked').length == 0) {
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
                    if ($("#" + item[0]).html() == "") {
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
            if (item[1] == "1" || item[1] == "3" || item[1] == "7" || item[1] == "8" || item[1] == "11" || item[1] == "10" || item[1] == "12") {
                data += "&" + item[0] + "=" + escape($("#" + item[0]).val());
            }
            else if (item[1] == "9") {
                data += "&" + item[0] + "=" + escape($("#" + item[0]).html());
            }
            else if (item[1] == "4") {
                data += "&" + item[0] + "=" + escape(UE.getEditor(item[0]).getContent());
            }
            else if (item[1] == "2") {
                data += "&" + item[0] + "=" + escape($("#" + item[0]).val().replace("请选择...", ""));
            }
            else if (item[1] == "5") {
                var cv = "";
                $("input[name=" + item[0] + "]:checked").each(function (i) {//把所有被选中的复选框的值存入数组
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
        $.ajax({
            type: "POST",
            url: "../Ajax/submit_add.ashx",
            data: data,
            success: function (msg) {
                if (msg == "Parameters Error") {
                    layer.alert('参数错误！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                }
                else if (msg.indexOf("Success") >= 0) {
                   
                    layer.alert('操作成功！', { icon: 1, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } }, function () {
                        var index = parent.layer.getFrameIndex(window.name);
                        var iframe = parent.$("#main").contents();
                        var v1 = iframe.find("#HiddenField3").val();
                        var v2 = iframe.find("#HiddenField1").val();
                        //alert(v);
                        if (v1 == "") { iframe.find("#HiddenField3").val(msg.split('|')[1]); }
                        else { iframe.find("#HiddenField3").val(iframe.find("#HiddenField3").val() + "|" + msg.split('|')[1]); }
                        if (v2 == "") { iframe.find("#HiddenField1").val(msg.split('|')[1]); }
                        else { iframe.find("#HiddenField1").val(iframe.find("#HiddenField1").val() + "|" + msg.split('|')[1]); }
                        //iframe.loadlist();
                        $(window.parent.document).contents().find("#main")[0].contentWindow.loadlist();
                        parent.layer.close(index);
                    });
                }
                else {
                    layer.alert('操作失败！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                }
            },
            error: function (msg) {
                layer.alert('操作失败！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
            }

        });
    });
});
function showuser(controlid) {
    parent.sp('Content/_ChooseUser.aspx?ReturnID=' + controlid + '&ReturnValue=' + $("#" + controlid).val(), 400, 500, '选择出席人员');
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