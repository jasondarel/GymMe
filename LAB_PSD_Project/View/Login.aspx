<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LAB_PSD_Project.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1>
            <hr />
            <input id="Name" runat="server" type="text" placeholder="Username"/> <br />
            <input id="Password" runat="server" type="password" placeholder="Password"/> <br />
            <asp:CheckBox ID="RememberMe" runat="server" Text="Remember Me"/> <br />
            <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label> <br />
            <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" /> <br /> <br />
            <asp:LinkButton ID="Register" runat="server" OnClick="Register_Click">To Register Page</asp:LinkButton> <br />
        </div>
    </form>
</body>
</html>
