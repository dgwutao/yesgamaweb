<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userreply.ascx.cs" Inherits="usercontrol_userreply" %>
<table width="354" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td style="width: 13px; height: 33px; background-image: url(/images/dialog_lt.png)">
            &nbsp;
        </td>
        <td align="left" valign="bottom" style="background-image: url(/images/dialog_ct.png); color: #FFF;
            font-weight: bolder">
            评论
        </td>
        <td style="width: 13px; background-image: url(/images/dialog_rt.png)">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="background-image: url(/images/dialog_mlt.png)">
            &nbsp;
        </td>
        <td align="center">
            <div id="noreply" style="font-size: 14px; color: Gray" align="left" runat="server">
                尚无评论</div>
            <div id="reply" runat="server">
                <asp:Repeater ID="rptreply" runat="server" OnItemDataBound="rptreply_ItemDataBound">
                    <ItemTemplate>
                    <div style="height:2px"></div>
                        <table width="320" border="0" cellspacing="0" cellpadding="0" style="border-bottom: 1px dotted #cccccc">
                            <tr>
                                <td align="left" style="font-size: 12px;">
                                    <font style="color: Gray;"><%#  DataBinder.Eval(Container.DataItem, "ip").ToString().Substring(0, DataBinder.Eval(Container.DataItem, "ip").ToString().LastIndexOf(".") + 1) + "*"%>发表于<%# Convertdate2view(DataBinder.Eval(Container.DataItem, "time").ToString())%></font><asp:LinkButton ID="lbcancle" OnClick="lbcancle_Click" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>'><font style="color:Red">delete</font></asp:LinkButton><br /><br />
                                    <%# DataBinder.Eval(Container.DataItem,"reply") %>
                                </td>
                            </tr>
                        </table>
                        <div style="height: 4px">
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
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
