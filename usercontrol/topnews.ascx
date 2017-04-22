<%@ Control Language="C#" AutoEventWireup="true" CodeFile="topnews.ascx.cs" Inherits="usercontrol_topnews" %>
<table width="344" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td height="29">
        </td>
        <td height="29" align="center" style="font-size: 16px; font-weight: bolder">
            <a href="<%=Convert.ToDateTime(stime).ToString("yyyy/MM/dd")%>/<%=id %>.html" target="_blank">
                [置顶]<%=title %></a>
        </td>
    </tr>
    <tr>
        <td height="67" style="font-size: 12px;" width="6" valign="bottom">
            <hr style="border-style: dashed; color: #CCC;" />
        </td>
        <td width="332" align="left" style="font-size: 12px;">
            <%=content %>
            <hr style="border-style: dashed; color: #CCC;" />
        </td>
    </tr>
    <tr>
        <td height="100" colspan="2" valign="top">
            <asp:Repeater ID="rpttopnews" runat="server">
                <ItemTemplate>
                    <table width="344" border="0" cellspacing="0" cellpadding="1" style="border-bottom: 1px dotted #cccccc">
                        <tr>
                            <td width="6">
                            </td>
                            <td width="329" align="left" style="font-size: 12px">
                                <a href="<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem,"time").ToString()).ToString("yyyy/MM/dd")%>/<%# DataBinder.Eval(Container.DataItem,"id") %>.html"
                                    target="_blank" title='<%# DataBinder.Eval(Container.DataItem, "title")%>'>
                                    <%# DataBinder.Eval(Container.DataItem,"title") %></a><font style="color: Gray">[<%# DataBinder.Eval(Container.DataItem,"readcount") %>]</font>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </td>
    </tr>
</table>
