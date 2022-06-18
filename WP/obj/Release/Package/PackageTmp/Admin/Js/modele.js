$(function () {
    if ($("#DFMoney").length > 0) {
        $("#DFMoney").keyup(function () {
            if (this.value.length == 1) { this.value = this.value.replace(/[^1-9]/g, '') } else { this.value = this.value.replace(/\D/g, '') }
        });

        $("#DFMoney").afterpaste(function () {
            if (this.value.length == 1) { this.value = this.value.replace(/[^1-9]/g, '') } else { this.value = this.value.replace(/\D/g, '') }
        });
    }
   
    if ($("#HaveDuoTu").val() != "") {
        var apic = $("#" + base64decode($("#HaveDuoTu").val())).val().split(',');
        if ($("#" + base64decode($("#HaveDuoTu").val())).val().indexOf(',') < 0) {
            apic = new Array($("#" + base64decode($("#HaveDuoTu").val())).val());
        }
        var start = 100;
        var array_picnumber = "";
        for (i = 0; i < apic.length; i++) {
            if (array_picnumber == "") { array_picnumber = start; }
            else { array_picnumber += "," + start; }
            start++;
        }
        var apicnum = new Array();
        try {
            apicnum = array_picnumber.split(',');
        }
        catch (E) {

        }
        if (array_picnumber.toString().indexOf(',') < 0) {
            apicnum = new Array(array_picnumber);
        }
        var html = "";
        for (i = 0; i < apic.length; i++) {
            if (apic[i] != "") {
                html += "<div id=\"uploadList_" + apicnum[i] + "\" class=\"upload_append_list\"><div class=\"file_bar\"><div style=\"padding:5px;\"><p class=\"file_name\" title=\"" + apic[i] + "\">" + apic[i] + "</p><span class=\"file_edit\" data-index=\"" + apicnum[i] + "\" title=\"编辑\"></span><span class=\"file_del\" data-index=\"" + apicnum[i] + "\" title=\"删除\"></span></div>	</div>	<a style=\"height:115px;width:140px;\" href=\"#\" class=\"imgBox\">	<div class=\"uploadImg\" style=\"width:125px;max-width:125px;max-height:105px;\"><img id=\"uploadImage_" + apicnum[i] + "\" class=\"upload_image\" src=\"" + apic[i].replace("~", "../../..") + "\" style=\"width:expression(this.width > 125 ? 125px : this.width);\">		</div>	</a>	<p id=\"uploadProgress_" + apicnum[i] + "\" class=\"file_progress\" style=\"display: none; width: 100%;\"></p>	<p id=\"uploadFailure_" + apicnum[i] + "\" class=\"file_failure\">上传失败，请重试</p>	<p id=\"uploadTailor_" + apicnum[i] + "\" class=\"file_tailor\" tailor=\"false\" style=\"display: none;\">裁剪完成</p>	<p id=\"uploadSuccess_" + apicnum[i] + "\" class=\"file_success\" title=\"" + apic[i] + "\" style=\"display: block;\"></p></div>";
                console.log(html);
            }
        }
        $("#preview").append(html);
    }
    $(".upload_append_list").mouseover(function () {
        var number = this.id.replace("uploadList_", "");
        if (number > 99) {
            $("#" + this.id + " .file_bar").addClass("file_hover");
        }
    });
    $(".upload_append_list").mouseout(function () {
        $(".file_bar").removeClass("file_hover");
    });
    $(".file_del").click(function () {
        $(this).parent().parent().parent().hide();
    });
});
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
$(function () {

    $("#button1").click(function () {

        try {
            if ($("#HaveDuoTu").val() != "") {


                var filename = "";
                $('.upload_append_list').each(function (i) {

                    var number = this.id.replace("uploadList_", "");
                    if ($("#uploadSuccess_" + number).css("display") == "block") {
                        if ($(this).css("display") == "block") {
                            if (filename == "") { filename = $("#uploadSuccess_" + number).attr("title"); }
                            else { filename += "," + $("#uploadSuccess_" + number).attr("title"); }
                        }
                    }
                    if ($("#uploadSuccess_" + number).css("display") == "none" && $(this).css("display") == "block") {
                        flag++;
                    }
                });
                $("#" + base64decode($("#HaveDuoTu").val())).val(filename);
            }
        } catch (E) { }

        var cid = GetQueryString("channelid");


        var data = "";
        data += "infoid=" + escape(GetQueryString("infoid")) + "&channelid=" + escape(GetQueryString("channelid"));
        
        var c = base64decode($("#c").val()).split('|');
        
        

        for (i = 0; i < c.length; i++)
        {
            var item = c[i].split('$$$');
            if (item[2] == "1")
            {
                if (item[1] == "17" || item[1] == "16" || item[1] == "1" || item[1] == "3" || item[1] == "7" || item[1] == "8" || item[1] == "12" || item[1] == "10" || item[1] == "14" || item[1] == "15")
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
            }

            //赋值
            if (item[1] == "17" || item[1] == "16" || item[1] == "1" || item[1] == "3" || item[1] == "7" || item[1] == "8" || item[1] == "11" || item[1] == "12" || item[1] == "10" || item[1] == "13" || item[1] == "15")
            {
                if ((item[0] == "Content" || item[0] == "Zhuliao" || item[0] == "Fuliao") && cid == "1000060") {
                    //data += "&" + item[0] + "=" + escape($("#Year").val() + "年" + $("#" + item[0]).val());
                    //data += "&Year=" + escape($("#Year").val());
                    //data += "&QiNum=" + escape($("#Title").val());
                    if (item[0] == "Zhuliao")
                    {
                        var cv = "";
                        var cs = 0;
                        $(".CTable").eq(0).find("tbody").find("tr").each(function () {
                            cs++;
                            if (cs > 1) {
                                var vi = $(this).find("td").eq(0).find(".text1").val();
                                var vv = $(this).find("td").eq(1).find(".text1_1").val();
                                cv += "###" + vi + "@@@" + vv;
                            }
                        });
                        if (cv != "") { cv = cv.substring(3); }
                        data += "&Zhuliao=" + escape(cv);
                    }
                    else if (item[0] == "Fuliao")
                    {
                        var cv = "";
                        var cs = 0;
                        $(".CTable").eq(1).find("tbody").find("tr").each(function () {
                            cs++;
                            if (cs > 1) {
                                var vi = $(this).find("td").eq(0).find(".text2").val();
                                var vv = $(this).find("td").eq(1).find(".text2_1").val();
                                cv += "###" + vi + "@@@" + vv;
                            }
                        });
                        if (cv != "") { cv = cv.substring(3); }
                        data += "&Fuliao=" + escape(cv);
                    }
                    else
                    {
                        var cv = "";
                        var cs = 0;
                        $(".CTable").eq(2).find("tbody").find("tr").each(function () {
                            cs++;
                            if (cs > 1) {
                                var vi = $(this).find("td").eq(0).find("img").attr("src");
                                var vv = $(this).find("td").eq(1).find(".area1").val();
                                cv += "###" + vi + "@@@" + vv;
                            }
                        });
                        if (cv != "") { cv = cv.substring(3); }
                        data += "&Content=" + escape(cv);
                    }
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
        if (escape(GetQueryString("channelid")) == "1000034") {
            data += "&classid=" + $("#ClassID").val();
            if ($("input[name='Flag']:checked").val() == "审核失败") {
                data += "&deltf=2";
            }
            else {
                data += "&deltf=1";
            }
        }
       
            //data += "&classid=" + base64decode($("#CSID").val());
        
        

        $.ajax({
            type: "POST",
            url: "../Ajax/submit_edit.ashx",
            data: data,
            success: function (msg) {
                if (msg == "Parameters Error") {
                    layer.alert('参数错误！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                } else if (msg == "Success") {
                    layer.alert('操作成功！', { icon: 1, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } }, function () {
                        if (GetQueryString("channelid") == "1000042") {
                            //Content/EditContent.aspx?action=edit&channelid=1000042&infoid=1459
                            //document.reload();
                            window.location.reload()
                        }
                        else {
                            location.href = 'ContentManage.aspx?newid=' + GetQueryString("infoid") + '&clid=' + $("#ClassID").val() + '&channelid=' + GetQueryString("channelid");
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