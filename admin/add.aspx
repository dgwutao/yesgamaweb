<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add.aspx.cs" Inherits="admin_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="300" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="71" align="right">
                    用户名：
                </td>
                <td width="229">
                    <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    密码：
                </td>
                <td>
                    <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    权限：
                </td>
                <td>
                    <asp:DropDownList ID="ddlpower" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnadd" runat="server" Text="添加" onclick="btnadd_Click" />
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
