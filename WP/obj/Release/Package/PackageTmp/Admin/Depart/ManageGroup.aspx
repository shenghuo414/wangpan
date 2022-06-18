<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageGroup.aspx.cs" Inherits="Food.Admin.Depart.ManageGroup" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        input {
            display:inline-block!important;
        }
        .width350{
            width:200px;
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
    </style>


     <div id="manage_top" class="menu_top_fixed">
            <ul>
        <li id="p1"><a href="AddGroup.aspx?action=add"><b></b>添加用户组</a></li>

        </ul>
    </div>
    <div class="content-area pageBlank" style="margin-left:0px;margin-top:70px;margin-right:0px;margin-bottom:70px">

        <div class="myTitle">
            用户组管理
        </div>

        <div class="row searchlist" style="border-bottom: 1px solid #ddd; margin-bottom: 10px; padding-bottom: 10px;">
            <asp:Panel ID="pl_select" runat="server" CssClass="form_select col-xs-11">

            </asp:Panel>
            
           
        </div>

        <table  cellpadding="0" cellspacing="0" class="CTable" style="width:99%;border-collapse:collapse; " >
            <tbody>
                <tr class="" style="background: #f4f6f7; text-align:center">
                    <td>用户组ID</td>
                    <td>用户组名称</td>
                    <td>用户组描述</td>
                    <td style="width:50px">编辑</td>
                    <td style="width:50px">删除</td>
                </tr>
            </tbody>
        <asp:Repeater ID="rp_list" runat="server" >
            <ItemTemplate>
               <tbody>
                <tr onmouseover="this.className='CtrMouseOver'" onmouseout="this.className='CtrMouseOut'" class="CtrMouseOut" id="tr{GZ_infoID}" style="text-align:center; border-bottom:1px solid #ccc">
                    <td class="Ctd "><%#Eval("GroupID") %></td>
                    <td class="Ctd "><%#Eval("GroupName") %></td>
                    <td class="Ctd "><%#Eval("Intro") %></td>
                    <td class="Ctd ">
                        <a href="AddGroup.aspx?action=edit&groupid=<%#Eval("groupid") %>" class="edit" title="编辑"></a>
                    </td>
                    <td class="Ctd ">
                       <a onclick="deleterow(<%# Eval("groupid") %>,'<%#Eval("groupname") %>');" class="delete" title="删除"></a>
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
       
    </div>
     <div class="footer_page">
         <webdiyer:AspNetPager CssClass="ap" ID="AspNetPager1" runat="server" Width="98%" NumericButtonCount="6" UrlPaging="true" NumericButtonTextFormatString="{0}" ShowCustomInfoSection="Left"
                CustomInfoHTML="当前页码为：%CurrentPageIndex%  总页数： %PageCount% 页 每页显示：10条 总记录：%RecordCount% 条" 
                FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" Font-Names="Microsoft YaHei" AlwaysShow="true" ShowInputBox="Never" SubmitButtonText="跳转" OnPageChanging="AspNetPager1_PageChanging"  CurrentPageButtonClass="currr" CustomInfoClass="" CustomInfoSectionWidth="30%" PageSize="10">
            </webdiyer:AspNetPager>
        </div>
    <div style="display:none">     <asp:HiddenField ID="HiddenField1" runat="server" />
         <asp:Button ID="linSubmit" runat="server" Text="提交" onclick="Button1_Click" />
    </div>
    <script>
        function deleterow(sid, name) {
            $("#ContentPlaceHolder1_HiddenField1").val(sid);
            //if ($("#deletehidden").val() == "True") {
            layer.confirm('确定要删除用户组【' + name + '】吗？', {
                skin: 'layer-ext-moon',
                closeBtn: 0,//样式类名
                btn: ['确定', '取消'] //按钮
            }, function () {
                $("#ContentPlaceHolder1_linSubmit").click();
            }, function () {

            });

            function reload() {
                window.location.reload();
            }
            //}
            //else {
            //    KesionJS.Alert('对不起,您没有此项操作的权限!');
            //}
        }

    </script>
</asp:Content>
