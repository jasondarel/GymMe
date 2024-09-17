<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LAB_PSD_Project.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Register</h1>
            <hr />
            <input id="Name" type="text" placeholder="Username" runat="server"/> <br />
            <input id="Email" type="text" placeholder="Email" runat="server"/> <br />
            <asp:Label ID="GenderLbl" runat="server" Text="Gender: "></asp:Label>
            <asp:RadioButton ID="Male" runat="server" Text="Male" GroupName="Gender"/>
            <asp:RadioButton ID="Female" runat="server" Text="Female" GroupName="Gender"/> <br />
            <asp:Label ID="DOB" runat="server" Text="Date of Birth"></asp:Label>
            <asp:Calendar ID="DOBCalendar" runat="server"></asp:Calendar>
            <input id="Password" type="password" placeholder="Password" runat="server"/> <br />
            <input id="ConfirmPassword" type="password" runat="server" placeholder="Confirm Password"/> <br />
            <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label> <br />
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" /> <br /> <br />
            <asp:LinkButton ID="Login" runat="server" OnClick="Login_Click">To Login Page</asp:LinkButton>
        </div>
    </form>
</body>
</html>
