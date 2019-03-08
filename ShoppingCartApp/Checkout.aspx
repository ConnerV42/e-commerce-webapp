<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" runat="server">
        <div class="jumbotron" runat="server">
            <h1 class="display-4">Order Summary</h1>
            <h6 id="Price" runat="server"></h6>
            <h6 id="Shipping" runat="server"></h6>
            <h6 id="Total" runat="server"></h6>
            <h6 id="Quantity" runat="server"></h6>
            <h6 id="Weight" runat="server"></h6>
            <h6 id="Items" runat="server"></h6>
        </div>
        <div class="alert alert-warning alert-dismissible fade show" role="alert"></div>
        <form id="form1" runat="server">
            <div class="form-group">
                <label for="Name">Name</label>
                <input class="form-control" type="text" id="Name" runat="server" required="required"/>
            </div>
            <div class="form-group">
                <label for="Street">Shipping Address</label>
                <input class="form-control" ID="Street" runat="server" required="required"/>
            </div>
            <div class="form-group">
                <label for="City">City</label>
                <input class="form-control" ID="City" runat="server" required="required"/>
            </div>
            <div class="form-group">
                <label for="State">State</label>
                <input class="form-control" ID="State" runat="server" required="required"/>
            </div>
            <div class="form-group">
                <label for="Zip">Zip Code</label>
                <input class="form-control" ID="Zip" runat="server" required="required"/>
            </div>
            <div class="form-group">
                <label for="Year">Year</label>
                <input class="form-control" ID="Year" runat="server" required="required"/>
            </div>
            <div class="form-group">
                <label for="Email">Email Address</label>
                <input class="form-control" ID="Email" runat="server" required="required"/>
                <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
            </div>
            <asp:Button class="btn btn-outline-primary" runat="server" OnClick="SubmitOrder_Click" OnClientClick="return validateForm();" Text="Confirm Purchase"/>
        </form>
    </div>
</asp:Content>

