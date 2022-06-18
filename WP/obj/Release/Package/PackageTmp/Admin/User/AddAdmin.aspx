<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddAdmin.aspx.cs" Inherits="Food.Admin.User.AddAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Css/addstyle.css" rel="stylesheet" />
     <div id="manage_top" class="menu_top_fixed">
             管理员信息
     </div>
    <div class="main-content main_with_red_border" style="margin-left:-40px; margin-right:-20px; margin-top:70px; margin-bottom:70px;padding-bottom:20px">
        <div class="content-area dynamic-tab-pane-control tab-page" style="padding:0px 20px 20px 20px;margin-top:20px" >
            
            <asp:UpdatePanel ID="up_Main" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pl_main" CssClass="formMain form-horizontal form-groups-bordered" runat="server">
                         
                        <div class="col-xs-12 form-group">
			                <span class="labels">管理员名称：</span>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control width350"></asp:TextBox>
                            <font color="#ff0000">*</font><span class="tips">如：用于登录后台的账号。</span>
		                </div>
                        <div class="col-xs-12 form-group">
			                <span class="labels">姓名：</span>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control width350"></asp:TextBox>
                            <font color="#ff0000">*</font><span class="tips">如：张三、李四等。</span>
		                </div>
                         <div class="col-xs-12 form-group">
			                <span class="labels">密码：</span>
                            <asp:TextBox ID="TextBox3" TextMode="Password" runat="server" CssClass="form-control width350"></asp:TextBox>
                            <font color="#ff0000">*</font><span class="tips"> 如：用于登录后台的密码。</span>
		                </div>
                       <div class="col-xs-12 form-group">
			                <span class="labels">用户组：</span>
                           <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control width350"></asp:DropDownList>
                            <font color="#ff0000">*</font>
		                </div>
                        <div class="col-xs-12 form-group">
			                <span class="labels">部门：</span>
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control width350"></asp:DropDownList>
                            <font color="#ff0000">*</font>
		                </div>
                        <div class="col-xs-12 form-group">
			                <span class="labels">状态：</span>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="rcss" RepeatColumns="2" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True">正常</asp:ListItem>
                                <asp:ListItem>锁定</asp:ListItem>
                            </asp:RadioButtonList>
                            <font color="#ff0000">*</font>
		                </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="clear"></div>

        </div>
    </div>
    <div class="footer_page" style="text-align:center;height:50px!important">

        <asp:Button ID="Button1" runat="server" Text="确认(O)" CssClass="button" OnClick="Button1_Click" />
		<input type="button" value="返回上一页(C)" onclick="history.back(); return false;" id="fhsyy" accesskey="C" class="button"/>
        <asp:HiddenField ID="HiddenField1" runat="server" />
	</div>
    <script>
        function CheckForm()
        {
            if ($("#<%=TextBox1.ClientID%>").val() == "")
            {
                layer.alert('管理员名称不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
                return false;
            }
            else if ($("#<%=TextBox2.ClientID%>").val() == "") {
                layer.alert('管理员姓名不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
                return false;
            }
            else if ($("#<%=TextBox3.ClientID%>").val() == "") {
                layer.alert('密码不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
                return false;
            }
            else if ($("#<%=TextBox3.ClientID%>").val().length < 6 || $("#<%=TextBox3.ClientID%>").val().length >12) {
                layer.alert('密码在6到12位之间！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
                return false;
            }
            else if ($("#<%=DropDownList1.ClientID%>").val() == "0") {
                layer.alert('请选择用户组！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
                return false;
            }
            else if ($("#<%=DropDownList2.ClientID%>").val() == "0") {
                layer.alert('请选择部门！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</asp:Content>
