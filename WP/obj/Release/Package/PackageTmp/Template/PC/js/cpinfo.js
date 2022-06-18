$(function () {

    $(".J_com").click(function () {
        location.href = "Comment.aspx?infoid=" + $("#ContentPlaceHolder1_cinfoid").val();
    });
    $(".J_fav").click(function () {
        if ($(this).attr("class").indexOf("on") > 0) {

        }
        else {
            $.ajax({
                type: "POST",
                url: "/Template/PC/js/setfav.ashx",
                data: "infoid=" + $("#ContentPlaceHolder1_cinfoid").val() + "&title=" + escape($(".recipe_De_title").html()),
                success: function (mess) {
                    if (mess == "OK") {
                        $(".J_fav").find("span").html(parseInt($(".J_fav").find("span").html()) + 1);
                        $(".J_fav").addClass("on");
                    }
                    else if (mess == "NoLogin") {
                        location.href = "/Login.aspx";
                    }
                },
                error: function (mess) {

                }
            });

        }
    });

});