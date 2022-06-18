<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageDepart.aspx.cs" Inherits="Food.Admin.Depart.ManageDepart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="manage_top" class="menu_top_fixed">
             <ul>
            <li><strong>管理操作：</strong></li>
            <li class="curr"><a href="#">部门管理</a></li>
        </ul>
    </div>
    <div class="content-area" style="margin-top:70px">
 	<div class="myTitle">部门管理
         
 	</div>        
        <div>
    <ul class="Depart">
        <asp:Literal ID="lt_menu" runat="server"></asp:Literal>
    </ul>
    <asp:Repeater ID="list" runat="server">
        <HeaderTemplate>
            <table id="ct" width="100%" align="center" cellpadding="0" cellspacing="0" class="table table-bordered table-striped datatable dataTable" >
                <tr class="CTitle" id="dd13" did="13" pid="0">
                    <th scope="col" style="width: 50px;text-align:center">部门ID</th>
                    <th scope="col">部门名称</th>

                    <th scope="col" style="width: 50px;text-align:center">序号</th>
                    
                    <th scope="col" style="width: 50px!important;text-align:center" >修改</th>
                    <th scope="col" style="width: 50px!important;text-align:center" >删除</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr id='d<%#Eval("DepartId") %>' did="<%#Eval("DepartId") %>" pid="<%#Eval("ParentIDPath") %>" onmouseover="jQuery('#a<%# Eval("departId") %>').show();this.className='CtrMouseOver'" onmouseout="jQuery('#a<%# Eval("departId") %>').hide();this.className='CtrMouseOut'" onclick="chk(this)">
                <td class="" align="center"><%# Eval("departid") %></td>
                <td class="" style="height: 30px; width: 350px;">

                    <%# getLine(Eval("ParentIDPath").ToString(), Eval("DepartMentName").ToString(), Eval("child").ToString())%>
                    <span id='a<%# Eval("departId") %>' style="padding-left: 20px; display: none">
                        <a style="color: #999" onclick="addrows(<%# Eval("departId") %>)">添加子组织</a>
                    </span>
                </td>
                <td class="" align="center">
                    <%# Eval("OrderID") %>

                </td>
             
                <td class="Ctd" align="center">
                    <a onclick="updaterows(<%# Eval("departId") %>)" class="edit" title="编辑">
                        
                    </a></td>
                    <td class="Ctd" align="center">

                    <a class="delete" vid="<%# Eval("departid") %>" title="删除" onclick="deleterow(<%# Eval("departid") %>,'<%#Eval("departmentname") %>');"><i class="entypo-cancel"></i>删除</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater><div style="display:none">   
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" />
                                 <asp:Button ID="linSubmit" runat="server" Text="提交" onclick="Button1_Click" /></div>
            </div>

    <script>
        $(function () {
            $(".delete").each(function () {
                if ($(this).attr("vid") == "1") {
                    $(this).remove();
                }
            });
        });
        function jd(obj) {
            var id = obj.parentNode.parentNode.getAttribute("id");
            var did = obj.parentNode.parentNode.getAttribute("did");
            if (obj.innerText == "[-]") {
                obj.innerText = "[+]";
                $("#ct").find("tr").each(function () {
                    //console.log($(this).html());
                    //console.log($(this).attr("id"));
                    var pid = $(this).attr("pid");
                    //console.log(pid);
                    //console.log(did);
                    if (pid.indexOf(did) > -1) {
                        $(this).hide();
                    }
                });
            }
            else {
                obj.innerText = "[-]";
                $("#ct").find("tr").each(function () {
                    var pid = $(this).attr("pid");
                    if (pid.indexOf(did) > -1) {
                        $(this).show();
                    }
                });
            }

            //.getAttribute('did'));
        }
        function deleterow(sid,name) {
            $("#ContentPlaceHolder1_HiddenField1").val(sid);
            $("#ContentPlaceHolder1_HiddenField2").val(name);
            //if ($("#deletehidden").val() == "True") {
                layer.confirm('确定要删除组织架构【'+name+'】吗？', {
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
        function updaterows(departid) {
            //if ($("#updatehidden").val() == "True") {
            sp('AddDepart.aspx?action=edit&id=' + departid, '700px', '400px', '编辑部门')
            //}
            //else {
            //    KesionJS.Alert('对不起,您没有此项操作的权限!');
            //}
        }
        function sp(url, width, height, title) {
            var windowwidth = window.innerWidth;
            if (windowwidth < 1000) {
                height = "95%";
                width = "98%";
            }
            var windowheight = window.innerHeight;
            if (windowheight < 750) {
                height = "95%";
                width = "98%";
            }
            //alert(windowheight);
            layer.open({
                type: 2,
                title: title,
                scrollbar: false,
                shadeClose: false,
                shade: 0.8,
                area: [width, height],
                content: url
            });
        };
        function addrows(departid) {
            //if ($("#addhidden").val() == "True") {
                sp('AddDepart.aspx?action=add&Parentid=' + departid, '700px', '400px', '添加部门');
            //}
            //else {
            //    KesionJS.Alert('对不起,您没有此项操作的权限!');
            //}
        }

       
    </script>
</asp:Content>
