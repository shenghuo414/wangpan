$(function () {
    $("#dbut").click(function () {
        
        
   
        if ($("#KnowledgeID").val() == "")
        {
            layer.alert('请选择试题类型！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
        }
        else if ($("#QuestionLevel").val() == "请选择...")
        {
            layer.alert('请输入题目难度！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
        }
        else if ($("#Score").val() == "")
        {
            layer.alert('请输入默认分值！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
        }
        else if ($("#upfile").val() == "")
        {
            layer.alert('请上传Word文件！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
        }
        else
        {
            var index = layer.load(1, {
                shade: [0.6, '#000'] //0.1透明度的白色背景
            });
            var data = "classid=" + $("#ClassID").val() + "&wordname=" + $("#upfile").val() + "&level=" + $("#QuestionLevel").val() + "&knowid=" + $("#KnowledgeID").val() + "&score=" + $("#Score").val();
            $.ajax({
                type: "POST",
                url: "../Ajax/submit_upload.ashx",
                data: data,
                success: function (msg) {
                  
                    if (msg == "Parameters Error") {
                        layer.close(index);
                        layer.alert('参数错误！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                    } else if (msg == "Success") {
                        layer.close(index);
                        layer.alert('操作成功！', { icon: 1, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } }, function () { location.href = 'ContentManage.aspx?&channelid=1000015'; });
                    }
                    else {
                        layer.close(index);
                        layer.alert('操作失败！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                    }
                },
                error: function (msg) {
                    layer.close(index);
                    layer.alert('操作失败！', { icon: 2, kin: 'layer-ext-moon', closeBtn: 0, success: function () { $(':focus').blur(); } });
                }

            });
        }
    });
});