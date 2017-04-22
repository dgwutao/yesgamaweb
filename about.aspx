<%@ Page Language="C#" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="aboutus" EnableViewState="false" %>
<%@ OutputCache CacheProfile="PageAboutCache" VaryByParam="None" %>
<%@ Register Src="~/usercontrol/head.ascx" TagName="Head" TagPrefix="HeadUC" %>
<%@ Register Src="~/usercontrol/foot.ascx" TagName="Foot" TagPrefix="FootUC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Yes!gama-关于我们</title>
    <meta name="author" content="Yes!gama" />
    <meta name="generator" content="Yesgama.com" />
    <meta name="copyright" content="Copyright (c) 2010 yesgama. All Rights Reserved." />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta name="rating" content="general" />
    <meta name="keywords" content="Yes!gama-分享互联网,it信息,新闻,影视,电影,电视,热映新片" />
    <meta name="description" content="Yes!gama-是一个专注于互联网分享的个人网站，在这里你可以找到最新的电影电视，和热门的IT新闻，我们将尽力打造全新的网络分享平台，您对本站的支持就是我们的动力！" />
    <link rel="shortcut icon" href="/favicon.ico" type="image/vnd.microsoft.icon" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div><HeadUC:Head ID="Head1" runat="server" /></div>
    <div>
    <table width="980" border="0" cellspacing="0" cellpadding="5" align="center">
  <tr>
    <td width="163" align="right" style="font-weight:bolder" height="30" >关于Yes!gama</td>
    <td width="817">&nbsp;</td>
  </tr>
  <tr>
    <td height="49" align="right" valign="top">网站简介：</td>
    <td align="left" valign="top"><p>Yes!gama是一个专门做互联网信息分享的个人网站，在这里你可以找到你想要的信息!</p>
      <p>采用ASP.NET+ACCESS的架构，本网站完全开源，源码可以通过加入企鹅群向管理员索取，</p>
      <p>仅供大家交流学习之用。由衷的感谢您对本站的支持！</p></td>
  </tr>
  <tr>
    <td align="right" valign="top" height="56">联系我们：</td>
    <td height="56" align="left" valign="top"><p>企鹅群：112955219  邮箱:dgwutao#qq.com(把# 换成@)</p>
      <p>微博：<a href="http://t.sina.com.cn/yesgama" title="新浪微博" target="_blank"><img border="0" src="images/t-sina.gif" width="77" height="27" /></a><a href="http://dgwutao.t.sohu.com" target="_blank" title="搜狐微博"><img border="0" src="images/t-sohu.jpg" width="77" height="27" /></a><a href=" http://twitter.com/yesgama_com" title="twitter" target="_blank"><img border="0" src="images/t-twitter.jpg" width="79" height="29" /></a></p></td>
  </tr>
  <tr>
    <td align="right" valign="top" height="64">发展历程：</td>
    <td height="64" align="left" valign="top"><p>2010年底正式制作完成；</p>
      <p>2010年12月上线测试</p></td>
  </tr>
  <tr>
    <td align="right" valign="top" height="42">管理人员：</td>
    <td height="42" align="left">Ghost<a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=479610238&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:479610238:46" alt="QQ联系" title="QQ联系"></a></td>
  </tr>
    </table>
    </div>
    <div><FootUC:Foot ID="Foot" runat="server" /></div>
    </form>

</body>
</html>
