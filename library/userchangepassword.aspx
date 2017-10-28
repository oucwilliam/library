<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userchangepassword.aspx.cs" Inherits="userchangepassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            修改密码:<br />
            用户名：<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
            原密码：<asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            新密码：<asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            确认密码：<asp:TextBox ID="txtCheckPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            绑定的手机号：<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox><br />
            验证码：
            <asp:TextBox ID="tbx_yzm" runat="server" Width="70px"></asp:TextBox>
            <asp:ImageButton ID="ibtn_yzm" runat="server" />
            <a href="javascript:changeCode()"style="text-decoration: underline; font-size:10px;">换一张</a>
            <script type="text/javascript">
            function changeCode() 
            {
             document.getElementById('ibtn_yzm').src = document.getElementById('ibtn_yzm').src + '?';
             }
             </script><br />
            <asp:Button ID="BtnChangePassword" runat="server" Text="修改密码" OnClick="BtnChangePassword_Click" />
            <asp:Button ID="BackHome" runat="server" Text="返回主页" OnClick="BackHome_Click" />
        </div>
    </form>
</body>
</html>
