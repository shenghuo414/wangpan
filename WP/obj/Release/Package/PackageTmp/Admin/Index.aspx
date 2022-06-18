<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Food.Admin.Index" %>

<html><head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=Edge">
    <title>
	网盘---网站后台管理
</title>
    <script src="Js/jquery-1.11.0.min.js"></script>
    <script src="Js/layer.js"></script>
    <link href="Css/layer.css" rel="stylesheet" />
    <link href="Css/font-icons/entypo/css/entypo.css" rel="stylesheet" />
    <script src="Js/main.js"></script>
    <script src="Js/prettyPhoto/jquery.prettyPhoto.js"></script>
    <link href="Js/prettyPhoto/prettyPhoto.css" rel="stylesheet" />
    <script src="Js/index.js"></script>
    <link href="Css/style.css" rel="stylesheet" />
    <style>
        
.drp {
    width: 20.2%;
    position: absolute;
    right: 2.1%;
    z-index: 777;
    height: 58px;
    background: #f37334;
    color: #fff;
    font-size: 16px!important;
    padding-left: 1.5%;
    cursor: pointer;
}
.drp p {
    margin: 0;
    line-height: 56px;
    height: 56px;
    background: #f37334;
    color: #fff;
    font-size: 16px!important;
}
.drp_position_ul {
    list-style: none;
    position: absolute;
    left: 0;
    top: 58px;
    width: 100%;
    height: 380px;
    background: #fff;
    border: 1px solid #efefef;
    padding: 0;
    margin: 0;
    overflow-y: scroll;
}
    </style>
<!--[if IE 6]>
  <script src="../admin/include/iepng.js" type="text/javascript"></script>
  <script type="text/javascript">
    try{
     EvPNG.fix('div, ul, img, li, input, em, a, p,i,b,span,em,' ); 
    }catch(e){
    }
  </script>
  <![endif]-->
<style>
.message
{
DISPLAY:NONE;
}
.treep{
        padding-left: 20px;
    margin-top: 10px;
    font-size:14px!important;
}
</style>
    <link href="Css/menu.css" rel="stylesheet" />
</head>

<body class="prebody s3" style="overflow:hidden" scroll="no"><div class="" style="display: none; position: absolute;"><div class="aui_outer"><table class="aui_border"><tbody><tr><td class="aui_nw"></td><td class="aui_n"></td><td class="aui_ne"></td></tr><tr><td class="aui_w"></td><td class="aui_c"><div class="aui_inner"><table class="aui_dialog"><tbody><tr><td colspan="2" class="aui_header"><div class="aui_titleBar"><div class="aui_title" style="cursor: move;"></div><a class="aui_close" href="javascript:/*artDialog*/;">×</a></div></td></tr><tr><td class="aui_icon" style="display: none;"><div class="aui_iconBg" style="background: none;"></div></td><td class="aui_main" style="width: 820px; height: 480px;"><div class="aui_content" style="padding: 20px 25px;"></div></td></tr><tr><td colspan="2" class="aui_footer"><div class="aui_buttons" style="display: none;"></div></td></tr></tbody></table></div></td><td class="aui_e"></td></tr><tr><td class="aui_sw"></td><td class="aui_s"></td><td class="aui_se" style="cursor: se-resize;"></td></tr></tbody></table></div></div>

<form runat="server" id="form1">

  <div class="mainHeader">
       
  	<div class="navBar">
        	<ul>
                <li class="on" >信息</li>

                <li class="">用户</li>
       
            </ul>            
        </div>
	
         <div class="r-button">
            <ul>
              <li class="userinfo">
                 <span id="uname"><%=CheckSession(Session["LoginName"]) %></span>
              	<div class="operating">
                	<div class="arrow"></div>
                    <div class="name"><%=CheckSession(Session["LoginName"]) %><font class="mainColor"><%=CheckSession(Session["RealName"]) %></font></div>
                    <div class="info"><em>登录时间：</em>
                        <%=CheckSession(Session["LastLoginTime"]) %>
                    </div>
                    <div class="btn">
                        <a href="User/UpdatePass.aspx" title="修改密码" target="main"><i class="myicon icon-password"></i>修改密码</a>
                        <a href="javascript:WindowExit();" title="退出"><i class="myicon icon-out"></i>安全退出</a>
                    </div>    
                </div>
              </li>
                 
            </ul>
            <div id="wrapbg"></div>
         </div>
    </div>  
  	<!---mainHeader end-->
    
    <script>

        $(function () {
            $("li.userinfo").hover(function () {
                $(this).find(".operating").show();
            }, function () {
                $(this).find(".operating").hide();
            });
            $("#navbox-trigger").click(function () {
                $("#wrapbg").fadeIn(300);
                $(".navbox").animate({ right: "0px" }, 300);
            });
            $("#wrapbg,.close,.shut").click(function () {
                closeTool();
            });

            //侧栏是否打开
            //var has = $(".leftmain div").hasClass("topnav");
            //if(has==false){
            //    $(".main").addClass("noTopnav");
            //};


            //auto();
            //$(window).resize(function(){
            //    auto();
            //});
        });

        $("#ShowAnnounce").load(function () {
            $(this).contents().find("body").attr("style", "font-family:'HelveticaLT55Roman',arial,'microsoft yahei ui','microsoft yahei',simsun,sans-serif;");
        });


        function closeTool() {
            $("#wrapbg").fadeOut(300);
            $(".navbox").animate({ right: "-320px" }, 300);
        };
        function auto() {
            if ($(window).width() < 1500) {
                $("#ShowAnnounce").hide();
            }
            else {
                $("#ShowAnnounce").show();
            };
        };

        //导航适屏
        navauto();

        $(window).resize(function () {
            navauto();
        });
        function navauto() {
            var w = $(window).width();
            var num = $(".navBar li").length;
            if (num > 8 && w < 1360) {
                $(".navBar").addClass("navAuto")
            };

        };


    </script>


   <div class="main clearfix" style="height: 1697px;">

     <div class="leftmain">
       	 
           <div class="topnav" tabindex="5001" style="overflow: hidden; outline: none;">
             <ul style="display:none">
               <li><span class="cont-icon"></span><em class="textbg">信息</em></li>
               <li class=""><span class="user-icon"></span><em class="textbg">用户</em></li>
            </ul>
       </div>
        
	
       <div class="rightnav" tabindex="5000" style="overflow: hidden; outline: none;">
       
                 <div class="content" id="left0" style="">
                        <ul class="menu-one">

                            <li class="firstChild">
                                  <div class="header">
					                   <span class="txt"><i class="iconfont font1"></i>内容管理</span>
					                    <span class="arrow"></span>
				                   </div>
				          <ul class="menu-two" style="display:block">

                              <li vid='|1000044|'><a href="Content/ContentManage.aspx" target="main">文件信息管理</a>
									  </li>
                                      <li vid='|1000015|'><a href="Content/ContactManage.aspx" target="main">VIP激活码管理</a>
									  </li>
								
										  <li vid='|1000054|'><a href="Content/UserManage.aspx" target="main">用户信息管理</a>
									  </li>
                           </ul>
                         </li>
         
                              
                        </ul>
                    </div>
                
                
                 <div class="content" id="left4" style="display: none;">
                        <ul class="menu-one">

                            
                               
                              
                                <li>
				                    <div class="header">
					                    <span class="txt"><i class="font1 iconfont"></i>管理员</span>
					                    <span class="arrow"></span>
				                    </div>
				                    <ul class="menu-two">


                                        <li vid="|glygl|"><a href="User/AdminManage.aspx" target="main">管理员管理</a></li>
                                        <li vid="|bmgl|"><a href="Depart/ManageDepart.aspx" target="main">部门管理</a></li>
                                        <li vid="|yhzgl|"><a href="Depart/ManageGroup.aspx" target="main">用户组管理</a></li>
				                    </ul>
			                    </li>
                              
                            
                              
                        </ul>
                  
                    </div>

 
                
        </div>
	</div>
	<div class="rightmain" >
    
    <iframe src="" id="main" name="main" frameborder="0" scrolling="auto" style="width: 100%;"> </iframe>
       
   </div>	

 </div>

<div class="clear"></div>

    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
    <script src="Js/base64.js"></script>
    
    <script src="Js/list.js"></script>
    </form>

    
<%--<script src="../admin/images/jquery.nicescroll.js"></script>--%>
<script>
    function HourExit() {
        layer.confirm('登录超时，确定要退出系统吗？', {
            skin: 'layer-ext-moon',
            closeBtn: 0,//样式类名
            btn: ['确定', '取消'] //按钮
        }, function () {
            $.ajax({
                type: "POST",
                url: "ajax/clearsession.ashx",
                data: null,
                success: function (msg) {
                    location.href = "Login.aspx";
                },
                error: function (msg) {
                    layer.alert('操作失败！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0 });
                }

            });
        }, function () {

        });
    }
    function WindowExit() {
        layer.confirm('确定要退出系统吗？', {
            skin: 'layer-ext-moon',
            closeBtn: 0,//样式类名
            btn: ['确定', '取消'] //按钮
        }, function () {
            location.href = "Login.aspx";
        }, function () {

        });
    }
    function sp(url, width, height, title) {

        layer.open({
            type: 2,
            title: title,
            scrollbar: false,
            shadeClose: false,
            shade: 0.8,
            area: [width, height],
            content: url
        });
        //if (parseInt($(".layui-layer-iframe").css("top").replace("px", "")) > 100) {
        //$(".layui-layer-iframe").css("top", "70px");
        //}
        $(".layui-layer-shade").css("z-index", "999");
        $(".layui-layer-iframe").css("z-index", "1000");
    };

    function bp(url, width, height, title, cid) {

        var id = $("#main").contents().find("#" + cid).val();
        //alert(id);
        layer.open({
            type: 2,
            title: title,
            scrollbar: false,
            shadeClose: false,
            shade: 0.8,
            area: [width, height],
            content: url + id
        });
        //if (parseInt($(".layui-layer-iframe").css("top").replace("px", "")) > 100) {
        //$(".layui-layer-iframe").css("top", "70px");
        //}
        $(".layui-layer-shade").css("z-index", "999");
        $(".layui-layer-iframe").css("z-index", "1000");
    };




</script>



</body></html>

