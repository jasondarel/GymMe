<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="LAB_PSD_Project.View.TransactionDetailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Transaction Detail</h1>
            <hr />
            <asp:Label ID="IDLbl" runat="server" Text="ID: "></asp:Label> <br />
            <asp:Label ID="UserLbl" runat="server" Text="User: "></asp:Label> <br />
            <asp:Label ID="DateLbl" runat="server" Text="Transaction Date: "></asp:Label> <br />
            <asp:Label ID="StatusLbl" runat="server" Text="Status: "></asp:Label> <br />
            <asp:GridView ID="TransactionDetails" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Supplement.Name" HeaderText="Supplement" SortExpression="Supplement.Name"></asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
