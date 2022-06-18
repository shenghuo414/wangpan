<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LookFile.aspx.cs" Inherits="Food.LookFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Template/PC/js/jquery-1.11.0.min.js"></script>
    <script src="Template/PC/js/layui/layui.all.js"></script>
     <link href="/Template/PC/js/layui/css/layui.css" rel="stylesheet">
    <style>
        .Ctd a.showBtn{background-position:-328px -190px;}
        .default-small {
    background-position: -596px -566px;
}
.default-small {
    background-repeat: no-repeat;
}.fileicon-small-pic {
    background-position: -596px -306px;
}

.fileicon-small-pic {
    background-repeat: no-repeat;
}
.fileicon-small-zip {
    background-position: -596px -1664px;
}
.fileicon-small-zip {
    background-repeat: no-repeat;
}
.fileicon-sys-s-ipa, .fileicon-sys-s-vsd, .fileicon-sys-s-pages, .fileicon-sys-s-numbers, .fileicon-sys-s-fonts, .fileicon-sys-s-code, .fileicon-sys-s-web, .fileicon-sys-s-links, .fileicon-sys-s-eps, .fileicon-sys-s-swf, .fileicon-sys-s-video, .fileicon-small-video, .fileicon-small-zip, .fileicon-small-rar {
    background-image: url(/images/icons_z_6ae3d28.png);
}
        .button{
                display: inline-block;
    line-height: 42px;
    padding: 0 18px;
    background-color: #09AAFF;
    color: #fff;
    white-space: nowrap;
    text-align: center;
    font-size: 12px;
    border: none;
    border-radius: 2px;
    cursor: pointer;
    margin: auto;
    width: 80px;
    border-radius: 4px;
    border: 1px solid #09AAFF;
        }
        .topdiv{
            left: 0;
                padding-top: 15px;
    width: 100%;
    font-size: 14px;
    z-index: 99999;
    text-indent: 10px;
    height:48px;
        }
        .g-dropdown-button {
 
    margin: 0 5px;
    vertical-align: top;
}.g-button:link, .g-button:visited {
    color: #09AAFF;
}
 .g-dropdown-button .g-button, .g-dropdown-button .menu {
    padding: 10px 20px 10px 20px;
    margin: 0!important;
    list-style: none;
    z-index: 1;
}.g-button-blue {
    border: 1px solid #09AAFF;
    background-color: #09AAFF;
}.g-button {
    text-decoration: none;
 
    border-radius: 4px;
    height: 32px;
    line-height: 32px;
}.icon-upload:before {
    content: "\e915";
}.g-button-blue .icon {
    color: #fff;
}

.g-button .icon {
    line-height: 28px;
    font-size: 16px;
    height: 31px;
    margin-right: 0;
}

.g-button .icon {
    display: inline-block;
    width: 20px;
    height: 24px;
    margin-right: 4px;
    vertical-align: middle;
}
 .g-button-right {
    height: 32px;
    line-height: 32px;

    text-align: center;
    cursor: pointer;
}
 .g-button {
    text-decoration: none;
    color: #09AAFF;
    border: 1px solid #C3EAFF;
    border-radius: 4px;
    height: 32px;
    line-height: 32px;
    padding-left: 10px;
}
        .ctr {
            height:45px;line-height:45px;
            border-bottom:1px solid #f7f7f7; 
        }
        .ctr td{
            padding-left:20px;
        }
        .Ctd a.delete {
    background-position: -213px -170px;
}
        .Ctd a.backgj {
    background-position: -296px -213px;
}
.Ctd  a.edit, a.delete, a.del, a.copy, a.apply, a.ok, a.no, a.money, a.preview, a.backBtn, a.showBtn, a.backgj, a.verify, a.create, a.print, a.rename {
    display: inline-block;
    width: 18px;
    height: 0;
    padding-top: 18px;
    overflow: hidden;
    background: url(/Admin/images/all_icon.png) no-repeat 0 0;
    vertical-align: middle;
    margin: 0 4px;
}

a:hover {
    text-decoration: none;
    color: #50869f;
}
.ucpyE234 {
    cursor: default;
    display: block;
    height: 26px;
    width: 26px;
    display: inline-block;
margin-bottom:-10px;
margin-top:10px
}
.fileicon-small-bt, .fileicon-small-dws, .fileicon-small-code, .fileicon-small-txt, .fileicon-small-pdf, .fileicon-small-doc, .fileicon-small-ppt, .fileicon-small-xls, .fileicon-small-vsd, .fileicon-small-pic, .fileicon-small-mmap, .fileicon-small-xmind, .fileicon-small-mm, .fileicon-small-mp3, .icon-play-music, .default-small, .dir-multi-small, .dir-multi-middle, .dir-small, .dir-cang-small, .dir-app-small, .dir-apps-small, .dir-backup-small, .dir-share-middle, .dir-phone-small, .fileicon-sys-s-exe, .fileicon-sys-s-apk, .fileicon-sys-s-psd, .fileicon-sys-s-key, .fileicon-sys-s-ai {
    background-image: url(/Images/icons_z_6ae3d28.png);
}
.dir-small {
    background-position: -594px -862px;
}
.dir-small {
    background-repeat: no-repeat;
}

    </style>
</head>
<body style="background:#fff;">
    <form id="form1" runat="server">
        <div class="topdiv">
            <span class="g-dropdown-button" style="display: inline-block;">
                <a class="g-button g-button-blue blue-upload upload-wrapper"href="javascript:sc();" title="上传">
                    <span class="g-button-right">
                        <span class="text" style="width: 40px;color:#fff">上传</span>
                    </span>
                </a>
            </span>
            <a class="g-button"  href="javascript:showwb();" title="新建文件夹" style=" text-indent: 0px;
    padding:10px 10px;">
                <span class="g-button-right">
                
                    <span class="text" style="width: auto;">新建文件夹</span>
                </span>

            </a>
        </div>
        <div style="width:100%;">
            <div style="    width: 60%;
    float: left;
    padding-left: 20px;">全部文件</div>
            <div style="width:30%;float:right;    text-align: right;
    margin-right: 20px;">已全部加载，共<asp:Literal ID="Literal1" runat="server"></asp:Literal>个</div>
            <div style="clear:both"></div>
            <table border="0" cellspacing="0" cellpadding="0" width="100%">
            	<tr class="ctr">
            		<td>文件名</td>
                    <td style="width:180px">大小</td>
                    <td style="width:180px">日期</td>
                    <td style="width:50px">分享</td>
                    <td style="width:50px">下载</td>
                     <td style="width:50px">删除</td>
            	</tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr class="ctr">
            		<td>
                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        	<tr>
                        		<td style="width:20px"><div class="ucpyE234 dir-small"></div></td>
                                <td><div style="display:inline-block;margin-left:10px">
                                    <a href="LookFile.aspx?InfoID=<%#Eval("InfoID") %>"><%#Eval("Title") %></a>

                                    </div></td>
                        	</tr>
                        </table>
            		</td>
                    <td>-</td>
                    <td><%#Eval("CreateDate") %></td>
                    <td >-</td>
                               <td >-</td>
                    <td class="Ctd">
                        <%--<a onclick="deleteall('12583');" class="delete" title="删除"></a>--%>
                    </td>
            	</tr>
                    </ItemTemplate>
                </asp:Repeater>
                 <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <tr class="ctr">
            		<td>
                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        	<tr>
                        		<td style="width:20px"><div class="ucpyE234 <%#ShowClass(Eval("OldName").ToString()) %>"></div></td>
                                <td><div style="display:inline-block;margin-left:10px">
                                    <%#Eval("OldName") %>

                                    </div></td>
                        	</tr>
                        </table>
            		</td>
                    <td><%#JS(Eval("FileLength").ToString()) %></td>
                    <td><%#Eval("CreateDate") %></td>
                            <td  class="Ctd"><a onclick="showlook('<%#Eval("Title") %>','<%#Eval("ShareID") %>','<%#Eval("ShareCode") %>');" class="showBtn" title="分享"></a></td>
                    <td  class="Ctd"><a onclick="upload('<%#Eval("Title") %>');" class="backgj" title="下载"></a></td>
                    <td class="Ctd">
                        <a onclick="deletewj('<%#Eval("InfoID") %>');" class="delete" title="删除"></a>
                    </td>
            	</tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>


<div id="pdq3" style="position:fixed;right:0;bottom:0;z-index:10;width:280px;height:156px;    margin: 0;
    padding: 0;display:none;
    background-color: #fff;
    -webkit-background-clip: content;
    border-radius: 2px;
    box-shadow: 1px 1px 50px rgba(0,0,0,.3);">
    <div style="
    padding: 0 80px 0 20px;
    height: 42px;
    line-height: 42px;
    border-bottom: 1px solid #eee;
    font-size: 14px;
    color: #333;
    overflow: hidden;
    background-color: #F8F8F8;
    border-radius: 2px 2px 0 0;
">上传信息框</div>
    <div class="ad-box-conts" style="    text-align: center;
    margin-top: 20px;">
    <!--<span onClick="closewindow3()" class="ad-close">关 闭</span><br>-->
        <button type="button" class="zdybtn" id="test1" style="width:100px">
                  <i class="zdyicon"></i>选择文件
        </button><input class="layui-upload-file" type="file" accept="undefined" name="file">

        <input id="test-upload-change-action" class="button" type="button" lay-filter="test-upload-change-action" value="确定" />
    </div>
    <div id="uploadName" style="width:100%;font-size:12px;line-height:32px;text-align:center; margin-top: 10px;"></div>
</div>

    <div >
        <div style="display:none"><asp:HiddenField ID="HiddenField2" runat="server" />
            <asp:HiddenField ID="HiddenField3" runat="server" />
            <asp:HiddenField ID="HiddenField4" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
        </div>
         
        <script>
            var id = "<%=ShowID(Request["InfoID"])%>";
            var layindex = 0;
            var oldname = "";

            layui.use('upload', function () {
                var upload = layui.upload;
             
                    //执行实例
                    var uploadInst = upload.render({
                        elem: '#test1' //绑定元素
                        , url: 'Upload.ashx' //上传接口
                        , auto: false
                        , accept: 'file'
                        , data: { pid: id, name: oldname }
                     , bindAction: '#test-upload-change-action'
                        , choose: function (obj) {//这里的作用是截取上传文件名称并显示
                            var uploadFileInput = $(".layui-upload-file").val();
                            var uploadFileName = uploadFileInput.split("\\");
                            oldname = uploadFileName[uploadFileName.length - 1];
                            $("#uploadName").html(uploadFileName[uploadFileName.length - 1]);
                            var flag = true;
                            obj.preview(function (index, file, result) {
                                console.log(file);
                                var num = 10;
                                if ($("#<%=HiddenField4.ClientID%>").val() == "普通会员")
                                {
                                    num = 100;
                                    if (((parseInt(file.size) + parseInt($("#<%=HiddenField3.ClientID%>").val())) / (1024 * 1024 )) > num) {
                                        $("#test-upload-change-action").hide();
                                        layer.msg("文件超出容量大小！");
                                    } else {
                                        $("#test-upload-change-action").show();
                                    }
                                }
                                else {
                                    if (((parseInt(file.size) + parseInt($("#<%=HiddenField3.ClientID%>").val())) / (1024 * 1024 * 1024)) > num) {
                                        $("#test-upload-change-action").hide();
                                    } else {
                                        $("#test-upload-change-action").show();
                                    }
                                }
                            });
                        }
                        , before: function (obj) {
                            
                                layindex = layer.load(1, {
                                    shade: [0.5, '#999'] //0.1透明度的白色背景
                                });
                            
                            
                        }
                      , done: function (res) {
                          layer.close(layindex);
                          if (res == "Error") {
                              layer.alert('上传失败，空间不足！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                          }
                          else {
                             
                              layer.alert('上传成功！', { icon: 1, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } }, function () { window.location.reload(); });
                          }
                      }
                      , error: function () {
                          //请求异常回调
                          layer.close(layindex);
                          layer.alert('上传失败，空间不足！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                      }
                    });
               
            });

            var xhrOnProgress=function(fun) {
                xhrOnProgress.onprogress = fun; //绑定监听
                //使用闭包实现监听绑
                return function() {
                    //通过$.ajaxSettings.xhr();获得XMLHttpRequest对象
                    var xhr = $.ajaxSettings.xhr();
                    //判断监听函数是否为函数
                    if (typeof xhrOnProgress.onprogress !== 'function')
                        return xhr;
                    //如果有监听函数并且xhr对象支持绑定时就把监听函数绑定上去
                    if (xhrOnProgress.onprogress && xhr.upload) {
                        xhr.upload.onprogress = xhrOnProgress.onprogress;
                    }
                    return xhr;
                }
            };
            function deletewj(infoid)
            {
                $("#<%=HiddenField2.ClientID%>").val(infoid);
                $("#<%=Button2.ClientID%>").click();
            }
            function upload(path)
            {
                $("#<%=HiddenField2.ClientID%>").val(path);
                $("#<%=Button1.ClientID%>").click();
            }
            function showlook(path,shareid,code)
            {
                layer.open({
                    title: '分享链接'
  , content: '请复制链接：http://localhost:9640/Share.aspx?code=' + shareid + ' 提取码：'+code+' 发送给朋友吧'
                });

            }
            function sc()
            {
                $("#pdq3").show();
            }
            function showwb()
            {
               
                layer.prompt(function (val, index) {
                    //layer.msg('得到了' + val);
                   
                    $.ajax({
                        type: "POST",
                        url: "/Template/PC/js/addclass.ashx",
                        data: {name:val,pid:"<%=ShowID(Request["InfoID"])%>"},
                        success: function (mess) {
                            layer.msg('添加文件夹成功！');
                            layer.close(index);
                            if (id == "0") { location.href = 'LookFile.aspx';}
                            else {
                                location.href = 'LookFile.aspx?InfoID=' + id;
                            }
                        }
                    });
                });
            }
   
        </script>
    </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </form>
</body>
</html>
