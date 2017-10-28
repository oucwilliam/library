<%@ Page Language="C#" AutoEventWireup="true" CodeFile="libraryhome.aspx.cs" Inherits="library" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="home" runat="server" visible="true">
            欢迎：<br />
            <asp:Button ID="BtnUserSubmit" runat="server" Text="普通用户注册" OnClick="BtnUserSubmit_Click" />
            <asp:Button ID="BtnUserLogin" runat="server" Text="普通用户登录" OnClick="BtnUserLogin_Click" />
            <asp:Button ID="BtnChangePassword" runat="server" Text="修改密码" OnClick="BtnChangePassword_Click" />
            <asp:Button ID="BtnFindPassword" runat="server" Text="找回密码" OnClick="BtnFindPassword_Click" />
        </div>
    </form>
</body>
</html>
