<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UpdatePass.aspx.cs" Inherits="Food.Admin.User.UpdatePass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="../Css/addstyle.css" rel="stylesheet" />
     <div id="manage_top" class="menu_top_fixed">
             修改密码
     </div>
    <div class="main-content main_with_red_border" style="margin-left:-40px; margin-right:-20px; margin-top:70px; margin-bottom:70px;padding-bottom:20px">
        <div class="content-area dynamic-tab-pane-control tab-page" style="padding:0px 20px 20px 20px;margin-top:20px" >
            
            <asp:UpdatePanel ID="up_Main" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pl_main" CssClass="formMain form-horizontal form-groups-bordered" runat="server">
                         
                        
                        
                         <div class="col-xs-12 form-group">
			                <span class="labels">新密码：</span>
                            <asp:TextBox ID="TextBox3" TextMode="Password" runat="server" CssClass="form-control width350"></asp:TextBox>
                            <font color="#ff0000">*</font><span class="tips"> 如：用于登录后台的密码。</span>
		                </div>
                        <div class="col-xs-12 form-group">
			                <span class="labels">确认密码：</span>
                            <asp:TextBox ID="TextBox1" TextMode="Password" runat="server" CssClass="form-control width350"></asp:TextBox>
                            <font color="#ff0000">*</font><span class="tips"> 如：用于登录后台的密码。</span>
		                </div>

                        
                       
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="clear"></div>

        </div>
    </div>
    <div class="footer_page" style="text-align:center;height:50px!important">

        <asp:Button ID="Button1" runat="server" Text="确认(O)" CssClass="button" OnClick="Button1_Click" />
		
        <asp:HiddenField ID="HiddenField1" runat="server" />
	</div>
    <script>
        function CheckForm() {
            
            if ($("#<%=TextBox3.ClientID%>").val() == "") {
                layer.alert('密码不能为空！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
                return false;
            }
            else if ($("#<%=TextBox3.ClientID%>").val().length < 6 || $("#<%=TextBox3.ClientID%>").val().length > 12) {
                layer.alert('密码在6到12位之间！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
                return false;
            }
            if ($("#<%=TextBox3.ClientID%>").val() != $("#<%=TextBox1.ClientID%>").val()) {
                layer.alert('两次密码不一致！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
                return false;
            }
            
            else {
                return true;
            }
}
    </script>
</asp:Content>
