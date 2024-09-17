<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminNav.Master" AutoEventWireup="true" CodeBehind="TransactionQueue.aspx.cs" Inherits="LAB_PSD_Project.View.Admin.TransactionQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction Queue</h1>
    <hr />
    <asp:GridView ID="Transactions" runat="server" OnRowCommand="Transactions_RowCommand" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID"></asp:BoundField>
            <asp:BoundField DataField="User.Name" HeaderText="User" SortExpression="User.Name"></asp:BoundField>
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate"></asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
            <asp:ButtonField CommandName="Handle" Text="Handle" ButtonType="Button" ShowHeader="True" HeaderText="Action"></asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
