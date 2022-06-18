
$(function () {

    var qx = "|" + $("#HiddenField1").val() + "|";

    
    if (qx.indexOf("|yh|") < 0) {
        $(".navBar").find("ul li").eq(2).remove();
        $(".topnav").find("ul li").eq(2).remove();
        $("#left4").remove();
    }
    else {
        if (qx.indexOf("|gly|") < 0) {
            $("#left4").find(".menu-one").eq(0).remove();
        }
        else {
            $("#left4").find(".menu-one").eq(0).find(".menu-two").find("li").each(function () {
                if (qx.indexOf($(this).attr("vid")) < 0) {
                    $(this).remove();
                }
            });
        }

        if (qx.indexOf("|yhgl|") < 0) {
            $("#left4").find(".menu-one").eq(1).remove();
        }
        else {
            $("#left4").find(".menu-one").eq(1).find(".menu-two").find("li").each(function () {
                if (qx.indexOf($(this).attr("vid")) < 0) {
                    $(this).remove();
                }
            });
        }
    }

    if (qx.indexOf("|xx|") < 0) {
        $(".navBar").find("ul li").eq(0).remove();
        $(".topnav").find("ul li").eq(0).remove();
        $("#left0").remove();
    }
    else {
        if (qx.indexOf("|nrgl|") < 0) {
            $("#left0").find(".firstChild").eq(0).remove();
        }
        else {
            $("#left0").find(".firstChild").eq(0).find(".menu-two").find("li").each(function () {
                if (qx.indexOf($(this).attr("vid")) < 0) {
                    $(this).remove();
                }
            });
        }
        if (qx.indexOf("|gnxx|") < 0) {
            $("#left0").find(".firstChild").eq(1).remove();
        }
        else {
            $("#left0").find(".firstChild").eq(1).find(".menu-two").find("li").each(function () {
                if (qx.indexOf($(this).attr("vid")) < 0) {
                    $(this).remove();
                }
            });
        }
    }


    $(".navBar").find("ul li").eq(0).addClass("on");
    $(".topnav").find("ul li").eq(0).addClass("curr");
    $(".topnav").find("ul").css("display", "block");
});

