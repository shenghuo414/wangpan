<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Food.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Template/PC/js/layui/css/layui.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
    <div class="bg" style="background-color:#fff">
    
    <div style="clear:both"></div>

    <div class="new_loginpage">
	
	    <h3 class="nl_title"><span class="nl_t_left"></span>注册网盘<span class="nl_t_right"></span></h3>

        <div class="nl_loginbox_w" id="msj_loginbox">

            <img id="touxiang" src="/UploadFiles/files/tx.png" class="tx">

            <div class="nl_loginitem">
                
                

                <button type="button" class="zdybtn" id="test1">
                  <i class="zdyicon"></i>上传图片
                </button><input class="layui-upload-file" type="file" accept="undefined" name="file">
       
                <script src="/Template/PC/js/layui/layui.js"></script>
        <script>
            layui.use('upload', function () {
                var upload = layui.upload;

                //执行实例
                var uploadInst = upload.render({
                    elem: '#test1' //绑定元素
                  , url: 'Upload.ashx' //上传接口
                  , done: function (res) {
                      //上传完毕回调
                      //alert(res);
                      $("#touxiang").attr("src", res.url);
                      $("#HiddenField1").val(res.url);
                  }
                  , error: function () {
                      //请求异常回调
                  }
                });
            });
        </script>
            </div>
			<div class="nl_loginitem">
				<input type="text" class="text onlyNumAlpha" value="" runat="server" id="username" placeholder="请输入账号">
			</div>
            <div class="nl_loginitem">
				<input type="text" class="text" value="" runat="server" id="nickname" placeholder="请输入昵称">
			</div>
			<div class="nl_loginitem">
				<input type="password" class="password" runat="server" id="password" placeholder="请输入密码">
			</div>
			
			<div class="nl_loginitem" style="text-align:center;">
                <asp:Button ID="Button1" runat="server" Text="注册" CssClass="button" OnClick="Button1_Click" />
			</div>

	    </div>
    </div>
</div>
</asp:Content>
