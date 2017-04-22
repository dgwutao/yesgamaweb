<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_Default" EnableViewStateMac="true" %>
<%@ OutputCache CacheProfile="PageDefaultCache" VaryByParam="None" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/usercontrol/head.ascx" TagName="Head" TagPrefix="HeadUC" %>
<%@ Register Src="~/usercontrol/foot.ascx" TagName="Foot" TagPrefix="FootUC" %>
<%@ Register Src="~/usercontrol/newscommend.ascx" TagName="Newscommend" TagPrefix="NewscommendUC" %>
<%@ Register Src="~/usercontrol/newshot.ascx" TagName="Newshot" TagPrefix="NewshotUC" %>
<%@ Register Src="~/usercontrol/newsreply.ascx" TagName="Newsreply" TagPrefix="NewsreplyUC" %>
<%@ Register Src="~/usercontrol/topnews.ascx" TagName="TopNews" TagPrefix="TopNewsUC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yes!gama-分享互联网</title>
    <meta name="author" content="Yes!gama" />
    <meta name="generator" content="yesgama.com" />
    <meta name="copyright" content="Copyright (c) 2010 Yes!gama All Rights Reserved." />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta name="rating" content="general" />
    <meta name="keywords" content="Yes!gama-分享互联网,it信息,新闻,影视,电影,电视,热映新片,IT,Movie,Music" />
    <meta name="description" content="Yes!gama-是一个专注于互联网分享的个人网站，在这里你可以找到最新的电影电视，和热门的IT新闻，我们将尽力打造全新的网络分享平台，您对本站的支持就是我们的动力！" />
    <link rel="shortcut icon" href="/favicon.ico" type="image/vnd.microsoft.icon" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="css/Progress.css" rel="stylesheet" type="text/css" />
    <link href="css/aspnetpager.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
            function onUpdating(){
                var pnlPopup = $get('<%= this.pnlPopup.ClientID %>');                 
                pnlPopup.style.display = '';	    
               Sys.UI.DomElement.setLocation(pnlPopup, 150, 380);    
            }
            function onUpdated() {
                var pnlPopup = $get('<%= this.pnlPopup.ClientID %>'); 
                pnlPopup.style.display = 'none';
            } 
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <HeadUC:Head runat="server" />
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="980px" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td width="623" align="left" valign="top">
                <table width="616" border="1" bordercolor="#24B8FF" style="border-collapse: collapse"
                    cellspacing="0" cellpadding="2">
                    <tr>
                        <td height="221" valign="middle">
                            <table width="610" height="232" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="264" height="232">

                                        <script type="text/javascript" language="javascript">
                                             <!--
                                             var focus_width=264;
                                             var focus_height=214;
                                             var text_height=18;
                                             var swf_height = focus_height+text_height;
                                             var pics='<%=pictxt%>';
                                             var links='<%=linktxt%>';
                                             var texts='<%=titletxt%>';
                                             document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000"  width="'+ focus_width +'" height="'+ swf_height +'">');
                                             document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="/images/playswf.swf"><param name=wmode value=transparent><param name="quality" value="high">');
                                             document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
                                             document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'">');
                                             document.write('<embed src="/images/playswf.swf" wmode="opaque" FlashVars="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'" menu="false"  bgcolor="#D3FBFC" quality="high" width="'+ focus_width +'" height="'+ swf_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-fla?????????sh" />');  document.write('</object>');
                                             //-->
                                        </script>

                                    </td>
                                    <td width="346" align="right">
                                        <TopNewsUC:TopNews runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div style="height: 1px">
                </div>
                <div id="navigate">
                    <table width="616" height="44" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="108" height="24" style="background-image: url(images/line.png)" class="text"
                                align="center">
                                <asp:LinkButton ID="lkball" runat="server" OnClick="lkball_Click">全部新闻</asp:LinkButton>
                            </td>
                            <td width="85" style="background-image: url(images/line.png)" class="text">
                                <asp:LinkButton ID="lkbmovie" runat="server" OnClick="lkbmovie_Click">影视音乐</asp:LinkButton>
                            </td>
                            <td width="423" style="background-image: url(images/line.png)" class="text">
                                <asp:LinkButton ID="lbkit" runat="server" OnClick="lkbit_Click">IT科技</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="background-image: url(images/bg_line.png)">&nbsp;
                                
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 1px">
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lkball" />
                        <asp:AsyncPostBackTrigger ControlID="lkbmovie" />
                        <asp:AsyncPostBackTrigger ControlID="lbkit" />
                    </Triggers>
                    <ContentTemplate>
                        <div>
                            <asp:Repeater ID="rptmain" runat="server">
                                <ItemTemplate>
                                    <table width="616" border="1" bordercolor="#24B8FF" style="border-collapse: collapse;"
                                        cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top">
                                                <table width="614" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="16" height="29">&nbsp;
                                                            
                                                        </td>
                                                        <td colspan="2" style="font-size: 16px; font-weight: bolder; color: #60F">
                                                            <a href="/<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem,"time").ToString()).ToString("yyyy/MM/dd")%>/<%# DataBinder.Eval(Container.DataItem,"id") %>.html" target="_blank" title='<%# DataBinder.Eval(Container.DataItem, "title")%>'>
                                                                <%# DataBinder.Eval(Container.DataItem, "title")%></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="20">&nbsp;
                                                            
                                                        </td>
                                                        <td height="20" colspan="2" style="font-size: 12px; color: Gray; border-bottom: 1px dotted #cccccc">
                                                            <img src="/images/icon.gif" width="13" height="13" /><%# DataBinder.Eval(Container.DataItem, "publisher")%>发布于<%# DataBinder.Eval(Container.DataItem,"time") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;
                                                            
                                                        </td>
                                                        <td width="486" valign="top" style="font-size: 12px">
                                                            <br />
                                                            <%#CutString(GetNoHtmlstr(DataBinder.Eval(Container.DataItem, "content")), 350)%>
                                                        </td>
                                                        <td width="112" align="center" valign="middle">
                                                            <img title="<%# DataBinder.Eval(Container.DataItem, "type")%>" src="<%# DataBinder.Eval(Container.DataItem, "picaddress")%>"
                                                                width="80px" height="80" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="29" style="background-image: url(images/bg_buttom.png); height: 22px;
                                                            font-size: 12px; color: #06F">&nbsp;
                                                            
                                                        </td>
                                                        <td colspan="2" style="background-image: url(images/bg_buttom.png); height: 22px;
                                                            font-size: 12px; color: #06F">
                                                            阅读[<%# DataBinder.Eval(Container.DataItem, "readcount")%>]标签：<%# DataBinder.Eval(Container.DataItem, "type")%>
                                                            <a href="<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem,"time").ToString()).ToString("yyyy/MM/dd")%>/<%# DataBinder.Eval(Container.DataItem,"id") %>.html"
                                                                target="_blank" title='<%# DataBinder.Eval(Container.DataItem, "title")%>'>
                                                                阅读详细</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    </div>
                                    <div id="insert" style="height: 5px">
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
               
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                  <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lkball" />
                        <asp:AsyncPostBackTrigger ControlID="lkbmovie" />
                        <asp:AsyncPostBackTrigger ControlID="lbkit" />
                    </Triggers>
                    <ContentTemplate>
                        <webdiyer:AspNetPager ID="aspnetpager" CssClass="paginator" CurrentPageButtonClass="cpb"
                            runat="server" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                            PageSize="20" PrevPageText="上一页" ShowInputBox="Never" OnPageChanged="PageChanged"
                            LayoutType="Table">
                        </webdiyer:AspNetPager>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <cc1:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender1" runat="server"
                    TargetControlID="UpdatePanel1">
                    <Animations>
                        <OnUpdating>
                            <Parallel duration="0">                             
                                <ScriptAction Script="onUpdating();" />  
                             </Parallel>
                        </OnUpdating>
                        <OnUpdated>
                            <Parallel duration="0">                               
                                <ScriptAction Script="onUpdated();" /> 
                            </Parallel> 
                        </OnUpdated>
                    </Animations>
                </cc1:UpdatePanelAnimationExtender>
                <asp:Panel ID="pnlPopup" runat="server" CssClass="progress" Style="display: none;">
                    <div class="container">
                        <div class="header">
                            载入中...</div>
                        <div class="body">
                            <img alt="" src="images/activity.gif" /></div>
                    </div>
              </asp:Panel>
                <table width="614" border="1" bordercolor="#24B8FF" style="border-collapse: collapse;"
                    cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 20px; font-size: 12px; color: #60F">
                            <asp:Image ID="imgsystem" ToolTip="system" runat="server" /><%=system %><asp:Image
                                ID="imgbrowser" ToolTip="browser" runat="server" /><%=browser %><img src="icon/icon_ip.gif"
                                    title="ip" width="20px" height="20px" /><%=ip %>
                        </td>
                    </tr>
                </table>
                <div style="height: 1px">
                </div>
            </td>
            <td width="357" valign="top" align="right">
                <div>
                    <NewscommendUC:Newscommend runat="server" />
                </div>
                <div>
                    <NewshotUC:Newshot runat="server" />
                </div>
                <div>
                    <NewsreplyUC:Newsreply runat="server" />
                </div>
            </td>
        </tr>
    </table>
    <div>
        <FootUC:Foot runat="server" />
    </div>
    </form>
</body>
</html>
