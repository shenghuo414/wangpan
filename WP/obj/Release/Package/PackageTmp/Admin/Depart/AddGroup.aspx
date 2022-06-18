<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddGroup.aspx.cs" Inherits="Food.Admin.Depart.AddGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style>
         .main-content {
            height: 100%;
            padding:0 20px;
        }
        .form-group {
            border-bottom:1px solid #ccc;
        }
         .labels {
    width: 150px;
    display: inline-block;
    text-align:right;
    padding-right:20px;
    line-height:50px;
}
        input {
            display:inline-block!important;
        }
        .width350{
            width:350px;
        }
        .width150{
            width:150px;
        }
        .mutinput{
            width:350px;
            height:80px!important;
            /*float:left;*/
            margin-top:10px;
            margin-bottom:10px;
            margin-left:5px;
        }
      .mutspan{
              display: block;
    text-align: left;
    position: absolute;
    /*padding-top: 80px;*/
    padding-left: 155px;
      }
    </style>




     <div id="manage_top" class="menu_top_fixed">
             用户组信息
           
    </div>
    <div class="main-content main_with_red_border" style="margin-left:-40px; margin-right:-20px; margin-top:70px; margin-bottom:70px;padding-bottom:20px">
         
        
        
        <div class="content-area dynamic-tab-pane-control tab-page" style="padding:0px 20px 20px 20px;margin-top:20px" >
            
            <asp:UpdatePanel ID="up_Main" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pl_main" CssClass="formMain form-horizontal form-groups-bordered" runat="server">
                         
                        <div class="col-xs-12 form-group">
			                <span class="labels">用户组名称：</span>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control width350"></asp:TextBox>
                            <font color="#ff0000">*</font><span class="tips">请输入用户组的中文名称，如超级用户组。</span>
		                </div>
                      
                         <div class="col-xs-12 form-group">
			                <span class="labels" style="float:left">用户组介绍：</span>
                             <asp:TextBox ID="TextBox7"  runat="server" CssClass="form-control mutinput" TextMode="MultiLine"  ></asp:TextBox>
		                </div>
                       
                        <div class="col-xs-12 form-group"  style="height: 680px;">
			                <span class="labels" style="float:left">用户组权限：</span>
                            <div style="margin-left:150px">
                            
                                    <div style="margin-top:10px">
                                        <asp:CheckBox runat="server" ID='chk01' CssClass="xx" Text='信息' Font-Bold="true" />
                                    </div>
                                    <div style="margin-top:10px">
                                        一&nbsp;&nbsp;<asp:CheckBox runat="server" CssClass="nrgl" ID='chk01_01' Text='内容管理' ForeColor="#0aa46a" />
                                    </div>
                                    <div style="margin-top:10px">
                                        一一&nbsp;&nbsp;
                                          <asp:CheckBox ID="chk01_01_01"  ForeColor="#0099ff"  Text='文件信息管理' runat="server" CssClass='1000044' />
                                          <asp:CheckBox ID="chk01_01_02"  ForeColor="#0099ff"  Text='VIP激活码管理' runat="server" CssClass='1000015' />
                                          <asp:CheckBox ID="chk01_01_03"  ForeColor="#0099ff"  Text='用户信息管理' runat="server" CssClass='1000054' />
                                        
                                    </div>
                                    <div style="margin-top:10px">
                                        一&nbsp;&nbsp;<asp:CheckBox runat="server" ID='chk01_02' Text='功能选项' CssClass="gnxx" ForeColor="#0aa46a" />
                                    </div>
                                    <div style="margin-top:10px">
                                        一一&nbsp;&nbsp;<asp:CheckBox ID="chk01_01_"  ForeColor="#0099ff"  Text='栏目管理' runat="server" CssClass="lmgl" />
                                    </div>

                                 <div style="margin-top:10px;display:none">
                                        <asp:CheckBox runat="server" ID='chk02' CssClass="yy" Text='互动' Font-Bold="true" />
                                    </div>

                                    <div style="margin-top:10px">
                                        <asp:CheckBox runat="server" ID='chk03' CssClass="yh" Text='用户' Font-Bold="true" />
                                    </div>
                                    <div style="margin-top:10px">
                                        一&nbsp;&nbsp;<asp:CheckBox runat="server" ID='chk03_01' Text='管理员' CssClass="gly" ForeColor="#0aa46a" />
                                    </div>
                                    <div style="margin-top:10px">
                                        一一&nbsp;&nbsp;<asp:CheckBox ID="chk03_01_01"  ForeColor="#0099ff"  Text='管理员管理' runat="server" CssClass="glygl" />
                                        <asp:CheckBox ID="chk03_01_02"  ForeColor="#0099ff"  Text='部门管理' runat="server" CssClass="bmgl" />
                                        <asp:CheckBox ID="chk03_01_03"  ForeColor="#0099ff"  Text='用户组管理' runat="server" CssClass="yhzgl" />
                                    </div>
                                 
                                <div style="margin-top:10px">
                                        <asp:CheckBox runat="server" ID='CheckBox1' CssClass="bq" Text='标签' Font-Bold="true" />
                                    </div>
                                    <div style="margin-top:10px">
                                        一&nbsp;&nbsp;<asp:CheckBox runat="server" ID='chk04_01' Text='风格标签' CssClass="fgbq" ForeColor="#0aa46a" />
                                    </div>
                                    <div style="margin-top:10px">
                                        
                                        一一&nbsp;&nbsp;
                                        <asp:CheckBox ID="chk04_01_02"  ForeColor="#0099ff"  Text='高级标签（自定义）' runat="server" CssClass="zjbq" />
                                        <asp:CheckBox ID="chk04_01_03"  ForeColor="#0099ff"  Text='高级标签（SQL）' runat="server" CssClass="gjbq" />
                                        <asp:CheckBox ID="chk04_01_04"  ForeColor="#0099ff"  Text='自定义静态标签' runat="server" CssClass="jtbq" />
                                        
                                    </div>
                                    <div style="margin-top:10px">
                                        一&nbsp;&nbsp;<asp:CheckBox runat="server" ID='chk04_02' Text='生成HTML操作' CssClass="schtmlcz" ForeColor="#0aa46a" />
                                    </div>
                                    <div style="margin-top:10px">
                                        
                                        一一&nbsp;&nbsp;<asp:CheckBox ID="CheckBox3"  ForeColor="#0099ff"  Text='生成首页' runat="server" CssClass="scsy" />
                                        <asp:CheckBox ID="CheckBox4"  ForeColor="#0099ff"  Text='生成栏目/内容页' runat="server" CssClass="sclnnry" />
                                        
                                    </div>

                               

                                    <div style="margin-top:10px">
                                        <asp:CheckBox runat="server" ID='chk04' CssClass="pz" Text='配置' Font-Bold="true" />
                                    </div>
                                    <div style="margin-top:10px">
                                        一&nbsp;&nbsp;<asp:CheckBox runat="server" ID='chk05_01' Text='基本设置' CssClass="jbsz" ForeColor="#0aa46a" />
                                    </div>
                                    <div style="margin-top:10px">
                                        
                                        一一&nbsp;&nbsp;
                                        <asp:CheckBox ID="chk05_01_01"  ForeColor="#0099ff"  Text='网站参数设置' runat="server" CssClass="wzcssz" />
                                        <asp:CheckBox ID="chk05_01_02"  ForeColor="#0099ff"  Text='模型&应用管理' runat="server" CssClass="mxyygl" />
                                        <asp:CheckBox ID="chk05_01_03"  ForeColor="#0099ff"  Text='更新缓存' runat="server" CssClass="gxhc" />
                                     </div>
                            </div>
                            <span class="tips mutspan">针对用户组设置的权限信息</span>
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

</asp:Content>
