<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminNav.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="LAB_PSD_Project.View.Admin.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Profile</h1>
    <hr />
    <input id="Username" type="text" runat="server" placeholder="Username"/> <br />
    <input id="Email" type="text" runat="server" placeholder="Email"/> <br />

    <asp:Label runat="server" Text="Gender: "></asp:Label>
    <asp:RadioButton runat="server" ID="Male" Text="Male" GroupName="Gender"></asp:RadioButton>
    <asp:RadioButton runat="server" ID="Female" Text="Female" GroupName="Gender"></asp:RadioButton>

    <br />
    <asp:Label runat="server" Text="Date of Birth:"></asp:Label>
    <asp:Calendar runat="server" ID="DOB"></asp:Calendar>
    <asp:Label ID="ErrorLbl1" runat="server" Text="" ForeColor="Red"></asp:Label> <br />
    <asp:Button ID="UpdateProfBtn" runat="server" Text="Update Profile" OnClick="UpdateProfBtn_Click" />
    <br />
    <br />
    <br />
    <br />
    <input id="OldPassword" type="password" runat="server" placeholder="Old Password"/> <br />
    <input id="NewPassword" type="password" runat="server" placeholder="New Password"/> <br />
    <asp:Label ID="ErrorLbl2" runat="server" Text="" ForeColor="Red"></asp:Label> <br />
    <asp:Button ID="UpdatePassBtn" runat="server" Text="Update Password" OnClick="UpdatePassBtn_Click"/>

</asp:Content>
