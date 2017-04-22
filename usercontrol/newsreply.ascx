<%@ Control Language="C#" AutoEventWireup="true" CodeFile="newsreply.ascx.cs" Inherits="usercontrol_newsreply" %>
<table width="355" border="1" bordercolor="#24B8FF" style="border-collapse: collapse;"
    cellspacing="0" cellpadding="0">
    <tr>
        <td height="227" align="center" valign="top">
            <table width="354" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="27" style="height: 24px; background-image: url(images/line.png)">
                    </td>
                    <td width="327" class="text" style="height: 24px; background-image: url(images/line.png)"
                        align="left">
                        最新回复
                    </td>
                </tr>
            </table>
            <asp:Repeater ID="rptnewsreply" runat="server">
                <ItemTemplate>
                    <table width="354" border="0" cellspacing="0" cellpadding="3" style="background-color: #FFFFCE;border-bottom: 1px dotted #cccccc;">
                        <tr>
                            <td style="font-size: 12px" align="left">
                                <%# DataBinder.Eval(Container.DataItem, "reply")%>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="font-size: 12px; color: Gray; height:20px">
                                来自<%# DataBinder.Eval(Container.DataItem, "ip").ToString().Substring(0, DataBinder.Eval(Container.DataItem, "ip").ToString().LastIndexOf(".") + 1) + "*"%>的评论(发表于<%# Convertdate2view(DataBinder.Eval(Container.DataItem, "time").ToString())%>)
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="font-size:12px; height:15px">
                                <font style="font-size:15px;">@</font>
                                    <a href="<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem,"time").ToString()).ToString("yyyy/MM/dd")%>/<%# DataBinder.Eval(Container.DataItem,"id") %>.html" target="_blank" title='<%# DataBinder.Eval(Container.DataItem, "title")%>'>
                                    <%# DataBinder.Eval(Container.DataItem, "title")%></a>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <table width="354" border="0" cellspacing="0" cellpadding="3" style="background-color: #FFFFAC;border-bottom: 1px dotted #cccccc;">
                        <tr>
                            <td style="font-size: 12px" align="left">
                                <%# DataBinder.Eval(Container.DataItem, "reply")%>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="font-size: 12px; color: Gray; height:20px">
                                来自<%# DataBinder.Eval(Container.DataItem, "ip").ToString().Substring(0, DataBinder.Eval(Container.DataItem, "ip").ToString().LastIndexOf(".") + 1) + "*"%>的评论(发表于<%# Convertdate2view(DataBinder.Eval(Container.DataItem, "time").ToString())%>)
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="font-size:12px; height:15px">
                                <font style="font-size:15px;">@</font>
                                <a href="<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem,"time").ToString()).ToString("yyyy/MM/dd")%>/<%# DataBinder.Eval(Container.DataItem,"id") %>.html" target="_blank" title='<%# DataBinder.Eval(Container.DataItem, "title")%>'>
                                    <%# DataBinder.Eval(Container.DataItem, "title")%></a>
                            </td>
                        </tr>
                    </table>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </td>
    </tr>
</table>
<div style="height: 5px">
</div>
