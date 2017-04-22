<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tagmanager.aspx.cs" Inherits="publish_tagmanager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>标签管理页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="tag">
        <asp:Repeater ID="rpttag" runat="server">
            <ItemTemplate>
                <table width="553" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="106">
                        <%# DataBinder.Eval(Container.DataItem, "type")%>
                        </td>
                        <td width="302">
                        <%# DataBinder.Eval(Container.DataItem, "picaddress")%>
                        </td>
                        <td width="145">
                            <asp:LinkButton ID="lb" OnClientClick="return confirm('删除后不能恢复，确认删除吗？')" OnClick="lb_Click"
                                runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>'>删除</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div id="add">
        <table width="553" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <asp:FileUpload ID="fileupload" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    标签：<asp:TextBox ID="txttag" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnok" runat="server" Text="确定" OnClick="btnok_Click" />
                    <asp:Button ID="btnback" runat="server" Text="回到发布页" onclick="btnback_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
