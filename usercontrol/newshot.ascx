<%@ Control Language="C#" AutoEventWireup="true" CodeFile="newshot.ascx.cs" Inherits="usercontrol_newshot" %>
<table width="355" border="1" bordercolor="#24B8FF" style="border-collapse: collapse;"
                    cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="227" align="center" valign="top">
                            <table width="354" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="27" style="height: 24px; background-image: url(images/line.png)">
                                    </td>
                                    <td width="327" class="text" style="height: 24px; background-image: url(images/line.png)" align="left">
                                        人气新闻
                                    </td>
                                </tr>
                            </table>
                            <asp:Repeater ID="rpthot" runat="server">
                                <ItemTemplate>
                                    <table width="352" border="0" cellspacing="0" cellpadding="3" style="background-color: #FFFFCE">
                                        <tr>
                                            <td style="font-size: 12px; color: #60F;" align="left">
                                                <a href="<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem,"time").ToString()).ToString("yyyy/MM/dd")%>/<%# DataBinder.Eval(Container.DataItem,"id") %>.html" target="_blank" title='<%# DataBinder.Eval(Container.DataItem, "title")%>'>
                                                    <%# DataBinder.Eval(Container.DataItem, "title")%></a><font style="color: Gray">[<%# DataBinder.Eval(Container.DataItem, "readcount")%>]</font>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <table width="352" border="0" cellspacing="0" cellpadding="3" style="background-color: #FFFFAC;
                                        border-bottom: 1px dotted #cccccc;">
                                        <tr>
                                            <td style="font-size: 12px; color: #60F;" align="left">
                                                <a href="<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem,"time").ToString()).ToString("yyyy/MM/dd")%>/<%# DataBinder.Eval(Container.DataItem,"id") %>.html" target="_blank" title='<%# DataBinder.Eval(Container.DataItem, "title")%>'>
                                                    <%# DataBinder.Eval(Container.DataItem, "title")%></a><font style="color: Gray">[<%# DataBinder.Eval(Container.DataItem, "readcount")%>]</font>
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