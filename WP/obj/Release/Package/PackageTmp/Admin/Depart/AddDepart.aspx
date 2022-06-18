<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddDepart.aspx.cs" Inherits="Food.Admin.Depart.AddDepart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="../Js/Uploadify/css/uploadify.css" rel="stylesheet">
    <script src="../Js/Uploadify/js/uploadify3.2.1/jquery.uploadify.min.js"></script>
    <link href="../Js/control/css/zyUpload.css" rel="stylesheet">
    <script src="../Js/control/js/zyFile.js"></script>
    <script src="../Js/control/js/zyUpload.js"></script>
    <div class="col-xs-12">
        <asp:UpdatePanel ID="up_main" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pl_addOrEdit" runat="server">

                    <div class="row" style="margin-top:20px">
                        <div class="col-xs-6">

                            <div class="form-group">
                                <table style="width:100%">
                                    <tr>
                                    <td style="width:90px"><label for="field-1" class="control-label">父组织选择</label></td>
                                    <td><asp:DropDownList ID="drp_ParentID" CssClass="form-control" runat="server"></asp:DropDownList>
                                <a href=""></a></td>
                                       </tr>
                                </table>
                                
                               
                            </div>

                        </div>
                        <div class="col-xs-6">

                            <div class="form-group">
                                <table style="width:100%">
                                    <tr>
                                    <td style="width:90px">
                                <label for="field-1" class="control-label">组织排序</label></td>
                                        <td>
                                <asp:TextBox ID="txt_OrderID" CssClass="form-control" placeholder="请输入数字" runat="server"></asp:TextBox>
                                            </td></tr></table>
                            </div>

                        </div>
                    </div>
                    <div class="row" style="margin-top:10px">
                        <div class="col-xs-6">

                            <div class="form-group">
                                <table style="width:100%">
                                    <tr>
                                    <td style="width:90px">
                                <label for="field-1" class="control-label">组织名称</label></td>
                                        <td>
                                <asp:TextBox ID="txt_DepartMentName" CssClass="form-control" placeholder="组织名称" runat="server" AutoPostBack="True" OnTextChanged="txt_DepartMentName_TextChanged"></asp:TextBox>
                                            </td></tr></table>
                            </div>

                        </div>
                        <div class="col-xs-6">

                            <div class="form-group">
                                <table style="width:100%">
                                    <tr>
                                    <td style="width:90px">
                                <label for="field-1" class="control-label">组织标识</label></td>
                                        <td>
                                <asp:TextBox ID="txt_DepartMentEname" CssClass="form-control" placeholder="组织标识" runat="server"></asp:TextBox>
                                            </td></tr></table>
                            </div>

                        </div>

                    </div>
                
                    <div class="row">

                        <div class="main-button" style="margin-bottom:20px">
                            <asp:LinkButton ID="lk_sure" CssClass="button" runat="server" OnClick="lk_sure_Click">确定保存</asp:LinkButton>

                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>

        </asp:UpdatePanel>
    </div>
    <script>
        $(function () {
            //layer.alert('操作失败！', { icon: 2, kin: 'layer-ext-moon' }, function () {
            //    location.href = "Index.aspx";
            //});

            $(".main-button").css("width", "99.8%");
        });
    </script>
</asp:Content>
