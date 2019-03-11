<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" runat="server">
        <div class="jumbotron" runat="server">
            <h1 class="display-4">Order Summary</h1>
            <h6 id="PriceDisplay" runat="server"></h6>
            <h6 id="ShippingDisplay" runat="server"></h6>
            <h6 id="TotalDisplay" runat="server"></h6>
            <h6 id="QuantityDisplay" runat="server"></h6>
            <h6 id="WeightDisplay" runat="server"></h6>
            <h6 id="ItemsDisplay" runat="server"></h6>
        </div>
        <div class="alert alert-warning alert-dismissible fade show" role="alert"></div>
        <form id="form1" runat="server">
            <div class="form-group">
                <label for="Name">Name</label>
                <input class="form-control" type="text" id="NameInput" runat="server" required="required"/>
            </div>
            <div class="form-group">
                <label for="Street">Shipping Address</label>
                <input class="form-control" ID="StreetInput" runat="server" required="required"/>
            </div>
            <div class="form-group">
                <label for="City">City</label>
                <input class="form-control" ID="CityInput" runat="server" required="required"/>
            </div>
            <div class="form-group">
                <label for="State">State</label>
                <input class="form-control" ID="StateInput" runat="server" required="required"/>
            </div>
            <div class="form-group">
                <label for="Zip">Zip Code</label>
                <input class="form-control" ID="ZipInput" runat="server" required="required"/>
            </div>
            <div class="form-group">
                <label for="Year">Year</label>
                <input class="form-control" ID="YearInput" runat="server" required="required"/>
            </div>
            <div class="form-group">
                <label for="Email">Email Address</label>
                <input class="form-control" ID="EmailInput" runat="server" required="required"/>
                <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
            </div>
            <asp:Button class="btn btn-outline-primary" runat="server" OnClick="SubmitOrder_Click" OnClientClick="return validateForm();" Text="Confirm Purchase"/>
        </form>
    </div>
</asp:Content>

