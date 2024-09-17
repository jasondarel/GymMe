<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminNav.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LAB_PSD_Project.View.Admin.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Home</h1>
    <hr />
    <asp:Label ID="Role" runat="server" Text="Role: "></asp:Label>
    <br />
    <asp:GridView ID="Customers" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
            <asp:BoundField DataField="DOB" HeaderText="Date of Birth" SortExpression="DOB"></asp:BoundField>
            <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender"></asp:BoundField>
            </Columns>
    </asp:GridView>
</asp:Content>
