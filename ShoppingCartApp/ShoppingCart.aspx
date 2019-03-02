<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="jumbotron">
            <h1>Shopping Cart</h1>
        </div>
    </div>
    <form runat="server" id="form">
        <div class="container" runat="server" id="cartParent">
            <div class="table-responsive" runat="server" id="shoppingCart"></div>
        </div>
        <div class="container" runat="server" id="cartButtons"></div>
    </form>
</asp:Content>

