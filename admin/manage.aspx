<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage.aspx.cs" Inherits="admin_manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="500" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="163">
                    用户名
                </td>
                <td width="148">
                    密码
                </td>
                <td width="96">
                    权限
                </td>
                <td width="93">
                    操作
                </td>
            </tr>
        </table>
        <asp:Repeater ID="rpt" runat="server">
            <ItemTemplate>
                <table width="500" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="163">
                            <%# DataBinder.Eval(Container.DataItem, "username")%>
                        </td>
                        <td width="149">
                            <%# DataBinder.Eval(Container.DataItem, "password")%>
                        </td>
                        <td width="96">
                            <%# DataBinder.Eval(Container.DataItem, "power")%>
                        </td>
                        <td width="92">
                            <asp:LinkButton ID="lb" OnClick="lb_Click" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>'>删除</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <table width="500" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <asp:Button ID="btnadd" runat="server" Text="添加" onclick="btnadd_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnviewsys" runat="server" Text="查看系统日志" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
