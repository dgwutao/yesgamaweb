<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="error" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>没有找到您要找的资源！Yes!gama-出错页</title>
    <meta name="author" content="yes!gama" />
    <meta name="generator" content="yesgama.com" />
    <meta name="copyright" content="Copyright (c) 2010 yesgama. All Rights Reserved." />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta name="rating" content="general" />
    <meta http-equiv='refresh' content='5;url=index.html'>
    <meta name="keywords" content="Yes!gama-分享互联网,it信息,新闻,影视,电影,电视,热映新片" />
    <meta name="description" content="Yes!gama-是一个专注于互联网分享的个人网站，在这里你可以找到最新的电影电视，和热门的IT新闻" />
    <link rel="shortcut icon" href="/favicon.ico" type="image/vnd.microsoft.icon" />
    <script type="text/javascript">
            var second=5;
            var timer;
            function change()
            {
                second--;
             
             if(second>-1)
             {
                 document.getElementById("second").innerHTML=second;
                 timer = setTimeout('change()',1000);
             }
             else
             {
                 clearTimeout(timer);
             }
            }
            timer = setTimeout('change()',1000);
    </script>

</head>
<body>
    <div>
        <table width="665" border="0" cellspacing="0" cellpadding="0" align="center">
            <tr>
                <td width="31" style="height: 43px; width: 31px; background-image: url(images/404/404_tl.gif)">&nbsp;
                    
                </td>
                <td colspan="2" style="background-image: url(images/404/404_bgt.gif)">&nbsp;
                    
                </td>
                <td width="39" style="width: 39px; background-image: url(images/404/404_tr.gif)">&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td height="227" rowspan="2" style="background-image: url(images/404/404_bgl.gif)">&nbsp;
                    
                </td>
                <td width="110" height="46">&nbsp;
                    
                </td>
                <td>
                    给您带来麻烦了，出错了！
                </td>
                <td rowspan="2" style="background-image: url(images/404/404_bgr.gif)">&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td height="216" valign="top">
                    <img src="images/404/404.gif" width="90" height="88" />
                </td>
                <td valign="top">
                    <p>
                        您浏览的页面已经被删除或不存在！</p>
                    <p>如有疑问可以加入Yes!gama群：112955219或发邮件至dgwutao@qq.com</p>
                    <div id="second" style="text-align: center; float: left; color: Red; font-weight: bolder">
                      5</div>
                    秒后自动返回Yes!gama首页。
                </td>
            </tr>
            <tr>
                <td style="height: 27px; background-image: url(images/404/404_bl.gif)">&nbsp;
                    
                </td>
                <td colspan="2" style="background-image: url(images/404/404_bgb.gif)">&nbsp;
                    
                </td>
                <td style="background-image: url(images/404/404_br.gif)">&nbsp;
                    
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
