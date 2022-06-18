<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="Food.UserInfo" %>

<html><head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=Edge">
    <title>
	网盘---网站后台管理
</title>
    <script src="/Admin/Js/jquery-1.11.0.min.js"></script>
    <link href="Template/PC/js/layui/css/layui.css" rel="stylesheet" />
 
    <script src="Template/PC/js/layui/layui.all.js"></script>
<%--    <script src="/Admin/Js/layer.js"></script>
    <link href="/Admin/Css/layer.css" rel="stylesheet" />--%>
    <link href="/Admin/Css/font-icons/entypo/css/entypo.css" rel="stylesheet" />
    <script src="/Admin/Js/main.js"></script>
    <script src="/Admin/Js/prettyPhoto/jquery.prettyPhoto.js"></script>
    <link href="/Admin/Js/prettyPhoto/prettyPhoto.css" rel="stylesheet" />
    <script src="/Admin/Js/index.js"></script>
    <link href="/Admin/Css/style.css" rel="stylesheet" />

    <link href="/Admin/Css/menu.css" rel="stylesheet" />
</head>

<body class="prebody s3" style="overflow:hidden" scroll="no">

<form runat="server" id="form1">

  <div class="mainHeader" style="height:62px;background: #fff; line-height:64px;
    border-bottom: 2px inset #eee; ">
       
  	<div class="navBar">
          <img src="Images/logo.png" style="margin-top:15px"/>   
    </div>
	
         <div class="r-button">
            <ul>
                 <li><img id="Img1" src="<%=CheckSession(Session["LoginPic"]) %>" class="tx"></li>
              <li class="userinfo">
                 
                 <span id="uname" style="color:#424e67">
                     <%=CheckSession(Session["LoginLoginName"]) %>
                     <%=CheckSession(Session["UserLevel"]).ToString()=="VIP超级会员"?"<span style='color:red;font-size:12px'>【VIP】</span>":"" %>
                 </span>
              	<div class="operating">
                	<div class="arrow"></div>
                    <div class="name"><%=CheckSession(Session["LoginLoginName"]) %><font class="mainColor"><%=CheckSession(Session["LoginTitle"]) %></font></div>
                    <div class="info"><em>登录时间：</em>
                        <%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>
                    </div>
                    <div class="btn">
                        <a href="UpdatePass.aspx" title="修改密码" target="main"><i class="myicon icon-password"></i>修改密码</a>
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
            //layer.alert("111");
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
       <style>
           .tx {
width: 30px;height: 30px;margin:auto;border-radius:50px;

}
           .ldiv{
            line-height:38px;
            height:38px;margin-left:50px;
            font-size:16px;
            color:#999;
           } .bar {
    position: relative;
}.remainingSpaceUi {
    height: 8px;
    width: 155px;
    background: #42aee7;
    background: rgba(0,0,0,.1);
    line-height: 0;
    _font-size: 0;
    border-radius: 10px;
    overflow: hidden;
    top: 0;
    left: 0;
} .remaining-space {
    position: relative;
    top: 7px;
    float: left;
} .DIeHPCb span {
    font-size: 12px;
    position: relative;
    top: 0;
    left: 0;
}.GELdyA {
    text-align: right;
    margin-top: 4px;
    float: right;
} .GELdyA a {
    border: 0;
    color: #09AAFF;
    background: 0 0;
    text-align: right;
}
  .DIeHPCb span {
    font-size: 12px;
    position: relative;
    top: 0;
    left: 0;
}
 .remainingSpaceUi_span {
               height: 8px;
               line-height: 0;
               _font-size: 0;
               display: block;
               border-radius: 10px;
               transition-property: width;
               transition-delay: .3s;
               transition-timing-function: linear;
           }
           .tDuODs {
    margin: 8px 20px;
    width: 155px;
    color: #424e67;
        position: absolute;
    bottom: 10px;
}
       </style>
     <div class="leftmain" style="padding-left:0px;background-color:#f7f7f7;width:196px;">
       	 
           <div style="margin-top:20px;" class="ldiv"><a href="LookFile.aspx" target="main">全部文件</a></div>
           <div class="ldiv"><a href="LookFile.aspx?type=pic" target="main">图片</a></div>
           <div class="ldiv"><a href="LookFile.aspx?type=word" target="main">文档</a></div>
           <div class="ldiv"><a href="LookFile.aspx?type=video" target="main">视频</a></div>
           <div class="ldiv"><a href="LookFile.aspx?type=torrent" target="main">种子</a></div>
           <div class="ldiv"><a href="LookFile.aspx?type=music" target="main">音乐</a></div>
           <div class="ldiv"><a href="LookFile.aspx?type=other" target="main">其它</a></div>

         <div style="background-color: rgba(59,140,255,.1);
    color: #09AAFF;    width: 90%;
    margin-left: 5%;position: absolute;
    bottom: 60px;
    border: 1px solid #09AAFF;" runat="Server" id="sjdiv">		
             <div class="get-capacity" style="line-height:33px;color: #09AAFF;text-align:center">
                 <span>
                     <a node-type="pylkbrk" href="ActiveVIP.aspx" target="main">
                    开通会员，升至10G超大容量</a>
                 </span>
             </div>	
         </div>

         <ul class="tDuODs">		
             <li class="g-clearfix bar">		
                 <div node-type="cuamNdqk" class="remainingSpaceUi">			
                     <span node-type="ypu0YLk" class="remainingSpaceUi_span" runat="Server" id="jdtspan">
                     </span>		
                 </div>		
                 <div class="DIeHPCb remaining-space">			
                     <span node-type="pfgn53k" class="bold" runat="server" id ="yyspan"></span>/<span node-type="brkBg0" runat="Server" id="wyspan"></span>		
                 </div>		
                 <div class="GELdyA">          
                     <a node-type="cmukQv0" target="main" href="ActiveVIP.aspx">扩容</a>
                 </div>		
             </li>	
         </ul>

	</div>
	<div class="rightmain" style="margin-left: 197px;">
    
    <iframe src="LookFile.aspx" id="main" name="main" frameborder="0" scrolling="auto" style="width: 100%;"> </iframe>
       
   </div>	

 </div>

<div class="clear"></div>

    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />

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
