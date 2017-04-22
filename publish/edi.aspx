<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edi.aspx.cs" Inherits="publish_edi" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑新闻页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="rpt" runat="server">
            <ItemTemplate>
                <table width="887" border="0" cellspacing="0" cellpadding="0" style="border-bottom: 1px dotted #cccccc;">
                    <tr>
                        <td width="331">
                            <%# DataBinder.Eval(Container.DataItem,"title") %>
                        </td>
                        <td width="366">
                        类别：
                        <%# DataBinder.Eval(Container.DataItem,"category") %>
                        标签：
                      <%# DataBinder.Eval(Container.DataItem,"type") %>发布：
                            <%# DataBinder.Eval(Container.DataItem,"publisher") %>
                        </td>
                        <td width="47">
                            <a href="repub.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id") %>" target="_blank" >编辑</a>
                        </td>
                        <td width="143">
                            <asp:LinkButton ID="lb" OnClientClick="return confirm('删除后不能恢复，确认删除吗？')"  OnClick="lb_Click" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>'>删除</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <webdiyer:AspNetPager Style="font-size: 13px" ID="AspNetPager1" runat="server" PageSize="50"
                ShowPageIndexBox="Always" CustomInfoTextAlign="Center" ShowNavigationToolTip="True" 
                CustomInfoHTML="<font color='gray'>第<b>%CurrentPageIndex%</b>页 共%PageCount%页  范围: %StartRecordIndex%-%EndRecordIndex%</font>"
                InputBoxStyle="width:19px" meta:resourceKey="AspNetPager1" Width="400px" ShowCustomInfoSection="Left"
                OnPageChanged="AspNetPager1_PageChanged" HorizontalAlign="Center"  PageIndexBoxType="DropDownList" TextBeforePageIndexBox="转到第" TextAfterPageIndexBox="页">
            </webdiyer:AspNetPager>
        <asp:Button ID="goback" runat="server" Text="回到发布页" onclick="goback_Click" />    
    </div>
    </form>
</body>
</html>
