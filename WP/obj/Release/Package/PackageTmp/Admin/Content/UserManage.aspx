<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="Food.Admin.Content.UserManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script src="../Js/DatePicker/WdatePicker.js"></script>
       <style>
        input {
            display:inline-block!important;
        }
        .width350{
            width:200px;
        }
        .width100{
            width:100px;
        }
        .form-group {
    border-bottom: 1px solid #ccc;
} .labels {
    width: 110px;
    display: inline-block;
    text-align:right;
    padding-right:20px;
    line-height:50px;
}
  .lb {
    min-width:70px;
    display: inline-block;
    text-align:right;
    padding-right:20px;
    line-height:50px;
    margin-left: 20px;
}
        
    .tb {
 width:190px;
    display: inline-block;
    padding-right:10px;
    padding-left:10px;
}
    .drp {
 min-width:190px;
    display: inline-block;
    padding-right:10px;
    padding-left:10px;
}
    .mt{
        margin-top:8px;
    }
    .form_select span{
        display:inline-block;
    }
    </style>

    <div class="content-area pageBlank" style="margin-left:0px;margin-top:20px;margin-right:0px;margin-bottom:70px">

        <div class="myTitle">
            用户信息管理
          
        </div>
         <div class="row searchlist" style="border-bottom: 1px solid #ddd; margin-bottom: 10px; padding-bottom: 10px;">
            <asp:Panel ID="pl_select" runat="server" CssClass="form_select col-xs-11">
                <span class="lb">登录账号</span>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="tb"></asp:TextBox>
                <span class="lb">用户昵称</span>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="tb"></asp:TextBox>


            </asp:Panel>
             <span style="float:right">
                <asp:Button ID="Button1" runat="server" Text="查询" CssClass="button mt new_button_with_new_bg width100" OnClick="Button1_Click" />
            </span>
            <div style="clear:both"></div>
         
        </div>
        <table class="CTable" >
            <tbody>
                <tr class="" style="text-align:center;background: #ececec;border-bottom: 1px solid #ddd;">
                    
                    <td style="width:100px">编号</td>
                    <td>登录账号</td>
                    <td>用户昵称</td>
                    <td>头像</td>
                      <td>注册日期</td>  
                    
                </tr>
            </tbody>
        <asp:Repeater ID="rp_list" runat="server" >
            <ItemTemplate>
               <tbody>
                <tr onmouseover="this.className='CtrMouseOver tbline'" onmouseout="this.className='CtrMouseOut tbline'" class="CtrMouseOut tbline" id="tr{GZ_infoID}" style="text-align:center; border-bottom:1px solid #ccc">
                    
                   <td class="Ctd"><%#Eval("InfoID") %></td>
                   <td class="Ctd"><%#Eval("LoginName") %>【<%#Eval("UserLevel").ToString()=="VIP超级会员"?"<span style='color:red'>VIP超级会员</span>":Eval("UserLevel").ToString() %>】</td>
                    <td class="Ctd"><%#Eval("Title") %></td>
                    <td class="Ctd"><img src='<%#Eval("Pic") %>' width="100px" height="100px" /></td>
                    <td class="Ctd"><%#Eval("AddDate") %>
                       
                    </td>
                    
                  
                </tr>
            </tbody>
            </ItemTemplate>
        </asp:Repeater>
            <iframe  width="0"   height="0"   frameborder="0"   name="hrong"   style="display:none"></iframe>  
            </table>


        <style>
            .main-content {
            height: 100%;
            padding:0 20px;
        }
            .ap{
                font-size: 9pt; height: 25px; text-align: right;margin-left:20px;
            }
            .currr {
    color: #FFFFFF;
    font-weight: bold;
    background-color: #ea3527;
    border: 1px solid #ea3527;
    padding: 6px 10px;
    margin: 0 3px;
    border-radius: 3px;
}
        </style>
       <iframe id="exceliframe" style="display:none"></iframe>
    </div>
     <div class="footer_page">
         <webdiyer:AspNetPager CssClass="ap" ID="AspNetPager1" runat="server" Width="98%" NumericButtonCount="6" UrlPaging="false" NumericButtonTextFormatString="{0}" ShowCustomInfoSection="Left"
                CustomInfoHTML="当前页码为：%CurrentPageIndex%  总页数： %PageCount% 页 每页显示：10条 总记录：%RecordCount% 条" 
                FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" Font-Names="Microsoft YaHei" AlwaysShow="true" ShowInputBox="Never" SubmitButtonText="跳转" OnPageChanging="AspNetPager1_PageChanging"  CurrentPageButtonClass="currr" CustomInfoClass="" CustomInfoSectionWidth="30%">
            </webdiyer:AspNetPager>
         <asp:HiddenField ID="HiddenField1" runat="server" />
         <asp:HiddenField ID="HiddenField2" runat="server" />
         <asp:HiddenField ID="HiddenField3" runat="server" />
         <asp:HiddenField ID="HiddenField4" runat="server" ClientIDMode="Static" />
         <asp:HiddenField ID="HiddenField5" runat="server" />
         <asp:HiddenField ID="HiddenField6" runat="server" ClientIDMode="Static" />
         <asp:HiddenField ID="HiddenField7" runat="server" />
         <asp:HiddenField ID="HiddenField8" runat="server" ClientIDMode="Static" />
        </div>
     <div style="display:none">
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
    </div>
    
</asp:Content>
