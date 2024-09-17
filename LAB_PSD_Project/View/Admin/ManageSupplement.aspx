<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminNav.Master" AutoEventWireup="true" CodeBehind="ManageSupplement.aspx.cs" Inherits="LAB_PSD_Project.View.Admin.ManageSupplement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Supplement</h1>
    <hr />
    <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click" />
    <asp:GridView ID="Supplements" runat="server" AutoGenerateColumns="False" OnRowDeleting="Supplements_RowDeleting" OnRowEditing="Supplements_RowEditing">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id"></asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
            <asp:BoundField DataField="SupplementType.Name" HeaderText="Type" SortExpression="SupplementType.Name"></asp:BoundField>
            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" SortExpression="ExpiryDate"></asp:BoundField>
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"></asp:BoundField>
            <asp:CommandField ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" ShowHeader="True" HeaderText="Actions"></asp:CommandField>
        </Columns>
    </asp:GridView>
</asp:Content>
