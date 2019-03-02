<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ItemDetailPage.aspx.cs" Inherits="ItemDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form class="form-inline" runat="server" id="form">
        <div class="container" runat="server" id="inventoryDump"></div>
        <div class="container">
            <select class="selectpicker" runat="server" id="quantityDropDown" data-style="btn-primary"></select>
            <asp:Button class="btn btn-outline-primary" id='AddToCart' runat='server' Text='Add to Cart' OnClick='AddToCart_Click' />
            <asp:Button class="btn btn-outline-primary" id='ViewShoppingCart' runat="server" Text="Shopping Cart" OnClick="ViewCart_Click" />
        </div>
    </form>
</asp:Content>

