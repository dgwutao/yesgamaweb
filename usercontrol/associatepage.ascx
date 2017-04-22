<%@ Control Language="C#" AutoEventWireup="true" CodeFile="associatepage.ascx.cs" Inherits="usercontrol_associatepage" %>
<table width="354" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td style="width: 13px; height: 33px; background-image: url(/images/dialog_lt.png)">
            &nbsp;
        </td>
        <td valign="bottom" style="background-image: url(/images/dialog_ct.png); font-weight: bolder;
            color: #FFF" align="left">
            相关新闻
        </td>
        <td style="width: 13px; background-image: url(/images/dialog_rt.png)">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="background-image: url(/images/dialog_mlt.png)">
            &nbsp;
        </td>
        <td>
            <asp:Repeater ID="rptassociate" runat="server">
                <ItemTemplate>
                    <table width="324" border="0" cellspacing="0" cellpadding="3" style="border-bottom: 1px dotted #cccccc;">
                        <tr>
                            <td style="font-size: 12px;" align="left">
                                    <a href="/<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem,"time").ToString()).ToString("yyyy/MM/dd")%>/<%# DataBinder.Eval(Container.DataItem,"id") %>.html" target="_parent" title='<%# DataBinder.Eval(Container.DataItem, "title")%>'>
                                    <%# DataBinder.Eval(Container.DataItem, "title")%></a><font style="color:Gray">[<%# DataBinder.Eval(Container.DataItem, "readcount")%>](<%# Convertdate2view(DataBinder.Eval(Container.DataItem, "time").ToString())%>)</font>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
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
