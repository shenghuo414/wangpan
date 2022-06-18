$(function () {

    $("#xgbutton").click(function () {
        var data = {
            password: $("#password").val(),
            pic: $("#touxiang").attr("src"),
            classid: 96,
            channelid:1000054
        };
        if ($("#password").val() == "") {
            layer.alert('请输入账号密码！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
        }
        else
        {
            $.ajax({
                type: "POST",
                url: "/Template/PC/js/pwd.ashx",
                data: data,
                success: function (mess) {
                    if (mess == "密码修改成功！") {
                        layer.alert(mess, { icon: 1, kin: 'layer-ext-moon', closeBtn: 0 });
                    }
                    else {
                        layer.alert(mess, { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
                    }
                }
            });
        }
    });

    if ($(".jiahao").length > 0)
    {
        $(".jiahao").click(function () {
            $(".zhuliao").append("<div class=\"zlitem\"><input type=\"text\" class=\"text1\" value=\"\" placeholder=\"食材名\" ><input type=\"text\" class=\"text1_1\" value=\"\"  placeholder=\"用量\" ><div class=\"chahao\" onclick=\"gb(this)\" ></div></div>");
        });
    }
    if ($(".fljiahao").length > 0) {
        $(".fljiahao").click(function () {
            $(".flzhuliao").append("<div class=\"flitem\"><input type=\"text\" class=\"text2\" value=\"\" placeholder=\"食材名\" ><input type=\"text\" class=\"text2_1\" value=\"\"  placeholder=\"用量\" ><div class=\"chahao\" onclick=\"gb(this)\" ></div></div>");
        });
    }

    if ($(".bzjiahao").length > 0)
    {
        $(".bzjiahao").click(function () {
            var id = "1";
            $(".bzzhuliao").find("img").each(function () {
                id = $(this).attr("id").replace("Img", "");
            });
            id = parseInt(id) + 1;
            var html = "<div class=\"bzitem\"><button type=\"button\" class=\"bzbtn\" id=\"Button"+id+"\"><i class=\"zdyicon\">&#xe67c;</i>上传图片</button>";
                html += "<img src=\"\" id=\"Img"+id+"\" class=\"scimg\" >";
                html += "<textarea id=\"Textarea"+id+"\" class=\"area1\" placeholder=\"请输入做法说明菜品描述\"></textarea><div class=\"chahao\" onclick=\"gb(this)\" ></div></div>";
                $(".bzzhuliao").append(html);

                layui.use('upload', function () {
                    var upload4 = layui.upload;

                    //执行实例
                    var uploadInst = upload4.render({
                        elem: '#Button'+id //绑定元素
                      , url: '/Upload.ashx' //上传接口
                      , done: function (res) {
                          //上传完毕回调

                          //$("#cptx").show();
                          //$("#cptx").attr("src", res.url);
                          $("#Button"+id).hide();
                          $("#Button"+id).parent().find("img").attr("src", res.url);
                          $("#Button"+id).parent().find("img").show();
                      }
                      , error: function () {
                          //请求异常回调
                      }
                    });
                });
        });
    }

    if ($("#fbbutton").length > 0)
    {
        $("#fbbutton").click(function () {
            var data = "channelid=1000060&classid=";
            if ($("#title").val() == "")
            {
                layer.alert("菜谱名称不能为空！", { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
            }
            else if ($("#classid").val() == "0")
            {
                layer.alert("菜谱分类不能为空！", { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
            }
            else if ($("#cptx").attr("src") == "/UploadFiles/files/tx.png") {
                layer.alert("菜谱图片不能为空！", { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
            }
            else if ($("#nandu").val() == "0") {
                layer.alert("难度不能为空！", { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
            }
            else if ($("#kouwei").val() == "0") {
                layer.alert("口味不能为空！", { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
            }
            else if ($("#gongyi").val() == "0") {
                layer.alert("工艺不能为空！", { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
            }
            else if ($("#haoshi").val() == "0") {
                layer.alert("耗时不能为空！", { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
            }
            else if ($("#chuju").val() == "0") {
                layer.alert("厨具不能为空！", { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
            }
            else
            {
                data += $("#classid").val() + "&intro=" + escape($("#intro").val()) + "&pic=" + $("#cptx").attr("src");
                data += "&nandu=" + escape($("#nandu").val()) + "&kouwei=" + escape($("#kouwei").val()) + "&gongyi=" + escape($("#gongyi").val());
                data += "&haoshi=" + escape($("#haoshi").val()) + "&chuju=" + escape($("#chuju").val());
                data += "&title=" + escape($("#title").val()) + "&qiaomen=" + escape($("#qiaomen").val());
                var zl = "";
                $(".zhuliao").find(".zlitem").each(function () {
                    if ($(this).find(".text1").val() != "")
                    {
                        zl += "###" + $(this).find(".text1").val() + "@@@" + $(this).find(".text1_1").val();
                    }
                });
                if (zl != "") { zl = zl.substring(3); }
                data += "&zhuliao=" + escape(zl);
                var fl = "";
                $(".flzhuliao").find(".flitem").each(function () {
                    if ($(this).find(".text2").val() != "") {
                        fl += "###" + $(this).find(".text2").val() + "@@@" + $(this).find(".text2_1").val();
                    }
                });
                if (fl != "") { fl = fl.substring(3); }
                data += "&fuliao=" + escape(fl);
                var bz = "";
                $(".bzzhuliao").find(".bzitem").each(function () {
                    if ($(this).find(".area1").val() != "") {
                        bz += "###" + $(this).find(".scimg").attr("src") + "@@@" + $(this).find(".area1").val();
                    }
                });
                if (bz != "") { bz = bz.substring(3); }
                data += "&content=" + escape(bz);
                //console.log(data);

                $.ajax({
                    type: "POST",
                    url: "/Template/PC/js/caipu.ashx",
                    data: data,
                    success: function (mess) {
                        if (mess == "发布成功！") {
                            layer.open({
                                content: mess,
                                closeBtn: 0,
                                icon: 1,
                                kin: 'layer-ext-moon',
                                yes: function (index, layero) {
                                    location.href = "UserInfo.aspx";
                                }
                            });
                        }
                        else {
                            layer.alert(mess, { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
                        }
                    }
                });

            }
        });
    }
});
function gb(obj)
{
    $(obj).parent().remove();
}

function showurl(infoid, flag)
{
    if (flag == "已审核")
    {
        location.href = infoid + ".html";
    }
}

function scpl(infoid,obj)
{
    layer.confirm("确定删除评论？", {
        skin: 'layer-ext-moon',
        closeBtn: 0,//样式类名
        btn: ['确定', '取消'] //按钮
    }, function () {
        $.ajax({
            type: "POST",

            url: "ajax/scpl.ashx",
            data: { infoid: infoid },
            success: function (msg) {
                if (msg == "操作成功！") {
                    $(obj).parent().parent().parent().remove();
                    layer.msg('删除评论成功！', { icon: 1 });
                }
                else if (msg == "NoLogin")
                {
                    location.href="c112.html";
                }
                else {
                    layer.msg('删除评论失败！', { icon: 5 });
                }
            },
            error: function (msg) {
                layer.msg('删除评论失败！', { icon: 5 });
            }
        });
    }, function () {

    });

}

function qxsc(infoid, obj) {
    layer.confirm("确定取消收藏？", {
        skin: 'layer-ext-moon',
        closeBtn: 0,//样式类名
        btn: ['确定', '取消'] //按钮
    }, function () {
        $.ajax({
            type: "POST",

            url: "ajax/qxsc.ashx",
            data: { infoid: infoid },
            success: function (msg) {
                if (msg == "操作成功！") {
                    $(obj).parent().parent().parent().remove();
                    layer.msg('取消收藏成功！', { icon: 1 });
                }
                else if (msg == "NoLogin") {
                   
                    location.href = "c112.html";
                }
                else {
                    layer.msg('取消收藏失败！', { icon: 5 });
                }
            },
            error: function (msg) {
                layer.msg('取消收藏失败！', { icon: 5 });
            }
        });
    }, function () {

    });

}