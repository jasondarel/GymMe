<%@ Page Title="" Language="C#" MasterPageFile="~/View/Customer/CustomerNav.Master" AutoEventWireup="true" CodeBehind="OrderSupplement.aspx.cs" Inherits="LAB_PSD_Project.View.Customer.OrderSupplement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Order Supplement</h1>
    <hr />
    <h2>Supplements</h2>
    <asp:GridView ID="Supplements" runat="server" AutoGenerateColumns="false" OnRowCommand="Supplements_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id"></asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" SortExpression="ExpiryDate"></asp:BoundField>
            <asp:BoundField DataField="SupplementType.Name" HeaderText="Type" SortExpression="SupplementType.Name"></asp:BoundField>
            <asp:BoundField DataField="Price" HeaderText="Price (Rp)" SortExpression="Price"></asp:BoundField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="Quantity" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="Order" Text="Order" ButtonType="Button" ShowHeader="True" HeaderText="Action"></asp:ButtonField>
        </Columns>
    </asp:GridView>
    <br />
    <hr />
    <h2>Cart</h2>
    <asp:GridView ID="Carts" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id"></asp:BoundField>
            <asp:BoundField DataField="Supplement.Name" HeaderText="Supplement" SortExpression="Supplement.Name"></asp:BoundField>
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="ClearCartBtn" runat="server" Text="Clear Cart" OnClick="ClearCartBtn_Click" />
    <asp:Button ID="ChekcoutBtn" runat="server" Text="Check out" OnClick="ChekcoutBtn_Click" />
</asp:Content>
