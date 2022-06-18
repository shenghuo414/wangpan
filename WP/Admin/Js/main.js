function Exit(){ }
var box=null;
var isreload=false;
function openWin(title,url,reload,width,height){ 
      if (width==null) width=760;
      if (height == null) height = 450;
	  isreload=reload;
	  box=$.dialog.open(url,{ id:'topbox',lock: true, title: title, width: width, height: height, close: function() {
       if (isreload) {
          top.frames['main'].location.reload();
          }
      }
      });
}
   
function rz() {
    //调整宽和高
  
    $(".main").height(document.body.clientHeight - $(".mainHeader").height() );
    $("#main").height(document.body.clientHeight - $(".mainHeader").height() );
}
$(function() {
   
    rz();
    $(window).resize(function () {
        rz();
    });
       
    //关于
  

   

        //顶部菜单
        $('.menu-two  > li > a').click(function (i) {
            $('.menu-two  > li > a').removeClass("curr");
            $(this).addClass("curr");
        });
        $('.pane > .icons > a').click(function (i) {
            $('.pane > .icons > a').removeClass("curr");
            $(this).addClass("curr");
        });
     
        $('.topnav li').click(function (i) {
			var i = $(this).index();
            $(this).addClass("curr").siblings("li").removeClass("curr");
			$(".navBar li:eq("+i+")").addClass("on").siblings("li").removeClass("on");
            $(".rightnav .content:eq("+i+")").fadeIn(300).siblings(".content").hide();
            if (isCloseLeft) closeLeft();
        });
		$(".navBar li").click(function(){
			var i = $(this).index();
			$(".topnav li:eq("+i+")").addClass("curr").siblings("li").removeClass("curr");
			$(".rightnav .content:eq("+i+")").fadeIn(300).siblings(".content").hide();
			$(this).addClass("on").siblings("li").removeClass("on");
		});


    });


