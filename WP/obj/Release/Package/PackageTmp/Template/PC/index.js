$(function () {


    $(".my_select").each(function () {
        $(this).attr("tabindex", "0").attr("hidefocus", "true").attr("onblur", "hide_se(this)");
    })


	//判断浏览器是否支持placeholder属性
  	supportPlaceholder='placeholder'in document.createElement('input'),
 	placeholder=function(input){
 		var text = input.attr('placeholder'),
    	defaultValue = input.defaultValue;
 		if(!defaultValue){
 			input.val(text).addClass("phcolor");
    	}
 		input.focus(function(){
	 		if(input.val() == text){
	   			$(this).val("");
	      	}
    	});
	 	input.blur(function(){
 			if(input.val() == ""){
       			$(this).val(text).addClass("phcolor");
      		}
    	});
 	//输入的字符不为灰色
	    input.keydown(function(){
	  		$(this).removeClass("phcolor");
	    });
  	};
 	//当浏览器不支持placeholder属性时，调用placeholder函数
  	if(!supportPlaceholder){
 		$('input').each(function(){
	 		text = $(this).attr("placeholder");
	 		if($(this).attr("type") == "text"){
	 			placeholder($(this));
	      	}
	 		if($(this).attr("type") == "password"){
	 			placeholder($(this));
	      	}
    	});
  	}


  
});
function open_se(e){
    $(e).parent().addClass("open");
    $(e).parent().find(".se li").bind("click",function(){
        $(this).parent().parent().find(".f_select").html($(this).text()+"<i></i>");
        $(this).parent().parent().removeClass("open");
    });
}
function hide_se(e){
    $(e).removeClass("open");
}

function tab_fn(e){
	$(e).addClass("select").siblings().removeClass("select");
	$(e).parent().parent().find(".tab_body div").each(function(){
		if($(this).index() == $(e).index()){
			$(this).addClass("select").siblings().removeClass("select");
		}
	})
}
//首页顶部第一个轮播
var swiper = new Swiper('.news_turn', {
    pagination: {
	    el: '.swiper-pagination',
	    clickable: true,
	    renderBullet: function (index, className) {
	        return '<span class="' + className + '">' + (index + 1) + '</span>';
	    },
    },
    autoplay:true,
    loop:true,
    observer:true,//修改swiper自己或子元素时，自动初始化swiper
	observeParents:true,//修改swiper的父元素时，自动初始化swiper
});



