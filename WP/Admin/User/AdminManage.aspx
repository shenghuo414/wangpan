<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminManage.aspx.cs" Inherits="Food.Admin.User.AdminManage" %>
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
        <li id="p1">
            <a href="AddAdmin.aspx?action=add" class="new_button_with_new_bg_little " style="padding: 6px 12px; ">添加管理员</a></li>
           

        </ul>
    </div>
    <div class="content-area pageBlank" style="margin-left:0px;margin-top:70px;margin-right:0px">

        <div class="myTitle">
            管理员管理
        </div>

        <div class="row searchlist" style="border-bottom: 1px solid #ddd; margin-bottom: 10px; padding-bottom: 10px;">
            <asp:Panel ID="pl_select" runat="server" CssClass="form_select col-xs-11">

            </asp:Panel>
            
           
        </div>

        <table  cellpadding="0" cellspacing="0" class="CTable" style="width:99%;border-collapse:collapse; " >
            <tbody>
                <tr class="" style="background: #f4f6f7; text-align:center">
                    <td>ID</td>
                    <td>管理员账号</td>
                    <td>管理员名称</td>
                    <td>部门名称</td>
                    <td>用户组名称</td>
                    <td>状态</td>
                    <td style="width:50px">编辑</td>
                    <td style="width:50px">删除</td>
                    
                </tr>
            </tbody>
        <asp:Repeater ID="rp_list" runat="server" >
            <ItemTemplate>
               <tbody>
                <tr onmouseover="this.className='CtrMouseOver'" onmouseout="this.className='CtrMouseOut'" class="CtrMouseOut" id="tr{GZ_infoID}" style="text-align:center; border-bottom:1px solid #ccc">
                    <td class="Ctd "><%#Eval("ID") %></td>
                    <td class="Ctd "><%#Eval("LoginName") %></td>
                    <td class="Ctd "><%#Eval("RealName") %></td>
                    <td class="Ctd "><%#Eval("DepartMentName") %></td>
                    <td class="Ctd "><%#Eval("GroupName") %></td>
                    <td class="Ctd "><%#Eval("Locked").ToString()=="0"?"<span style='color:green'>正常</span>":"<span style='color:red'>锁定</span>" %></td>
                    <td class="Ctd ">
                        <a href="AddAdmin.aspx?action=edit&loginname=<%#Eval("LoginName") %>" class="edit" title="编辑"></a>
                    </td>
                    <td class="Ctd ">
                       <a onclick="deleterow(<%#Eval("ID") %>,'<%#Eval("LoginName") %>');" class="delete" title="删除"></a>
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
    <script>
        function deleterow(id,name)
        {
            layer.confirm('确定要删除【' + name + '】管理员吗？', {
                skin: 'layer-ext-moon',
                closeBtn: 0,//样式类名
                btn: ['确定', '取消'] //按钮
            }, function () {
                $.ajax({
                    type: "POST",

                    url: "../Ajax/admin_delete.ashx",
                    data: { userid: id },
                    success: function (msg) {
                        if (msg == "操作成功！") {
                            layer.alert(msg, { icon: 1, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } }, function () { window.location.reload(); });
                        }
                        else {
                            layer.alert(msg, { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                        }
                    },
                    error: function (msg) {
                        layer.alert('操作失败！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                    }

                });
            }, function () {

            });
        }
    </script>
</asp:Content>
