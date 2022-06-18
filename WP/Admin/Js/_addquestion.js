function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
            $(function () {
                $("#ctl00$ContentPlaceHolder1$RadioButtonList1").click(function () {
                    var infoid = GetQueryString("InfoID");
                    location.href = "_HandQuestions.aspx?InfoID=" + infoid;
                });
                $("#ContentPlaceHolder1_yxst").click(function () {
                    $("#div1").show();
                    $("#div2").hide();
                    $("#ContentPlaceHolder1_yxst").addClass("active");
                    $("#ContentPlaceHolder1_ssst").removeClass("active");

                    $.ajax({
                        type: "POST",
                        url: "../Ajax/getresultdata.ashx",
                        data: { infoids: $("#HiddenField1").val(), currentsize: 1 },
                        success: function (msg) {
                            var array = msg.split('@@@');
                            if (array[0] == "操作成功！") {
                                $('#resultdiv').html(array[1]);

                                $("#tcdPageCode2").createPage({
                                    pageCount: array[2],
                                    current: 1,
                                    backFn: function (p) {
                                        showresult(p, "resultdiv");
                                    }
                                });

                            }
                        }, error: function (msg) {
                            layer.alert('获取数据失败！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                        }
                    });
                });
                $("#ContentPlaceHolder1_ssst").click(function () {
                    $("#div2").show();
                    $("#div1").hide();
                    $("#ContentPlaceHolder1_ssst").addClass("active");
                    $("#ContentPlaceHolder1_yxst").removeClass("active");
                });
                $("#searchbut").click(function () {
                    if ($("#ctl00$ContentPlaceHolder1$DropDownList1").val() == "请选择...") {
                        layer.alert('请选择题库分类！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                    }
                    else {
                        var questiontype = "";
                        if ($("#ContentPlaceHolder1_CheckBoxList1_0").prop("checked"))
                        {
                            questiontype = "'多选题'";
                        }
                        if ($("#ContentPlaceHolder1_CheckBoxList1_1").prop("checked")) {

                            if (questiontype == "") { questiontype = "'单选题'"; }
                            else { questiontype += ",'单选题'";}
                        }
                        if ($("#ContentPlaceHolder1_CheckBoxList1_2").prop("checked")) {

                            if (questiontype == "") { questiontype = "'判断题'"; }
                            else { questiontype += ",'判断题'"; }
                        }
                        if (questiontype == "") {
                            layer.alert('请至少选择一种题目类型！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                            return;
                        }
                        $("#HiddenField2").val(questiontype);
                        $("#div2").show();
                        $("#div1").hide();
                        $("#ContentPlaceHolder1_ssst").addClass("active");
                        $("#ContentPlaceHolder1_yxst").removeClass("active");
                        $.ajax({
                            type: "POST",
                            url: "../Ajax/getcachedata.ashx",
                            data: { qtype: $("#ContentPlaceHolder1_DropDownList1").val(), currentsize: 1,infoids:$("#HiddenField1").val(),questiontype:questiontype },
                            success: function (msg) {
                                var array = msg.split('@@@');
                                if (array[0] == "操作成功！") {
                                    $('#searchdiv').html(array[1]);
                                    checkin();
                                    $("#tcdPageCode1").createPage({
                                        pageCount: array[2],
                                        current: 1,
                                        backFn: function (p) {
                                            showdata(p, "searchdiv");
                                               
                                        }
                                    });
                                    
                                }
                            }, error: function (msg) {
                                layer.alert('获取数据失败！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                            }
                        });
                    }
                });
            });

function removeresult(obj, infoid) {
    $(obj).parent().parent().remove();
    var str = "|" + $("#HiddenField1").val() + "|";
    str = str.replace("|" + infoid + "|", "|");
    str = str.substring(1);
    str = str.substring(0, str.length - 1);
    $("#HiddenField1").val(str);
    if ($("#Chk" + infoid).length > 0) {
        $("#Chk" + infoid).prop("checked", false);
    }
}
function checkin()
{
    var flag = true;
    $("input[name='ckb']").each(function () {
        if ($(this).prop("checked")) { }
        else { flag = false;}
    });
    //alert(flag);
    if (flag == false) { $("#Checkbox2").prop("checked", false); }
    else { $("#Checkbox2").prop("checked", true); }
}
function chkall()
{
    var str = "|" + $("#HiddenField1").val() + "|";
    if ($("#Checkbox2").prop("checked"))
    {
        $("input[name='ckb']").each(function () {
            $(this).prop("checked", true);
            var infoid = "|" + $(this).attr("id").replace("Chk", "") +"|";
            if (str.indexOf(infoid) < 0)
            {
                if ($("#HiddenField1").val() == "")
                {
                    $("#HiddenField1").val($(this).attr("id").replace("Chk", ""));
                }
                else
                {
                    $("#HiddenField1").val($("#HiddenField1").val() + "|" + $(this).attr("id").replace("Chk", ""));
                }
            }
        });
    }
    else
    {
        $("input[name='ckb']").each(function () {
            $(this).prop("checked", false);
            var infoid = "|" + $(this).attr("id").replace("Chk", "") + "|";
            if (str.indexOf(infoid) >= 0) {
                str = str.replace( infoid , "|");
                            
            }
        });
        str = str.substring(1);
        str = str.substring(0, str.length - 1);
        $("#HiddenField1").val(str);
    }
}

function setcache(obj)
{
    if ($(obj).prop("checked")) {
        var infoid = $(obj).attr("id").replace("Chk", "");
        //var content = $(obj).attr("cv");
        if ($("#HiddenField1").val() == "") {
            $("#HiddenField1").val(infoid);
        }
        else {
            $("#HiddenField1").val($("#HiddenField1").val() + "|" + infoid);
        }
    }
    else
    {
        var str = "|" + $("#HiddenField1").val() + "|";
        var infoid = $(obj).attr("id").replace("Chk", "");
        str = str.replace("|" + infoid + "|", "|");
        str = str.substring(1);
        str = str.substring(0, str.length - 1);
        $("#HiddenField1").val(str);
    }
}
function showdata(currentpage, searchdiv) {
    $.ajax({
        type: "POST",
        url: "../Ajax/getcachedata.ashx",
        data: { qtype: $("#ContentPlaceHolder1_DropDownList1").val(), currentsize: currentpage, infoids: $("#HiddenField1").val(), questiontype: $("#HiddenField2").val() },
        success: function (msg) {
            var array = msg.split('@@@')
            if (array[0] == "操作成功！") {
                $('#' + searchdiv).html(array[1]);
                checkin();
            }
            else {
                layer.alert("获取数据失败！", { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
            }
        },
        error: function (msg) {
            layer.alert('获取数据失败！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
        }
    });
}
function showresult(currentpage, searchdiv) {
    $.ajax({
        type: "POST",
        url: "../Ajax/getresultdata.ashx",
        data: { infoids: $("#HiddenField1").val(), currentsize: currentpage },
        success: function (msg) {
            var array = msg.split('@@@')
            if (array[0] == "操作成功！") {
                $('#' + searchdiv).html(array[1]);
            }
            else {
                layer.alert("获取数据失败！", { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
            }
        },
        error: function (msg) {
            layer.alert('获取数据失败！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
        }
    });
}
function saveresult()
{
    if ($("#HiddenField1").val() == "")
    {
        layer.alert('操作失败，请至少选择一道试题！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
    }
    else
    {
        var infoid = GetQueryString("InfoID");
        $.ajax({
            type: "POST",
            url: "../Ajax/setresultdata.ashx",
            data: { infoids: $("#HiddenField1").val(), infoid: infoid },
            success: function (msg) {
                if (msg == "操作成功！") {
                    layer.alert('操作成功！', { icon: 1, kin: 'layer-ext-moon', closeBtn: 0 }, function () { location.href = 'ContentManage.aspx?channelid=1000017'; });
                }
                else {
                    layer.alert(msg, { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                }
            },
            error: function (msg) {
                layer.alert('操作失败！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
            }
        });
    }
}
