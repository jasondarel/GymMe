<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminNav.Master" AutoEventWireup="true" CodeBehind="UpdateSupplement.aspx.cs" Inherits="LAB_PSD_Project.View.Admin.UpdateSupplement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update Supplement</h1>
    <hr />
    <input id="NameTF" type="text" runat="server" placeholder="Name"/> <br />
    <input id="PriceTF" type="text" runat="server" placeholder="Price"/> <br />
    <asp:Label ID="TypeIDLbl" runat="server" Text="Type: "></asp:Label>
    <asp:DropDownList ID="TypeNameDD" runat="server"></asp:DropDownList> <br />
    <asp:Label ID="ExpiryLbl" runat="server" Text="Expiry Date:"></asp:Label> <br />
    <asp:Calendar ID="ExpiredCal" runat="server"></asp:Calendar> 
    <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label> <br /> <br />
    <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" />
    <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
</asp:Content>
