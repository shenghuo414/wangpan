<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Share.aspx.cs" Inherits="Food.Share" %>
<html><head>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=7,9,10,11">
<meta name="renderer" content="webkit">
    <link href="Template/PC/js/layui/css/layui.css" rel="stylesheet" />
    <script src="Template/PC/js/jquery-1.11.0.min.js"></script>
    <script src="Template/PC/js/layui/layui.all.js"></script>
<meta content="max-age=30" http-equiv="Cache-Control">
<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=0">
    <style>
        #doc {
    background-color: #eef2f6;
    position: absolute;
    width: 100%;
    height: 100%;
}.acss-header {
    display: block;
    position: absolute;
    top: 50%;
    left: 50%;
    margin: -240px 0 0 -230px;
    z-index: 1;
}.verify-form {
    margin: 0 auto;
    width: 460px;
    height:248px;
    text-align: left;
    font-size: 14px;
    position: relative;
    background: #fff;
    border-radius: 4px;
    box-shadow: 0 0 10px rgba(171,198,235,.3);
}.acss-header .CMxQsC {
    background: url(/images/share_tit_bg_37f871e.png) no-repeat;
    background-size: 100% 100%;
    border-top-left-radius: 4px;
    border-top-right-radius: 4px;
    height:80px;
}.verify-property {
    color: #fff;
    height: 60px;
    line-height: 60px;
    margin: 10px 0;
    font-size: 12px;
}.verify-property strong {
    margin: 1px 10px 0 0;
    float: left;
    _display: inline;
    font-size: 14px;
}.verify-input dt {
    padding: 0 0 5px;
    margin: 20px 0 10px;
    color: #666;
    font-weight: 500;
}.verify-input .input-area {
    position: relative;
}.QKKaIE {
    width: 240px;
}
.LxgeIt {
    width: 240px;
    border: 1px solid #f2f2f2;
    padding: 8px 10px;

    line-height: 19px;
    border-radius: 4px;
}.g-button:link, .g-button:visited {
    color: #fff;
    text-decoration:none;
}
.verify-form .g-button-blue-large {
    border-radius: 4px;
    margin-left: 14px;
        height: 34px;
    display: inline-block;
    line-height: 34px;
}.verify-form .g-button-large .g-button-right, .verify-form .g-button-blue-large .g-button-right {
    height: 34px;
    line-height: 34px;
}
.g-button .g-button-right {
    height: 32px;
    line-height: 32px;
    padding-right: 10px;
    text-align: center;
    cursor: pointer;
}.g-button-blue-large {
    border: 1px solid #09AAFF;
    background: #09AAFF;
}
.g-button-large, .g-button-blue-large {
    padding-left: 10px;
    height: 32px;
}
 .avatar {
    padding: 15px 10px 15px 25px;
}
.avatar, .verify-property, .b-btn-8, .LxgeIt {
    float: left;
}
.photo-frame, .photo-frame span {
    width: 44px;
    height: 44px;
    overflow: hidden;
    border-radius: 60px;
}
.photo-frame {
    padding: 3px;
    background: #9ADAF2;
}.ac-close {
    padding: 20px 30px 40px;
}
.verify-input {
    float: left;
    width: 400px;
}.verify-input .pickpw {
    padding: 0 0 15px;
}.verify-input dt {
    padding: 0 0 5px;
    margin: 20px 0 10px;
    color: #666;
    font-weight: 500;
}.acss-header {
    display: block;
    position: absolute;
    top: 50%;
    left: 50%;
    margin: -240px 0 0 -230px;
    z-index: 1;
}
        html {
            *overflow-y: hidden!important;
        }
        /* layout begin */
        #layoutApp {
            position: absolute;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            min-width: 1186px;
            _width: 100%;
            _height: 630px;
            font: 14px 'Microsoft YaHei', 'SimSun';
        }
        #layoutHeader {
            position: absolute;
            width: 100%;
            height: 65px;
            top: 0;
            right: 0;
            left: 0;
            z-index: 41;
        }
        #layoutAside {
            position: absolute;
            width: 190px;
            min-height: 350px;
            top: 65px;
            left: 0;
            bottom: 0;
            border-right: 1px solid #e2e5e6;
            background: #f2f2f2;
            z-index: 9;
        }
        #layoutMain {
            position: absolute;
            top: 65px;
            left: 191px;
            bottom: 0;
            right: 0;
            z-index: 1;
        }
        #doc{
            background-color: #eef2f6;
            position: absolute;
            width: 100%;
            height: 100%;
        }
        /* layout end */
        .init-docs .cloud-bg {
    position: absolute;
    bottom: 0;
    left: 0;
    width: 100%;
    height: 400px;
}.init-docs .cloud-bg .bg1 {
    position: absolute;
    width: 100%;
    height: 400px;
    background: url(/images/footer-cloud_83b2a75.png);
    background-repeat: repeat-x;
    background-position: 0 bottom;
    bottom: 0;
}
        .acss_banner {
            width: 212px;
            height: 55px;background-repeat: no-repeat;
    margin: 0 auto 30px;
                background-image: url(/images/biglogo.png);
        }
    </style>




    <body style="margin:0px">

        <form runat="server" id="form1">


<div class="docs init-docs" id="doc">
<div class="acss-header" id="xogtBlkk">
<div class="acss_banner"></div>
<div class="verify-form">

<div class="CMxQsC">
<div class="avatar">
<div class="photo-frame">
<a href="//yun.baidu.com/buy/center?tag=8&amp;from=sicon" class="v-icon unvip-icon"><em></em></a>
<span class="radius-3"><img alt="185*****519" onload="if(this.offsetHeight>this.offsetWidth){this.style.height=&quot;44px&quot;;this.style.width=&quot;auto&quot;;}" src="https://ss0.bdstatic.com/7Ls0a8Sm1A5BphGlnYG/sys/portrait/item/5cd6bb40.jpg" width="44"></span>
</div>
</div>
<span class="verify-property"><strong>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal></strong>给您加密分享了文件</span>
<div class="cb"></div>
</div>
<div class="verify-input ac-close clearfix">
<dl class="pickpw clearfix">
<dt>
请输入提取码：</dt>
<dd class="clearfix input-area">
<input class="QKKaIE LxgeIt" id="hvyVEbB" tabindex="1" type="text" runat="Server">
<div id="eci20zV"><a class="g-button g-button-blue-large" data-button-id="b1" data-button-index="" href="javascript:down();" title="提取文件"><span class="g-button-right"><span class="text" style="width: auto;">提取文件</span></span></a></div>
</dd>
</dl>
</div>

<div id="tqBan2" style="display: block;"></div>
</div>
</div>
<div class="cloud-bg">
<div class="bg1"></div>
<div class="bg2"></div>
<div class="bg3"></div>
</div>


</div>
            <div style="display:none">
            <asp:HiddenField runat="server" ID="HiddenField2"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="HiddenField1"></asp:HiddenField>
            <asp:Button runat="server" Text="Button" ID="Button2" OnClick="Button2_Click" />
</div>
            <script>
                function down()
                {
     
                    $("#<%=Button2.ClientID%>").click();
                }
            </script>
        </form>

</body>

</html>