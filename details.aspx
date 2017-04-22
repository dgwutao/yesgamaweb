<%@ Page Language="C#" AutoEventWireup="true" CodeFile="details.aspx.cs" Inherits="details" ValidateRequest="false" MaintainScrollPositionOnPostback="true" EnableViewState="false" %>
<%@ OutputCache CacheProfile="PageDetailsCache" VaryByParam="None" %>
<%@ Register TagPrefix="skm" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<%@ Register Src="~/usercontrol/head.ascx" TagName="Head" TagPrefix="HeadUC" %>
<%@ Register Src="~/usercontrol/foot.ascx" TagName="Foot" TagPrefix="FootUC" %>
<%@ Register Src="~/usercontrol/userreply.ascx" TagName="UserReply" TagPrefix="UserReplyUC" %>
<%@ Register Src="~/usercontrol/associatepage.ascx" TagName="AssociatePage" TagPrefix="AssociatePageUC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=title %>-Yes!gama</title>
    <meta name="author" content="yes!gama" />
    <meta name="generator" content="yesgama.com" />
    <meta name="copyright" content="Copyright (c) 2010 yesgama. All Rights Reserved." />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta name="rating" content="general" />
    <meta name="keywords" content="Yes!gama,分享,互联网,it信息,新闻,影视,电影,电视,热映新片" />
    <meta name="description" content="Yes!gama-是一个专注于互联网分享的个人网站，在这里你可以找到最新的电影电视，和热门的IT新闻，我们将尽力打造全新的网络分享平台，您对本站的支持就是我们的动力！" />
    <link rel="shortcut icon" href="/favicon.ico" type="image/vnd.microsoft.icon" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="css/details.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">  
        function changeCode() {   
            var imgNode = document.getElementById("vimg");   
            imgNode.src = "/handler/WaterMark.ashx?t=" + (new Date()).valueOf();  
        }   
    </script>

</head>
<body>
    <skm:Form ID="Form1" runat="server" method="post">
        <div>
            <HeadUC:Head runat="server" />
        </div>
        <div id="main">
            <table width="980" border="0" cellspacing="0" cellpadding="0" align="center">
                <tr>
                    <td width="623" align="center" valign="top">
                        <table width="614" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="14" style="width: 14px; height: 34px; background-image: url(/images/leftTop.png)">
                                    &nbsp;
                                </td>
                                <td colspan="2" style="background-image: url(/images/top.png)">
                                    &nbsp;
                                </td>
                                <td width="13" style="width: 14px; background-image: url(/images/rightTop.png)">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td height="150" rowspan="2" style="background-image: url(/images/left.png)">
                                    &nbsp;
                                </td>
                                <td width="10" rowspan="2">
                                    &nbsp;
                                </td>
                                <td width="577" height="31" align="center" style="font-size: 16px; font-weight: bolder;
                                    color: #60F">
                                    <%=title %>
                                </td>
                                <td rowspan="2" style="background-image: url(/images/right.png)">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="left" style="font-size: 14px">
                                    <div style="float: left">
                                        <span style="font-size: 12px; color: Gray">
                                            <%=publisher %>发布于<%=time %>|阅读（<%=readcount %>）|回复（<%=reply %>）</span>
                                    </div>
                                    <!-- JiaThis Button BEGIN -->
                                    <div id="ckepop">
                                        <a title="分享到FaceBook" class="jiathis_button_fb"></a><a title="分享到twitter" class="jiathis_button_twitter">
                                        </a><a title="分享到新浪微博" class="jiathis_button_tsina"></a><a title="分享到QQ空间" class="jiathis_button_qzone">
                                        </a><a title="分享到开心网" class="jiathis_button_kaixin001"></a><a title="分享到人人网" class="jiathis_button_renren">
                                        </a><a title="分享到豆瓣" class="jiathis_button_douban"></a><a title="分享到搜狐微博" class="jiathis_button_tsohu">
                                        </a>
                                    </div>

                                    <script type="text/javascript" src="http://v1.jiathis.com/code/jia.js" charset="utf-8"></script>

                                    <!-- JiaThis Button END -->
                                    <br />
                                    <hr style="border-style: dashed; color: #CCC;" />
                                    <%=content %>
                                    <hr style="border-style: dashed; color: #CCC;" />
                                    <div id="up" runat="server" style="font-size: 12px; color: Gray">
                                        较旧一篇>:<a href="/<%=uptime %>/<%=uparticleid %>.html" target="_parent" title='<%=uparticle %>'>
                                        <%=uparticle %></a></div>
                                    <div id="down" runat="server" style="font-size: 12px; color: Gray">
                                        较新一篇>:<a href="/<%=downtime %>/<%=downarticleid %>.html" target="_parent" title='<%=downarticle %>'><%=downarticle %></a></div>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 14px; background-image: url(/images/leftBottom.png)">
                                </td>
                                <td colspan="2" style="background-image: url(/images/bottom.png)">
                                </td>
                                <td style="background-image: url(/images/rightBottom.png)">
                                </td>
                            </tr>
                        </table>
                        <table width="614" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="width: 13px; height: 33px; background-image: url(/images/dialog_lt.png)">
                                    &nbsp;
                                </td>
                                <td valign="bottom" style="background-image: url(/images/dialog_ct.png); color: #FFF;
                                    font-weight: bold;" align="left">
                                    发表评论
                                </td>
                                <td style="width: 13px; background-image: url(/images/dialog_rt.png)">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td height="65" style="background-image: url(/images/dialog_mlt.png)">
                                    &nbsp;
                                </td>
                                <td align="center" valign="top">
                                    <table width="580" border="0" cellspacing="0" cellpadding="5">
                                        <tr>
                                            <td colspan="2" align="left" height="112">
                                                <asp:TextBox ID="txtreply" Height="99px" runat="server" Width="390px" TextMode="MultiLine"
                                                    Style="margin-top: 0px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12px" align="left" width="338px">
                                                验证码：<asp:TextBox ID="txtverify" Width="70px" runat="server"></asp:TextBox><img alt="验证码"
                                                    src="/handler/WaterMark.ashx" id="vimg" title="看不清楚，换一张！" onclick="changeCode()" />
                                            </td>
                                            <td width="333">
                                                <asp:Button ID="btnok" runat="server" Text="发表评论" OnClick="btnok_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="background-image: url(/images/dialog_mrt.png)">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 13px; background-image: url(/images/dialog_lb.png)">
                                </td>
                                <td style="background-image: url(/images/dialog_cb.png)">
                                </td>
                                <td style="background-image: url(/images/dialog_rb.png)">
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="right" valign="top">
                        <UserReplyUC:UserReply runat="server" />
                        <AssociatePageUC:AssociatePage runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <FootUC:Foot ID="Foot" runat="server" />
        </div>
    </skm:Form>
</body>
</html>
