<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InventoryPage.aspx.cs" Inherits="InventoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="jumbotron">
            <h1>Browse Sneakers</h1>
            <p>Browse a selection of premium, deadstock sneakers that are packaged in
                box, with original receipt. Choose from highly sought after brands
                such as Nike, Air Jordan, and Adidas.
            </p>
        </div>
    </div>
    <div class="container" runat="server" id="inventoryDump"></div>
</asp:Content>