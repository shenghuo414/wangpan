<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActiveVIP.aspx.cs" Inherits="Food.ActiveVIP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Template/PC/js/jquery-1.11.0.min.js"></script>
    <script src="Template/PC/js/layui/layui.all.js"></script>
     <link href="/Template/PC/js/layui/css/layui.css" rel="stylesheet">
     <link href="Admin/Css/style.css" rel="stylesheet" />
    <style>
       .nl_loginitem .text {
    height: 22px;
    border: 1px solid #ddd;
    border-radius: 4px;
    line-height: 22px;
    font-size: 14px;
    color: #333;
    padding: 11px;
    width: 66px;
    font-family: "Hiragino Sans GB","冬青黑体","Microsoft Yahei","微软雅黑";
}
       .nl_loginitem .button {
    display: inline-block;
    vertical-align: top;
    height: 42px;
    border: 1px solid #09AAFF;
    border-radius: 4px;
    line-height: 40px;
    font-size: 15px;
    color: #fff;
    padding: 0px 24px;
    font-family: "Hiragino Sans GB","冬青黑体","Microsoft Yahei","微软雅黑";
    background: #09AAFF;
    cursor: pointer;
    width: 320px;
}
       .nl_loginitem{
           margin-bottom:10px;
       }
    </style>
</head>
<body style="background:#fff;">

    <form id="form1" runat="server">
     <div id="manage_top" class="toptitle menu_top_fixed">激活VIP</div>
    <div class="menu_top_fixed_height"></div>
    <div class="content-area">
            <div class="nl_loginitem">
				<input runat="server" type="text" id="UserName" class="text onlyNumAlpha" placeholder="">
                -
                <input runat="server" type="text" id="Text1" class="text onlyNumAlpha" placeholder="">
                -
                <input runat="server" type="text" id="Text2" class="text onlyNumAlpha" placeholder="">
                -
                <input runat="server" type="text" id="Text3" class="text onlyNumAlpha" placeholder="">
			</div>
			 
			<div class="nl_loginitem" >
                <asp:Button ID="Button1" runat="server" Text="激活VIP超级会员" CssClass="button" OnClick="Button1_Click" />
			</div>   
    </div>
    </form>
</body>
</html>
