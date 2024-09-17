<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminNav.Master" AutoEventWireup="true" CodeBehind="TransactionReportPage.aspx.cs" Inherits="LAB_PSD_Project.View.Admin.TransactionReportPage" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CR:CrystalReportViewer ID="TransactionReportViewer" runat="server" AutoDataBind="true" />
</asp:Content>
