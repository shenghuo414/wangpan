<%@ Page ValidateRequest="false" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ContactEidt.aspx.cs" Inherits="Food.Admin.Content.ContactEidt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.min.js"> </script>
    <!--建议手动加在语言，避免在ie下有时因为加载语言失败导致编辑器加载失败-->
    <!--这里加载的语言文件会覆盖你在配置项目里添加的语言类型，比如你在配置项目里配置的是英文，这里加载的中文，那最后就是中文-->
    <script type="text/javascript" charset="utf-8" src="/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="../Js/DatePicker/WdatePicker.js"></script>
    <link href="../Js/Uploadify/css/uploadify.css" rel="stylesheet" />
    <script src="../Js/Uploadify/js/uploadify3.2.1/jquery.uploadify.min.js"></script>
    <link href="../Js/control/css/zyUpload.css" rel="stylesheet" />
    <script src="../Js/control/js/zyFile.js"></script>
    <script src="../Js/control/js/zyUpload.js"></script>
    <script src="../Js/base64.js"></script>
    <script>
        function SetEdit(editor, txt) {
            UE.getEditor(editor).addListener("ready", function () {
                UE.getEditor(editor).setContent(txt);
            });
        }
    </script>
     <style>
         .text1{
             width:100%!important;
             text-align:center;
         }
         .text1_1{
             width:100%!important;
             text-align:center;
         }
         .text2{
             width:100%!important;
             text-align:center;
         }
         .text2_1{
             width:100%!important;
             text-align:center;
         }
         .area1{
             width:100%!important;
         }
         .qt{
                 width: 600px;
    float: left;
    margin-left: 20px;
    margin-top: 20px;
    margin-bottom: 20px;
         }
           .mr10 {
            margin-right:10px;
            margin-top:5px;
            margin-bottom:5px;
            }
         #radiodiv label {
             margin-top:20px;
           
         }
          #checkdiv label {
             margin-top:20px;
           
         }
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
            height:80px;
            margin-top:10px;
            margin-bottom:10px;
            margin-left:5px;
        }
      .mutspan{
              display: block;
    text-align: left;
    position: absolute;
    padding-top: 80px;
    padding-left: 155px;
      }
      .txt{
          width:650px;
          height:200px;
      }
    </style>
    <div id="manage_top" class="menu_top_fixed">
        批量生成VIP激活码
           
    </div>
    <div class="main-content main_with_red_border" style="margin-left:-40px; margin-right:-20px; margin-top:70px; margin-bottom:70px;padding-bottom:20px">
         
        
        
        <div class="content-area dynamic-tab-pane-control tab-page" style="padding:0px 20px 20px 20px;margin-top:20px" >
            <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
            <asp:UpdatePanel ID="up_Main" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pl_main" CssClass="formMain form-horizontal form-groups-bordered" runat="server">
                       
                        <div class="col-xs-12 form-group">
			                <span class="labels">生成数量：</span>
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem>10个</asp:ListItem>
                                <asp:ListItem>20个</asp:ListItem>
                          
                            </asp:DropDownList>
		                </div>
                        <div class="col-xs-12 form-group">
			               <table style="margin-top: 10px;"><tbody><tr><td>
                               <span class="labels">生成VIP激活码序列号：</span>
                               </td>
                               <td>
                                   <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                   <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                               </td>
                               </tr></tbody></table>

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                </td></tr></tbody></table>
		                </div>

                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="clear"></div>

        </div>
    </div>
    <div class="footer_page" style="text-align:center;height:50px!important">
   
        <asp:Button ClientIDMode="Static" ID="Button2" runat="server" Text="确认(O)" CssClass="button" OnClick="Button2_Click" />
		          <input type="button" value="返回上一页(C)" onclick="history.back(); return false;" id="fhsyy" accesskey="C" class="button"/>
        <%--<asp:HiddenField ID="duotu" ClientIDMode="Static" runat="server" />--%>
        <asp:HiddenField ID="HaveDuoTu" runat="server"  ClientIDMode="Static" />
	</div>

</asp:Content>
