<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Food.Admin.Login" %>
<html>
    <head>
<title>
	网盘---网站后台管理
</title>
    <script src="Js/jquery-1.11.0.min.js"></script>
    <script src="Js/layer.js"></script>
        <link href="Css/layer.css" rel="stylesheet" />
    <%--<script src="Js/bgstretcher.js"></script>--%>
<!--[if IE 6]>
  <script src="Js/iepng.js" type="text/javascript"></script>
  <script type="text/javascript">
    try{
     EvPNG.fix('div, ul, img, li, input, em, a, p,i,b,span,em,' ); 
    }catch(e){
    }
  </script>
  <![endif]-->
        <style>
            .mt {
            margin-top:0px!important;
            }
        </style>
<script>

    $(function () {
        //if (!isPlaceholderSupport()){
        var ch = $(document).height();
        var bh = $(".connect").height();
        $(".connect").css("margin-top", (ch - bh) / 2);
        $("#UserName").focus(function () {
            if ($(this).val() == '请输入登录账号') {
                $(this).val('');
            }
            $(this).removeClass("put").addClass("puton");

        }).blur(function () {
            if ($(this).val() == '') { $(this).val('请输入登录账号'); }
            if ($(this).val() == '请输入登录账号') {
                $(this).removeClass("puton").addClass("put");
            }
        }).val('请输入登录账号');


        $("#UserPass").focus(function () {
            if ($(this).val() == '******') {
                $(this).val('');
            }
            $(this).removeClass("put").addClass("puton");
        }).blur(function () {
            if ($(this).val() == '') { $(this).val('******'); }
            if ($(this).val() == '******') {
                $(this).removeClass("puton").addClass("put");
            }
        }).val('******');


        $("#AdminLoginCode").focus(function () {
            if ($(this).val() == '******') { $(this).val(''); }
            $(this).removeClass("put").addClass("puton");

        }).blur(function () {
            if ($(this).val() == '') { $(this).val('******'); }
            if ($(this).val() == '******') {
                $(this).removeClass("puton").addClass("put");
            }
        }).val('******');



        $("#ValidateCode").focus(function () {
            if ($(this).val() == '验证码') { $(this).val(''); }
            $(this).removeClass("put").addClass("puton");

        }).blur(function () {
            if ($(this).val() == '') { $(this).val('验证码'); }
            if ($(this).val() == '验证码') {
                $(this).removeClass("puton").addClass("put");
            }
        }).val('验证码');





        //}
    });

    function CheckForm() {
        if (jQuery("#UserName").val() == '' || jQuery("#UserName").val() == '请输入登录账号') {
            
            alert('请输入登录用户名！');
            jQuery("#UserName").focus();
            return false;
        }
        else if (jQuery("#UserPass").val() == '' || jQuery("#UserPass").val() == '******') {
           
            alert('请输入登录密码！');
            jQuery("#UserPass").focus();
            return false;
        }
        else {
            return true;
        }
    }

 </script>
        <link href="Css/login.css" rel="stylesheet" />
 

    </head>



<body class="bgStretcher-container">
   
 <form runat="server" id="form1">





 <div class="connect clearfix">
      
      <div class="loginbox">
              
         
         <div class="box">
         	<div class="m-title"><img src="Images/login-tilte.png" alt="管理员登录" style="left: 0%;"></div>
            <ul>
                   <li class="loginput">
                       <asp:TextBox ID="UserName" ClientIDMode="Static" runat="server" CssClass="username put" MaxLength="20"></asp:TextBox>
                       
                   </li>
                   <li style="position:relative;" class="loginput">
                       <asp:TextBox ID="UserPass" TextMode="Password" runat="server" MaxLength="50" CssClass="password put" ></asp:TextBox>
                   </li>
                 <li class="loginput">
                      
                      <script type="text/javascript">
                          function codech() {
                              image = document.getElementById('codeimage');
                              image.src = 'UseCheckCode.aspx?a=' + Math.random();
                          }
                            </script>
                       <asp:TextBox ID="ValidateCode" ClientIDMode="Static" runat="server" CssClass="code put" MaxLength="20"></asp:TextBox>
                       <img src="UseCheckCode.aspx" alt="验证码" style="width: 150px;height: 44px;float: right;margin-right: 20px;" id="codeimage"
                                title="点击换一张" onclick="codech()" />
                   </li>
                   <li class="loginput loginin">
                       <asp:Button ID="Button1" runat="server" Text="登录" CssClass="btn btn-submit mt" OnClick="Button1_Click" />
                       
                       <input name="" value="取消" type="button" class="btn btn-reset" onclick="javascript: location.href = '/';" style="margin-top:10px">
                   </li>
            </ul>
            <div class="clear"></div>
         </div>

      </div>

  </div>




</form>

</body></html>
