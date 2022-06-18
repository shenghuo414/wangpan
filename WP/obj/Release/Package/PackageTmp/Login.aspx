<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Food.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg" style="background-color:#fff">
    
    <div style="clear:both"></div>

    <div class="new_loginpage">
	
	    <h3 class="nl_title"><span class="nl_t_left"></span>登录网盘<span class="nl_t_right"></span></h3>

        <div class="nl_loginbox_w" id="msj_loginbox">

			<div class="nl_loginitem">
				<input type="text" class="text" value="" id="username" runat="Server" placeholder="请输入登录账号">
			</div>
			<div class="nl_loginitem">
				<input type="password" class="password" id="password" runat="server" placeholder="请输入密码">
			</div>
			
			<div class="nl_loginitem" style="text-align:center;">
                <asp:Button ID="Button1" runat="server" Text="登录" CssClass="button" OnClick="Button1_Click" />
				
			</div>

            <a href="Register.aspx" class="golink" id="nl_gozc">还没有账号？免费注册 ∨</a>
	    </div>

    </div>
</div>
</asp:Content>
