<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pub.aspx.cs" Inherits="publish_pub" ValidateRequest="false" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>yes!gama新闻发布页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="916" border="0" cellspacing="0" cellpadding="0" align="center">
  <tr>
    <td width="90" height="29" align="right">类别：</td>
    <td colspan="2"><asp:DropDownList ID="ddltype" runat="server"></asp:DropDownList></td>
  </tr>
  <tr>
    <td height="25" align="right">标签：</td>
    <td colspan="2"><asp:DropDownList ID="ddlpic" runat="server"></asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td height="28" align="right">标题：</td>
    <td colspan="2"><asp:TextBox ID="txttitle" runat="server" Width="248px"></asp:TextBox>&nbsp;&nbsp; 
        是否推荐：<asp:CheckBox ID="chk" runat="server" />
      &nbsp; 是否置顶：<asp:CheckBox ID="chktop" runat="server" />
      </td>
  </tr>
  <tr>
    <td height="481" align="right">内容：</td>
    <td colspan="2"><FTB:FreeTextBox ID="ftb" Width="700" Height="480" runat="server" ImageGalleryPath="~/upload/" ImageGalleryUrl = "ftb.imagegallery.aspx?rif={0}&cif={0}"  ToolbarLayout="FontFacesMenu,FontSizesMenu; FontForeColorsMenu;FontForeColorPicker; FontBackColorsMenu, FontBackColorPicker, Bold, Italic, Underline,Strikethrough,InsertImage, InsertImageFromGallery, CreateLink, Unlink,RemoveFormat, JustifyLeft, JustifyRight, JustifyCenter,JustifyFull; " ToolbarStyleConfiguration="OfficeXP" Language="zh-CN" ></FTB:FreeTextBox>
    </td>
  </tr>
  <tr>
    <td height="27" align="right">图片新闻：</td>
    <td colspan="2"><asp:TextBox ID="txtnewspic" runat="server" Height="26px" 
            Width="370px"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="right">&nbsp;</td>
    <td width="168" align="center"><asp:Button ID="ok" runat="server" Text="发布" onclick="ok_Click" /></td>
    <td width="658"><asp:Button ID="cancle" runat="server" Text="转到编辑页" onclick="cancle_Click" />
        <asp:Button ID="tagmanager" runat="server" Text="转到标签管理页" OnClick="tagmanager_Click" />
    </td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
