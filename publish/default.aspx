<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="publish_pub" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新闻发布页登录</title>
    <link href="images/Default.css" type="text/css" rel="stylesheet" />
    <link href="images/xtree.css" type="text/css" rel="stylesheet" />
    <link href="images/User_Login.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">  
        function changeCode() {   
            var imgNode = document.getElementById("vimg");   
            imgNode.src = "../handler/WaterMark.ashx?t=" + (new Date()).valueOf(); 
        }   
    </script>
</head>
<body id="userlogin_body">
    <form id="form1" runat="server">
    <center>
        <div>
            <div id="user_login">
                <dl>
                    <dd id="user_top">
                        <ul>
                            <li class="user_top_l"></li>
                            <li class="user_top_c"></li>
                            <li class="user_top_r"></li>
                        </ul>
                    </dd>
                    <dd id="user_main">
                        <ul>
                            <li class="user_main_l"></li>
                            <li class="user_main_c">
                                <div class="user_main_box">
                                    <ul>
                                        <li class="user_main_text">用户名： </li>
                                        <li class="user_main_input">
                                            <asp:TextBox ID="txtusername" runat="server" CssClass="TxtUserNameCssClass" MaxLength="20"></asp:TextBox>
                                        </li>
                                    </ul>
                                    <ul>
                                        <li class="user_main_text">密 码： </li>
                                        <li class="user_main_input">
                                            <asp:TextBox ID="txtpassword" runat="server" CssClass="TxtPasswordCssClass" TextMode="Password"></asp:TextBox>
                                        </li>
                                    </ul>
                                    <ul>
                                        <li class="user_main_text">验证码：</li>
                                        <li class="user_main_input"><asp:TextBox ID="txtverifycode" runat="server" CssClass="TxtValidateCodeCssClass"></asp:TextBox></li>
                                        <li ><img alt="" src="../handler/WaterMark.ashx" id="vimg" title="看不清楚，换一张！" onclick="changeCode()"  /></li>
                                    </ul>
                                </div>
                            </li>
                            <li class="user_main_r">
                                <asp:ImageButton ID="IbtnEnter" OnClick="IbtnEnter_Click" runat="server" CssClass="IbtnEnterCssClass" ImageUrl="images/user_botton.gif"
                                     />
                            </li>
                        </ul>
                        <dd id="user_bottom">
                            <ul>
                                <li class="user_bottom_l"></li>
                                <li class="user_bottom_c"></li>
                                <li class="user_bottom_r"></li>
                            </ul>
                        </dd>
                </dl>
            </div>
            <span id="ValrUserName" style="display: none; color: red"></span><span id="ValrPassword" style="display: none; color: red"></span><span id="ValrValidateCode" style="display: none; color: red"></span>
            <div id="ValidationSummary1" style="display: none; color: red">
            </div>
        </div>
    </center>
    </form>
</body>
</html>
